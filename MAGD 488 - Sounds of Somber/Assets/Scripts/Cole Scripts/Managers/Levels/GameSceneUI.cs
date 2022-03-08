using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUI : MonoBehaviour
{
    public string sceneToLoad; 

    public void OnButtonLoadMainMenu()
    {
        Debug.Log("Pressed " + gameObject.name + " button");
        SceneLoader.Load(SceneLoader.Scene.MainMenuTesting); 
    }

}
