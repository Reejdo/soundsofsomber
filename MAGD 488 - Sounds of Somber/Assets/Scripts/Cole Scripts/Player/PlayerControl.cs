using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField] 
    private float horizontalValue;
    [SerializeField]
    private float lastPosX;
    [SerializeField]
    private float jumpSpeed = 1.0f, timeBetweenJumps = 0.5f;
    [SerializeField]
    private Vector2 groundCheckValues; 
    [SerializeField]
    private Transform groundCheck; 
    [SerializeField]
    private LayerMask groundLayer;

    //Used for inspector
    [SerializeField] public float displayXVelocitiy;

    public AudioManager myAudioManager;
    private DataManager myDataManager; 
    private Rigidbody2D myRigidBody;
    private Animator myAnim;
    private bool playingMoveSound; 

    private Vector2 playerVelocity;
    [SerializeField]
    private bool isHousePlayer = false;
    [SerializeField] private bool displayIsGrounded; //used for inspector
    public bool needKinematicOff = false;
    public bool canMove;
    [SerializeField]
    private bool canJump = true;
    public bool hasJumped = false; //used in other scripts
    private bool isMoving, isKnocked; 


    // Start is called before the first frame update
    void Start()
    {
        lastPosX = 1; //make sure the animator knows where to start

        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myAudioManager = GameObject.FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
        myDataManager = GameObject.FindObjectOfType<DataManager>().GetComponent<DataManager>(); 

        canMove = true; 
    }


    // Update is called once per frame
    void Update()
    {
        if (myAudioManager == null)
        {
            FindAudioManager();
        }

        displayXVelocitiy = myRigidBody.velocity.x; 

        //Used for inspector
        displayIsGrounded = IsGrounded();

        PlayerMove();
        SetLastPosition();
        PlayerAudioPlay(); 

        myAnim.SetBool("isMoving", isMoving);
        myAnim.SetFloat("horVal", horizontalValue);
        myAnim.SetFloat("lastPosX", lastPosX);
        if (!isHousePlayer)
        {
            myAnim.SetBool("isGrounded", IsGrounded()); 
        }

    }

    public bool IsGrounded()
    {
        bool isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckValues, 0f, groundLayer);

        return isGrounded; 
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (canMove)
        {
            horizontalValue = context.ReadValue<Vector2>().x;
        }
        else
        {
            horizontalValue = 0; 
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!isHousePlayer)
        {
            if (context.performed && IsGrounded() && canJump && canMove)
            { 
                myAudioManager.Play("Jump"); 
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpSpeed);
                StartCoroutine(WaitToJump());
            }

            if (context.canceled && myRigidBody.velocity.y > 0f)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0);
            }
        }
    }

    void PlayerAudioPlay()
    {
        string thisMoveSound = ""; 

        if (myAudioManager != null)
        {
            if (myDataManager.lastLevelLoaded == "ChapterOne" || myDataManager.lastLevelLoaded == "Tutorial")
            {
                //Debug.Log("snow");
                thisMoveSound = "MoveSnow";
            }
            else if (myDataManager.lastLevelLoaded == "ChapterTwo")
            {
                //Debug.Log("dirt");
                thisMoveSound = "MoveDirt";
            }
            else
            {
                //Debug.Log("house");
                thisMoveSound = "MoveHouse";
            }

            if (isMoving && IsGrounded() && !playingMoveSound)
            {
                myAudioManager.Play(thisMoveSound);
                playingMoveSound = true;
            }
            else if (!isMoving || !IsGrounded() && playingMoveSound)
            {
                //Debug.Log("this sound:" + thisMoveSound); 
                myAudioManager.StopSound(thisMoveSound);
                playingMoveSound = false;
            }
        }

    }

    void PlayerMove()
    {
        if (canMove)
        {
            if (!needKinematicOff)
            {
                //for knockback section
                if (!isKnocked)
                {
                    if (IsGrounded() && Mathf.Abs(horizontalValue) < 1 && !hasJumped)
                    {
                        myRigidBody.velocity = new Vector2(0f, 0f);
                        myRigidBody.isKinematic = true;
                    }
                    else
                    {
                        myRigidBody.velocity = new Vector2(horizontalValue * playerSpeed, myRigidBody.velocity.y);
                        myRigidBody.isKinematic = false;
                    }
                }
                else //if isKnocked
                {
                    myRigidBody.isKinematic = false;
                    myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, myRigidBody.velocity.y);
                }
            }
            if (needKinematicOff)
            {
                myRigidBody.isKinematic = false;
                myRigidBody.velocity = new Vector2(horizontalValue * playerSpeed, myRigidBody.velocity.y);
            }
        }
        else
        {
            myRigidBody.isKinematic = false;
            myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
        }

        if (horizontalValue > 0 || horizontalValue < 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    void SetLastPosition()
    {
        if (horizontalValue > 0.1)
        {
            lastPosX = 1; 
        }
        else if (horizontalValue < -0.1)
        {
            lastPosX = -1; 
        }
    }

    IEnumerator WaitToJump()
    {
        hasJumped = true; 
        //Debug.Log("Wait to Jump"); 
        canJump = false; 
        yield return new WaitForSeconds(timeBetweenJumps);
        canJump = true;
        hasJumped = false; 
        //Debug.Log("Jump returned"); 
    }

    void FindAudioManager()
    {
        while (myAudioManager == null)
        {
            myAudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            Debug.Log("finding audio manager"); 
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheck.position, groundCheckValues); 
        //Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius); 
    }

    public IEnumerator AddForce(int direction, float forceToAdd)
    {
        isKnocked = true; 
        //Debug.Log("Add force");
        myRigidBody.AddForce(transform.right * direction * forceToAdd);
        yield return new WaitForSeconds(0.5f);
        isKnocked = false; 
    }

    public void SetMoveState(bool state)
    {
        canMove = state; 
    }

}
