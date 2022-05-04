using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventionWall : MonoBehaviour
{
    public InteractDialogue myDialogue;
    public int numToDisable;
    public BoxCollider2D myBoxCollider, backCollider; 

    // Start is called before the first frame update
    void Start()
    {
        backCollider.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (myDialogue.dialogueCounter >= numToDisable)
        {
            myBoxCollider.enabled = false;
            backCollider.enabled = true; 
        }
        else
        {
            myBoxCollider.enabled = true;
            backCollider.enabled = false; 
        }
    }
}
