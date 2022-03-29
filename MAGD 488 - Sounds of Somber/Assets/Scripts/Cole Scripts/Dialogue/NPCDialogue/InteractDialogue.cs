using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractDialogue : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private DialogueTrigger[] dialogueTrigger;
    private PlayerNPCInteract npcInteract;
    private ReactionDialogue myReactionDialogue; 
    
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

        myReactionDialogue = GameObject.FindObjectOfType<ReactionDialogue>().GetComponent<ReactionDialogue>();

    }

    void DialogueInteract()
    {
        Debug.Log("Dialogue Interact Called"); 
        if (npcInteract.inRange && !dialogueManager.talking && gameObject.name == npcInteract.npcName)
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
        //We need to check if this is the NPC being talked to so 
        //multiple NPCs work
        if (context.performed && gameObject.name == npcInteract.npcName && !myReactionDialogue.isTalking)
        {
            if (isPressed == false)
            {
                isPressed = true;
                Debug.Log("pressed");
                DialogueInteract();
            }
        }

        if (context.canceled && gameObject.name == npcInteract.npcName)
        {
            isPressed = false; 
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (npcInteract.inRange && gameObject.name == npcInteract.npcName)
        {
            buttonDisplay.SetActive(true);
        }

        else if (!npcInteract.inRange)
        {
            buttonDisplay.SetActive(false);
            dialogueManager.EndDialogue();
        }

    }
}
