using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataFileWrite : MonoBehaviour
{
    public string fileName = "/saveData.txt";
    public List<string> levelName, checkpointNumber;
    public string path;
    private string[] allLines;
    private DataManager myDataManager; 

    private void Awake()
    {
        myDataManager = GameObject.FindObjectOfType<DataManager>().GetComponent<DataManager>(); 
        if (myDataManager != null)
        {
            path = Application.persistentDataPath + "/" + fileName;
            WriteToFile();
        }
        else
        {
            Debug.Log("Data Manager cannot be found!"); 
        }
    }


    public void WriteToFile()
    {
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Save Data File:" + "\n");
            File.AppendAllText(path, myDataManager.lastLevelLoaded + "," + myDataManager.lastCheckpoint);
            ReadFromFile();

        }
        else
        {
            ReadFromFile();
            File.WriteAllLines(path, allLines);
        }

    }


    public void UpdateFile()
    {
        if (allLines.Length != 0)
        {
            allLines[1] = myDataManager.lastLevelLoaded + "," + myDataManager.lastCheckpoint;
            File.WriteAllLines(path, allLines);
        }
        else
        {
            Debug.Log("All Lines is empty!"); 
        }
    }


    public void ReadFromFile()
    {
        allLines = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, path));
        //Start at 1 to skip intro line
        for (int i = 1; i < allLines.Length; i++)
        {
            string[] thisString = allLines[i].Split(char.Parse(","));
            //Debug.Log(thisString[0] + " " + thisString[1]); 
            levelName.Add(thisString[0]);
            checkpointNumber.Add(thisString[1]);
        }

        //Update the Data Manager
        myDataManager.lastLevelLoaded = levelName[0];
        myDataManager.lastCheckpoint = int.Parse(checkpointNumber[0]); 
    }

    public void ResetFileToDefault()
    {
        allLines[1] = "HouseOne" + "," + 0; 
        File.WriteAllLines(path, allLines);
    }

}
