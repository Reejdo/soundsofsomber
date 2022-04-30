using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDoor : MonoBehaviour
{
    private Vector3 newPosition, originalPosition; 
    public float heightToMove;
    public float moveDuration;
    public float forceToPlayer; 
    public float speedToMove, speedDropMultiplier; 
    public bool startedMove, moveUp, moveDown;
    private PlayerControl myPlayerControl;
    private Transform playerTrans; 

    // Start is called before the first frame update
    void Start()
    {
        myPlayerControl = GameObject.FindObjectOfType<PlayerControl>().GetComponent<PlayerControl>();
        playerTrans = GameObject.FindWithTag("MainPlayer").GetComponent<Transform>(); 

        originalPosition = transform.position;
        newPosition = new Vector3(transform.position.x, transform.position.y + heightToMove, transform.position.z); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDoorMove()
    {
        if (!moveDown && !startedMove)
        {
            startedMove = true; 
            StartCoroutine(DoorMove());
        }

    }

    private void FixedUpdate()
    {
        if (moveUp)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, speedToMove * Time.deltaTime);
        }
        if (moveDown)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, speedToMove * speedDropMultiplier * Time.deltaTime); 
        }
    }

    IEnumerator DoorMove()
    {
        moveUp = true; 
        yield return new WaitForSeconds(moveDuration);
        moveUp = false; 
        moveDown = true;
        yield return new WaitForSeconds(1f);
        moveDown = false;
        startedMove = false; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (moveDown)
            {
                Debug.Log("Door hit player");
                if (playerTrans.position.x <= transform.position.x)
                {
                    StartCoroutine(myPlayerControl.AddForce(-1, forceToPlayer));
                }
                else
                {
                    StartCoroutine(myPlayerControl.AddForce(1, forceToPlayer));
                }
            }
        }
    }
}
