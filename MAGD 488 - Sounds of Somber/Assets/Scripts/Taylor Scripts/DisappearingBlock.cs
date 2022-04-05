using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingBlock : MonoBehaviour
{
    public int counter = 0;
    public int itemCount;
    public GameObject objectToDisable;
    public bool objectDisabled; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (counter >= itemCount)
        {
            objectDisabled = true;
            objectToDisable.SetActive(false);   
        } 
    }
}
