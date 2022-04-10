using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{

    public void LoadMainMenu()
    {
        Debug.Log("Load Main Menu");
        SceneLoader.Load(SceneLoader.Scene.MainMenuOfficial);
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

    public void LoadChapterOne()
    {
        Debug.Log("Load Chapter One");
        SceneLoader.Load(SceneLoader.Scene.ChapterOne);
    }

    public void LoadChapterTwo()
    {
        Debug.Log("Load Chapter Two");
        SceneLoader.Load(SceneLoader.Scene.ChapterTwo);
    }

    public void OnButtonQuit()
    {
        Application.Quit();
    }
}
