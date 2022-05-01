using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReactionLoadLevel : MonoBehaviour
{
    private PlayerControl myPlayerControl; 
    private bool startDialogue = false, startLoad = false, playerInRange;
    public List<string> lines;
    [SerializeField]
    private ReactionDialogue myReactDialogue;
   
    [SerializeField]
    private float timeWaitToLoad = 2f;

    [SerializeField]
    private GameObject roomFader, buttonIndicator, additionalObject;
    public UnityEvent LoadScene;

    // Start is called before the first frame update
    void Start()
    {
        myPlayerControl = GameObject.FindObjectOfType<PlayerControl>().GetComponent<PlayerControl>();

        if (buttonIndicator != null)
        {
            buttonIndicator.SetActive(false);
        }
        myReactDialogue = GameObject.FindObjectOfType<ReactionDialogue>().GetComponent<ReactionDialogue>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (startDialogue && !myReactDialogue.isTalking)
        {
            if (!startLoad)
            {
                startLoad = true;
                StartCoroutine(StartLoad()); 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (buttonIndicator != null)
            {
                buttonIndicator.SetActive(true);
            }
            playerInRange = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (buttonIndicator != null)
            {
                buttonIndicator.SetActive(false);
            }
            playerInRange = false; 
        }
    }

    public void UponInteractReaction()
    {
        if (playerInRange && !startDialogue)
        {
            startDialogue = true;
            myReactDialogue.StartDialogue(lines);
            myPlayerControl.SetMoveState(false);
            if (additionalObject != null)
            {
                additionalObject.SetActive(false);
            }
        }

    }

    IEnumerator StartLoad()
    {
        roomFader.SetActive(true); 
        yield return new WaitForSeconds(timeWaitToLoad);
        LoadScene.Invoke();

    }
}
