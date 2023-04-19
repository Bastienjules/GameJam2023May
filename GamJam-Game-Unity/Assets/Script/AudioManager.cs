using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sound;
    public float increaseDicreaseSpeed = 0.1f;
    public string playOnAwake;
    
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sounds s in sound)
        {
          s.source =  gameObject.AddComponent<AudioSource>();
          s.source.clip = s.clip;
            s.source.pitch = 0;
            s.source.volume = 0;
            s.source.playOnAwake = false;
        }
    }

    private void Start()
    {
        Play(playOnAwake);
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void Play( string name)
    {
        Sounds s = Array.Find(sound, sound => sound.name == name);
        s.source.pitch = 1;
        s.source.volume = 1;
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sounds s = Array.Find(sound, sound => sound.name == name);
        s.source.pitch = 0;
        s.source.volume = 0;
        s.source.Stop();
    }
    
    public void Decrease(bool volume, string name)
    {
        Sounds s = Array.Find(sound, sound => sound.name == name);
        if(volume == true)
        {
            s.source.volume = Mathf.Lerp(s.source.volume, 0, increaseDicreaseSpeed);
        }

        else
        {
            s.source.pitch = Mathf.Lerp(s.source.pitch, 0, increaseDicreaseSpeed);
        }

        if(s.source.pitch < 0.09 || s.source.volume < 0.09)
        {
            s.source.pitch = 0;
            s.source.volume = 0;
            s.source.Stop();
        }
    }

    public void Increase(bool volume, string name)
    {
        Sounds s = Array.Find(sound, sound => sound.name == name);
        Play(name);
        
       /* if(volume == true)
        {
            s.source.pitch = 1;
            s.source.volume = Mathf.Lerp(s.source.volume, 1, increaseDicreaseSpeed);
        }

        else
        {
            s.source.volume = 1;
            s.source.pitch = Mathf.Lerp(s.source.pitch, 1, increaseDicreaseSpeed);
        }*/
    }
}
