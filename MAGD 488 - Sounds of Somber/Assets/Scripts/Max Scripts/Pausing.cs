using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausing : MonoBehaviour
{
    public static bool paused = false;
   	public GameObject PauseUI; 
    public static Pausing instance;
    public bool canPause = true;
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
        //canPause = true;
    }

    private void DeterminePause(){
    	if(paused)
    		ResumeGame();
    	else
    		PauseGame();
    }

    

    public void ResumeGame(){
    	if(PauseUI != null){
    		PauseUI.SetActive(false);
    		//AudioListener.volume = 1;
    		Time.timeScale = 1f;
    		AudioListener.pause = false;
    		paused = false;
    	}
    	
    }

    public void PauseGame(){ //pauses the game
    	if(PauseUI != null){
    		PauseUI.SetActive(true);
    		//AudioListener.volume = 0;
    		Time.timeScale = 0f;
    		AudioListener.pause = true;
    		paused = true;
    	}
    	
    }

    //for pause screen buttons
    public void LoadMenu(){ //loads back to the main menu
    	Time.timeScale = 1f;
    	AudioListener.pause = false;
    	SceneManager.LoadScene("MainMenuOfficial");
    }

    public void QuitGame(){ //quits the game
    	Debug.Log("Quitting...");
    	Application.Quit();
    }



    public void noMorePause(){ //disabled pausing (if needed)
    	if(canPause)
        	canPause = false;
        else
        	canPause = true;
    }
}
