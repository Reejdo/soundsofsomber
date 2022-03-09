using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlockInteract : MonoBehaviour
{
    [SerializeField]
    private bool interactPressed; 
    [SerializeField]
    private bool playerInRange = false;
    public string playerTag = "Player";
    private Transform playerTransform; 
    [SerializeField]
    private Rigidbody2D playerRigidBody; 
    [SerializeField]
    private PlayerControl myPlayerControl; 

    private Rigidbody2D myRigidBody; 

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        playerRigidBody = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody2D>();
        myPlayerControl = GameObject.FindGameObjectWithTag(playerTag).GetComponent<PlayerControl>();
        playerTransform = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        BoxInteraction();

        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, -5f); 
    }

    void BoxInteraction()
    {
        if (myPlayerControl.IsGrounded())
        {
            if (playerTransform.position.y <= gameObject.transform.position.y)
            {
                if (interactPressed && playerInRange)
                {
                    myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
                    gameObject.GetComponent<FixedJoint2D>().enabled = true;
                    gameObject.GetComponent<FixedJoint2D>().connectedBody = playerRigidBody;
                }
                else if (!interactPressed)
                {
                    gameObject.GetComponent<FixedJoint2D>().enabled = false;
                    myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                }
            }
        }
        else if (!myPlayerControl.IsGrounded())
        {
            gameObject.GetComponent<FixedJoint2D>().enabled = false;
            myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }


    }

    public void OnInteractKey(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
            Debug.Log("pressed");
        }

        if (context.canceled)
        {
            interactPressed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            playerInRange = false;
        }
    }
}
