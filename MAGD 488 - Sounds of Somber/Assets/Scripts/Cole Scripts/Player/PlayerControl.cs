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
    private float jumpSpeed = 1.0f, timeBetweenJumps = 0.5f, groundCheckRadius = 0.2f;
    [SerializeField]
    private Transform groundCheck; 
    [SerializeField]
    private LayerMask groundLayer;

    public bool needKinematicOff = false; 

    //Used for inspector
    [SerializeField] private bool displayIsGrounded;
    [SerializeField] public float playerXVelocitiy; 

    private Rigidbody2D myRigidBody;

    //private bool isFacingRight = true; 
    
    private Vector2 playerVelocity;
    private bool groundedPlayer;

    public bool canMove;
    [SerializeField]
    private bool canJump = true;
    public bool hasJumped = false; //used in other scripts


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        canMove = true; 
    }


    // Update is called once per frame
    void Update()
    {
        playerXVelocitiy = myRigidBody.velocity.x; 

        //Used for inspector
        displayIsGrounded = IsGrounded();

        PlayerMove(); 
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
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
        if (context.performed && IsGrounded() && canJump && canMove)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpSpeed);
            StartCoroutine(WaitToJump()); 
        }

        if (context.canceled && myRigidBody.velocity.y > 0f)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0); 
        }
    }

    void PlayerMove()
    {
        if (canMove)
        {
            if (!needKinematicOff)
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
}
