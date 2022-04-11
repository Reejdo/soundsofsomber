using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    public UnityEvent thisEvent;

    void ThisEvent()
    {
        thisEvent.Invoke(); 
    }

    public void OnInteractKey(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            thisEvent.Invoke(); 
        }
    }
}
