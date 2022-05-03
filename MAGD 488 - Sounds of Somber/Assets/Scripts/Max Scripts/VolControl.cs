using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolControl : MonoBehaviour
{

	[SerializeField] Slider volumeSlider;

	void Awake(){
		if(!PlayerPrefs.HasKey("musicVolume")){
			PlayerPrefs.SetFloat("musicVolume", 1);
			Load();
		}
		else{
			Load();
		}
	}

	//public AudioMixer audioMix;
   	public void SetVol(){
   		AudioListener.volume = volumeSlider.value;
   		Save();
   	}

   	private void Load(){
   		volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
   	}

   	private void Save(){
   		PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
   	}
}
