using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroEventOnEnable : MonoBehaviour
{
    private IntroEventManager myEventManager;
    [SerializeField]
    private GameObject objectToTrack;

    private bool eventStart = false; 

    // Start is called before the first frame update

    private void Awake()
    {
        myEventManager = GameObject.FindObjectOfType<IntroEventManager>().GetComponent<IntroEventManager>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!objectToTrack.activeSelf && !eventStart)
        {
            eventStart = true;
            myEventManager.NextEvent();
            gameObject.SetActive(false); 
        }
    }
}
