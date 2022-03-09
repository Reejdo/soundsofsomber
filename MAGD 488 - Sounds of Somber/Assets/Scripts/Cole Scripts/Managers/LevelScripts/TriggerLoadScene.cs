using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class TriggerLoadScene : MonoBehaviour
{
    public UnityEvent LoadScene; 

    private LoadScene myLoadScene;
    [SerializeField]
    private string playerTag = "Player";
    private bool loadOnce = false; 

    private void Awake()
    {
        myLoadScene = GetComponent<LoadScene>(); 
    }


    void CallLoadScene()
    {
        LoadScene.Invoke(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag) && !loadOnce)
        {
            loadOnce = true;
            CallLoadScene(); 
        }            
    }

}
