using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public string lastLevelLoaded;
    public int lastCheckpoint; 

    [SerializeField]
    private LoadScene myLoadScene;
    [SerializeField]
    private UnityEvent[] LoadScene;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return; //Makes sure no other code is run before destroying gameObject
        }


        DontDestroyOnLoad(gameObject);
    }

    void ContinueGame()
    {
        string[] sceneNames = System.Enum.GetNames(typeof(SceneLoader.Scene));
        for (int i = 0; i < sceneNames.Length; i++)
        {
            if (lastLevelLoaded == sceneNames[i])
            {
                LoadScene[i].Invoke(); 
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
