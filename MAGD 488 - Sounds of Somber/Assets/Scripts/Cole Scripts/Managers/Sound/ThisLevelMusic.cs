using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisLevelMusic : MonoBehaviour
{
    public AudioManager myAudioManager;
    public AudioSource thisLevelTheme;


    // Start is called before the first frame update
    
    void Start()
    {
        myAudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>(); 

        if (myAudioManager.currentBackground.name == "null")
        {
            SwitchAudioNull(); 
        }
        else if (myAudioManager.currentBackground.name != thisLevelTheme.clip.name && myAudioManager.currentBackground.name != null)
        {
            Debug.Log("Name:" + myAudioManager.currentBackground.name); 
            StartCoroutine(SwitchAudio());
            //aManager.UpdateCurrentTheme(); 
            //myAudioManager.currentBackground.source.Play();
            //Debug.Log("Playing new theme");
        }
    }


    void SwitchAudioNull()
    {
        Debug.Log("Switch Audio Null");
        AudioSource myCurrentTheme = myAudioManager.currentTheme.GetComponent<AudioSource>();
        myCurrentTheme.clip = thisLevelTheme.clip;
        myAudioManager.currentBackground.name = thisLevelTheme.clip.name;
        myAudioManager.currentBackground.loop = true;
        myAudioManager.FadeInFromSwitch();
    }

    IEnumerator SwitchAudio()
    {
        AudioSource myCurrentTheme = myAudioManager.currentTheme.GetComponent<AudioSource>(); 

        Debug.Log("Switch Audio"); 
        myAudioManager.StopTheme();
        while (myCurrentTheme.volume != 0)
        {
            Debug.Log("Waited"); 
            yield return new WaitForSeconds(1f); 
        }
        myCurrentTheme.clip = thisLevelTheme.clip;
        myAudioManager.currentBackground.name = thisLevelTheme.clip.name;
        myAudioManager.currentBackground.loop = true; 
        myAudioManager.FadeInFromSwitch(); 
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
