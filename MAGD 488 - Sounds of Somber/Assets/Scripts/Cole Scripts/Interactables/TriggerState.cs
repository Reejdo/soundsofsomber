using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TriggerState : MonoBehaviour
{
    public UnityEvent thisEvent;

    void ThisEvent()
    {
        thisEvent.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided"); 
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Triggered Event"); 
            ThisEvent(); 
        }
    }

}
