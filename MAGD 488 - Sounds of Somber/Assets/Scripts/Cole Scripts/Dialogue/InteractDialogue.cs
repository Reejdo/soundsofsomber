using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractDialogue : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private DialogueTrigger[] dialogueTrigger;
    
    private PlayerNPCInteract npcInteract;
    
    [SerializeField] private GameObject buttonDisplay;
    [SerializeField] private int typesOfDialogue;

    public int dialogueCounter;
    public bool hasFinalDialogue;
    public int finalDialogueNumber;

    [SerializeField] private bool isPressed; 

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        npcInteract = FindObjectOfType<PlayerNPCInteract>();
        buttonDisplay.SetActive(false);

    }

    void DialogueInteract()
    {
        if (npcInteract.inRange && !dialogueManager.talking)
        {
            if (!hasFinalDialogue && dialogueCounter > 0)
            {
                if (typesOfDialogue > 1 && dialogueCounter >= typesOfDialogue)
                {
                    dialogueCounter = 1;
                }
            }
            else if (typesOfDialogue > 1 && dialogueCounter >= typesOfDialogue && hasFinalDialogue)
            {
                dialogueCounter = finalDialogueNumber;
            }
            else
            {
                dialogueCounter++;
            }

            if (!hasFinalDialogue)
            {
                dialogueTrigger[dialogueCounter - 1].TriggerDialogue();
            }

            else if (hasFinalDialogue)
            {
                if (dialogueCounter != finalDialogueNumber)
                {
                    dialogueTrigger[dialogueCounter - 1].TriggerDialogue();
                }
                else if (dialogueCounter == finalDialogueNumber)
                {
                    dialogueTrigger[finalDialogueNumber - 1].TriggerDialogue();
                }

            }
        }
        else if (dialogueManager.talking)
        {
            dialogueManager.DisplayNextSentence();
        }
    }

    public void OnInteractKey(InputAction.CallbackContext context)
    {
        if (context.performed && isPressed == false)
        {
            isPressed = true; 
            DialogueInteract();
        }

        if (context.canceled)
        {
            isPressed = false; 
        }
    }



    // Update is called once per frame
    void Update()
    {
        // && gameObject.name == npcInteract.npcName if we want to check for a name
        if (npcInteract.inRange)
        {
            buttonDisplay.SetActive(true);
        }

        else if (!npcInteract.inRange)
        {
            buttonDisplay.SetActive(false);
            dialogueManager.EndDialogue();
        }

        //DialogueInteract(); 
    }
}
