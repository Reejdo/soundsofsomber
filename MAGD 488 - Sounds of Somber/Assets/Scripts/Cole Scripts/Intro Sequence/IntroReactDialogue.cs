using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroReactDialogue : MonoBehaviour
{
    private IntroEventManager myEventManager; 
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
        myEventManager = GameObject.FindObjectOfType<IntroEventManager>().GetComponent<IntroEventManager>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag) && !startDialogue)
        {
            startDialogue = true;
            myReactDialogue.StartDialogue(lines);
            myEventManager.NextEvent(); 
        }
    }
}
