using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDialogueEvent : MonoBehaviour
{
    private DialogueManager myDialogueManager;
    private IntroEventManager myEventManager; 

    private bool newEvent = false; 

    // Start is called before the first frame update
    void Start()
    {
        myDialogueManager = GameObject.FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        myEventManager = GetComponent<IntroEventManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (myDialogueManager.talking && !newEvent)
        {
            newEvent = true;
        }

        if (!myDialogueManager.talking && newEvent)
        {
            newEvent = false;
            myEventManager.NextEvent();
        }
    }
}
