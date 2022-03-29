using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SaveData : MonoBehaviour
{
    [SerializeField]
    private string currentScene;
    [SerializeField]
    private int thisCheckPointNumber;
    //[SerializeField]
    //private GameObject buttonToDisplay;

    private DataManager myDataManager;
    private DataFileWrite myDataFile; 

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
        myDataManager = GameObject.FindObjectOfType<DataManager>().GetComponent<DataManager>();
        myDataFile = GameObject.FindObjectOfType<DataFileWrite>().GetComponent<DataFileWrite>(); 
        //buttonToDisplay.SetActive(false); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            myDataManager.SaveGame(currentScene, thisCheckPointNumber);
            myDataFile.UpdateFile(); 
            //buttonToDisplay.SetActive(true); 
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //buttonToDisplay.SetActive(false);
        }
    }
    */ 
}
