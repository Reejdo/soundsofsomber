using UnityEngine.Audio; //Much audio stuff is in this namespace
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

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

        currentBackground.source.Play();
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
            s.source.Play();
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
        currentBackground.source.playOnAwake = currentBackground.playOnAwake;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
