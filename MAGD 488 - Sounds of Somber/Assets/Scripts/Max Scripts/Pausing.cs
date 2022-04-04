using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausing : MonoBehaviour
{
    public static bool paused = false;
   	public GameObject PauseUI; 
    public static Pausing instance;
    public bool canPause;
    MenuKeys action;


    private void Awake(){
    	action = new MenuKeys();

    }

    private void OnEnable(){
    	action.Enable();
    }

    private void OnDisable(){
    	action.Disable();
    }


    private void Start(){
    	//PauseUI = GameObject.Find("pausemenu");
    	action.Pause.PauseGame.performed += _ => DeterminePause();
        instance = this;
        canPause = true;
    }

    private void DeterminePause(){
    	if(paused)
    		ResumeGame();
    	else
    		PauseGame();
    }

    

    public void ResumeGame(){
    	PauseUI.SetActive(false);
    	Time.timeScale = 1f;
    	AudioListener.pause = false;
    	paused = false;
    }

    public void PauseGame(){
    	PauseUI.SetActive(true);
    	Time.timeScale = 0;
    	AudioListener.pause = true;
    	paused = true;
    }

    //for pause screen buttons
    public void LoadMenu(){
    	Time.timeScale = 1f;
    	SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame(){
    	Debug.Log("Quitting...");
    	Application.Quit();
    }

    public void noMorePause(){
        canPause = false;
    }
}
