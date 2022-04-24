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

    public void LoadHousePostTutorial()
    {
        Debug.Log("Load House Post Tutorial");
        SceneLoader.Load(SceneLoader.Scene.HousePostTutorial); 
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

    public void LoadCutScene()
    {
        Debug.Log("Load CutScene scene");
        SceneLoader.Load(SceneLoader.Scene.CutScene);
    }

    public void OnButtonQuit()
    {
        Application.Quit();
    }
}
