using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNPCInteract : MonoBehaviour
{
    public bool inRange = false;
    public string npcTag;
    public string npcName; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(npcTag))
        {
            inRange = true;
            npcName = collision.gameObject.transform.parent.name; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(npcTag))
        {
            inRange = false;
            npcName = null; 
        }
    }
}
