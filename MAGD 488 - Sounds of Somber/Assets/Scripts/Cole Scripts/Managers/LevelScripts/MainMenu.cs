using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnButtonStartGame()
    {
        Debug.Log("Pressed " + gameObject.name + " button");
        SceneLoader.Load(SceneLoader.Scene.ColeTestTether);
    }

    public void OnButtonOptionsScene()
    {

    }

    public void OnButtonQuit()
    {
        Application.Quit(); 
    }

}
