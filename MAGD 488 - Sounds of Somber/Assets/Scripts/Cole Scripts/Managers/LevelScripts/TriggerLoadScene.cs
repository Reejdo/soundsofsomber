using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class TriggerLoadScene : MonoBehaviour
{
    public UnityEvent LoadScene; 

    private LoadScene myLoadScene;
    private PlayerControl myPlayerControl; 

    [SerializeField]
    private string playerTag = "Player";
    private bool loadOnce = false;
    [SerializeField]
    private bool loadToCutscene = false, isTrigger = false;
    [SerializeField]
    private int cutSceneNumber = 0;
    private DataManager myDataManager;
    public GameObject roomFader; 

    private void Awake()
    {
        myLoadScene = GetComponent<LoadScene>();
        myDataManager = GameObject.FindObjectOfType<DataManager>().GetComponent<DataManager>();
        myPlayerControl = GameObject.FindObjectOfType<PlayerControl>().GetComponent<PlayerControl>(); 
    }


    void CallLoadScene()
    {
        LoadScene.Invoke(); 
    }

    public void LoadNextScene()
    {
        StartCoroutine(SceneLoading());
        Debug.Log("Load next scene"); 
    }

    IEnumerator SceneLoading()
    {
        myPlayerControl.canMove = false; 
        roomFader.SetActive(true);
        yield return new WaitForSeconds(1f); //room fader fades in 1 second
        CallLoadScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger"); 
        if (collision.gameObject.CompareTag(playerTag) && !loadOnce)
        {
            Debug.Log("player collide"); 
            if (isTrigger)
            {
                if (!loadToCutscene)
                {
                    myDataManager.LoadToCutscene(cutSceneNumber);
                }
                loadOnce = true;
                LoadNextScene(); 
            }

        }            
    }

}
