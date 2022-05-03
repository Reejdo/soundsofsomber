using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
	public GameObject optionsMenu;

	void Start(){
		optionsMenu.SetActive(true);
		optionsMenu.SetActive(false);
	}

	public void SetFull(bool isFullScreen){
		Screen.fullScreen = isFullScreen;
	}
}
