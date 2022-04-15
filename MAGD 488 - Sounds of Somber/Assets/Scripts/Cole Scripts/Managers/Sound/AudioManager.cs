using UnityEngine.Audio; //Much audio stuff is in this namespace
using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public float soundEffectDefaultPitch = 0.3f;
    public float soundEffectPitchDeviation = 0.2f; 

    public Sound currentBackground;

    public GameObject currentTheme;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return; //Makes sure no other code is run before destroying gameObject
        }


        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }

        UpdateCurrentTheme();

    }


    public void Play(string name)
    {
        //This uses using.System
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!!");
        }
        else
        {
            float highPitch = soundEffectDefaultPitch + soundEffectPitchDeviation;
            float lowPitch = soundEffectDefaultPitch - soundEffectPitchDeviation;
            float newPitch = Random.Range(lowPitch, highPitch);

            s.source.pitch = newPitch; 
            s.source.Play();
        }
    }

    public void StopSound(string name)
    {
        //This uses using.System
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!!");
        }
        else if (s != null)
        {
            s.source.Stop();
        }
    }

    public void StopTheme()
    {
        currentBackground.source.Stop();
    }

    public void UpdateCurrentTheme()
    {
        currentBackground.source = currentTheme.GetComponent<AudioSource>();
        currentBackground.source.clip = currentBackground.clip;
        currentBackground.source.volume = currentBackground.volume;
        currentBackground.source.pitch = currentBackground.pitch;
        currentBackground.source.loop = currentBackground.loop;
        //currentBackground.source.playOnAwake = currentBackground.playOnAwake;

        currentBackground.source.Play(); 
        StartCoroutine(BackgroundFade(currentBackground.source, 2, 1)); 
    }

    public static IEnumerator BackgroundFade(AudioSource audioSource, float duration, float targetVolume)
    {

        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
