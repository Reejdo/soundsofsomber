using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    public UnityEvent thisEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
