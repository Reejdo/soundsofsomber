using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroEventManager : MonoBehaviour
{
    public int currentEventNumber;

    //Which objects these are should be based off of the intro scene document
    public GameObject[] eventsToEnable;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextEvent()
    {
        currentEventNumber++;

        eventsToEnable[currentEventNumber - 1].SetActive(false);

        if (eventsToEnable[currentEventNumber].activeSelf)
        {
            eventsToEnable[currentEventNumber].SetActive(false); 
        }
        else
        {
            eventsToEnable[currentEventNumber].SetActive(true); 
        }
    }
}
