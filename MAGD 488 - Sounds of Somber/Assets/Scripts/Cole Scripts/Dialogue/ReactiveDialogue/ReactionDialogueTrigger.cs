using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionDialogueTrigger : MonoBehaviour
{
    private string playerTag;
    private bool startDialogue = false;
    public List<string> lines; 
    [SerializeField]
    private ReactionDialogue myReactDialogue; 

    // Start is called before the first frame update
    void Start()
    {
        playerTag = "Player";
        myReactDialogue = GameObject.FindObjectOfType<ReactionDialogue>().GetComponent<ReactionDialogue>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag) && !startDialogue)
        {

            if (myReactDialogue.isTalking && !startDialogue)
            {
                startDialogue = true;
                myReactDialogue.QueueAnotherDialogue(lines); 
            }
            else
            {
                startDialogue = true;
                myReactDialogue.StartDialogue(lines);
            }

        }
    }
}
