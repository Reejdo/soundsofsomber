using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    public DataManager myDataManager;
    private int cutSceneNumber;
    public GameObject[] myCutScenes; 

    // Start is called before the first frame update
    void Start()
    {
        myDataManager = GameObject.FindObjectOfType<DataManager>().GetComponent<DataManager>();
        cutSceneNumber = myDataManager.myCutSceneNumber;
        EnableCutScene(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void EnableCutScene()
    {
        for (int i = 0; i < myCutScenes.Length; i++)
        {
            if (i == cutSceneNumber)
            {
                myCutScenes[i].SetActive(true); 
            }
            else
            {
                myCutScenes[i].SetActive(false); 
            }
        }
    }
}
