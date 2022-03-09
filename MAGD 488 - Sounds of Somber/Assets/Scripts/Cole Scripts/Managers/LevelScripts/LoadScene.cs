using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    /*  Loading,
        Tutorial,
        HouseOne, 
        HouseTwo,
        LevelOne, 
        LevelTwo,*/

    public void LoadMainMenu()
    {
        Debug.Log("Load Main Menu");
        SceneLoader.Load(SceneLoader.Scene.MainMenuTesting);
    }

    public void StartGame()
    {
        Debug.Log("Load Start Game scene");
        SceneLoader.Load(SceneLoader.Scene.ColeTestTether);
    }

    public void LoadTutorial()
    {
        Debug.Log("Load Tutorial");
        SceneLoader.Load(SceneLoader.Scene.Tutorial);
    }

    public void LoadHouseOne()
    {
        Debug.Log("Load House One");
        SceneLoader.Load(SceneLoader.Scene.HouseOne);
    }

    public void LoadHouseTwo()
    {
        Debug.Log("Load House Two");
        SceneLoader.Load(SceneLoader.Scene.HouseTwo);
    }

    public void LoadLevelOne()
    {
        Debug.Log("Load Level One");
        SceneLoader.Load(SceneLoader.Scene.LevelOne);
    }

    public void LoadLevelTwo()
    {
        Debug.Log("Load Level Two");
        SceneLoader.Load(SceneLoader.Scene.LevelTwo);
    }

    public void OnButtonQuit()
    {
        Application.Quit();
    }
}
