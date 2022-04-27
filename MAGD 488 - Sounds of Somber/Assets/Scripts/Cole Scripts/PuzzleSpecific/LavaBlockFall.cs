using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBlockFall : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    private LavaBlockStart myBlockStart;
    private GameObject playerObject;
    public bool parentPlayer = true; 

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBlockStart = GameObject.FindObjectOfType<LavaBlockStart>().GetComponent<LavaBlockStart>();
        playerObject = GameObject.Find("player"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        if (myBlockStart.startFalling)
        {
            //myRigidBody.MovePosition(gameObject.transform.position * weight + myBlockStart.fallLocation.position * (1 - weight));
            Vector3 velocity = new Vector3(0, -myBlockStart.blockSpeed, 0f);
            transform.position += (velocity * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && parentPlayer)
        {
            playerObject.transform.SetParent(transform); 
        }
    }

    /*
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerObject.transform.SetParent(transform); 
        }
    }
    */ 
}
