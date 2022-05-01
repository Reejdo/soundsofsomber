using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    public UnityEvent thisEvent;
    public bool isTriggerSwitch;
    public bool isInRange = false;
    [SerializeField]
    private GameObject interactButton;
    public Sprite[] switchSprites;
    private SpriteRenderer mySpriteRender; 

    private void Start()
    {
        mySpriteRender = GetComponent<SpriteRenderer>(); 
        if (interactButton != null)
        {
            interactButton.SetActive(false);
        }

    }

    void ThisEvent()
    {
        if (mySpriteRender.sprite == switchSprites[0])
        {
            mySpriteRender.sprite = switchSprites[1]; 
        }
        else
        {
            mySpriteRender.sprite = switchSprites[0]; 
        }
        thisEvent.Invoke(); 
    }

    public void OnInteractKey(InputAction.CallbackContext context)
    {
        if (context.performed && isInRange)
        {
            ThisEvent();  
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("MainPlayer"))
        {
            isInRange = true;

            if (!isTriggerSwitch)
            {
                interactButton.SetActive(true);
            }
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
