using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBackground : MonoBehaviour
{
   	public bool toggleOn = true;
    void Start()
    {
        if(toggleOn == false)
    		gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(toggleOn == true)
    		gameObject.SetActive(true);
    	else if(toggleOn == false)
    		gameObject.SetActive(false);
    }
}
