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
    private Rigidbody2D myRigidBody; 

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (interactPressed && playerInRange)
        {
            myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation; 
        }
        else if (interactPressed && !playerInRange)
        {
            myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            //myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else if (!interactPressed)
        {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            playerInRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            playerInRange = false;
        }
    }
}
