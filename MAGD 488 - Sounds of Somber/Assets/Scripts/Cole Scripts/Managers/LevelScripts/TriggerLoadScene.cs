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
    [SerializeField]
    private bool loadToCutscene = false;
    [SerializeField]
    private int cutSceneNumber = 0;
    private DataManager myDataManager; 

    private void Awake()
    {
        myLoadScene = GetComponent<LoadScene>();
        myDataManager = GameObject.FindObjectOfType<DataManager>().GetComponent<DataManager>(); 
    }


    void CallLoadScene()
    {
        LoadScene.Invoke(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag) && !loadOnce)
        {
            if (!loadToCutscene)
            {
                myDataManager.LoadToCutscene(cutSceneNumber); 
            }
            loadOnce = true;
            CallLoadScene();
        }            
    }

}
