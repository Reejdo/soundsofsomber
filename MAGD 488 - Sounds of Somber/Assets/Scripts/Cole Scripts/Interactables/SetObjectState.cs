using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectState : MonoBehaviour
{
    public GameObject myGameObject; 

    public void SetState(bool state)
    {
        myGameObject.SetActive(state); 
    }
}
