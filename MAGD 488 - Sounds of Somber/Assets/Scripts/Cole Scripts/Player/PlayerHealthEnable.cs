using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthEnable : MonoBehaviour
{
    public GameObject healthUI; 

    // Start is called before the first frame update
    void Start()
    {
        healthUI.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealthBarState(bool state)
    {
        Debug.Log("called health bar state"); 
        healthUI.SetActive(state);
    }
}
