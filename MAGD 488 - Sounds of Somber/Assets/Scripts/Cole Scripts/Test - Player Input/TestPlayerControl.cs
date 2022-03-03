using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class TestPlayerControl : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    private float horizontalValue; 
    [SerializeField]
    private float jumpSpeed = 1.0f, timeBetweenJumps = 0.5f;
    [SerializeField]
    private Transform groundCheck; 
    [SerializeField]
    private LayerMask groundLayer; 
    
    private Rigidbody2D myRigidBody;

    private bool isFacingRight = true; 
    
    
    private Vector2 playerVelocity;
    private bool groundedPlayer;

    [SerializeField]
    private bool canJump = true;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>(); 
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(IsGrounded()); 

        myRigidBody.velocity = new Vector2(horizontalValue * playerSpeed, myRigidBody.velocity.y);

        if (!isFacingRight && horizontalValue > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontalValue < 0f)
        {
            Flip(); 
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 localScale = transform.localScale;
        localScale.x = -1f;
        transform.localScale = localScale;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        horizontalValue = context.ReadValue<Vector2>().x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded() && canJump)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpSpeed);
            StartCoroutine(WaitToJump()); 
        }

        if (context.canceled && myRigidBody.velocity.y > 0f)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0); 
        }
    }

    IEnumerator WaitToJump()
    {
        Debug.Log("Wait to Jump"); 
        canJump = false; 
        yield return new WaitForSeconds(timeBetweenJumps);
        canJump = true;
        Debug.Log("Jump returned"); 
    }
}
