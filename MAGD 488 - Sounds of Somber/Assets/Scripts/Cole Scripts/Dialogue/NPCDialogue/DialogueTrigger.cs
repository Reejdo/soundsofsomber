using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public List<GameObject> UIElements;
    public TMP_Text dialogueText;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, UIElements, dialogueText);
    }

}
