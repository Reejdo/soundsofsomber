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

    public GameObject disableDoor;
    private SpriteRenderer disableDoorSR; 
    private bool startedMove, moveUp, moveDown;

    private PlayerControl myPlayerControl;
    private Transform playerTrans;
    private AudioManager myAudioManager; 

    // Start is called before the first frame update
    void Start()
    {
        myPlayerControl = GameObject.FindObjectOfType<PlayerControl>().GetComponent<PlayerControl>();
        playerTrans = GameObject.FindWithTag("MainPlayer").GetComponent<Transform>();
        myAudioManager = GameObject.FindObjectOfType<AudioManager>().GetComponent<AudioManager>(); 
        disableDoorSR = disableDoor.GetComponentInChildren<SpriteRenderer>(); 

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
        disableDoor.SetActive(true);
        if (disableDoorSR.color.a == 0)
        {
            StartCoroutine(FadeIn(0.5f));
        }

        moveUp = true; 
        yield return new WaitForSeconds(moveDuration);
        moveUp = false; 
        moveDown = true;
        yield return new WaitForSeconds(0.75f);
        myAudioManager.Play("DoorSlam");
        yield return new WaitForSeconds(0.25f); 
        moveDown = false;
        startedMove = false;


        StartCoroutine(FadeOut(0.5f));
        yield return new WaitForSeconds(0.5f); 
        disableDoor.SetActive(false); 


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (moveDown)
            {
                //Debug.Log("Door hit player");
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

    IEnumerator FadeOut(float fadeTime)
    {
        float elapsedTime = 0.0f;
        Color c = disableDoorSR.color;
        while (elapsedTime < fadeTime)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
            disableDoorSR.color = c;
        }
    }

    IEnumerator FadeIn(float fadeTime)
    {
        float elapsedTime = 0.0f;
        Color c = disableDoorSR.color;
        while (elapsedTime < fadeTime)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / fadeTime);
            disableDoorSR.color = c;
        }
    }

}
