using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    public UnityEvent thisEvent;
    public bool isTriggerSwitch;
    private bool isInRange = false;
    [SerializeField]
    private GameObject interactButton;


    private void Start()
    {
        interactButton.SetActive(false); 
    }

    void ThisEvent()
    {
        thisEvent.Invoke(); 
    }

    public void OnInteractKey(InputAction.CallbackContext context)
    {
        if (context.performed && isInRange)
        {
            thisEvent.Invoke(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTriggerSwitch)
        {
            interactButton.SetActive(true);
        }


        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            if (isTriggerSwitch)
            {
                thisEvent.Invoke(); 
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            interactButton.SetActive(false);
        }
    }
}
