using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerControl myPlayerControl;
    private GameObject cameraObject; 

    [SerializeField]
    private Transform teleportLocation;

    [SerializeField]
    private GameObject roomFader, buttonIndicator;

    [SerializeField]
    private float timeToTeleport, timeToWait; //Make sure this is same time as black screen anim
    private bool playerInRange = false, teleportStarted = false; 
    

    void Start()
    {
        myPlayerControl = GameObject.FindObjectOfType<PlayerControl>().GetComponent<PlayerControl>();
        cameraObject = GameObject.Find("Main Camera"); 

        if (cameraObject == null)
        {
            cameraObject = GameObject.Find("MainCamera"); 
            if (cameraObject == null)
            {
                Debug.Log("Can't find Camera! Is it named 'Main Camera'?"); 
            }
        }

        roomFader.SetActive(false);
        buttonIndicator.SetActive(false);

        timeToTeleport = 2f;
        timeToWait = 1f; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            buttonIndicator.SetActive(true); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            buttonIndicator.SetActive(false); 
        }
    }


    public void OnInteractKey(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (playerInRange && !teleportStarted)
            {
                teleportStarted = true;
                StartCoroutine(TeleportPlayer());
            }
        }
    }


    IEnumerator TeleportPlayer()
    {
        Debug.Log("starting teleport");
        myPlayerControl.SetMoveState(false); 
        roomFader.SetActive(true); 

        yield return new WaitForSeconds(timeToTeleport);

        myPlayerControl.gameObject.transform.position = teleportLocation.position;
        cameraObject.transform.position = new Vector3(teleportLocation.position.x, teleportLocation.position.y, cameraObject.transform.position.z); 

        yield return new WaitForSeconds(timeToWait);

        //Debug.Log("ending teleport"); 
        roomFader.SetActive(false);
        buttonIndicator.SetActive(false);
        myPlayerControl.SetMoveState(true); 
        teleportStarted = false; 

    }
}
