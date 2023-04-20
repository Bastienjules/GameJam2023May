using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManagerV2 : MonoBehaviour
{
    public float increaseDicreaseSpeed = 0.001f;
    public float transitionTime = 2;
    public Sounds[] sound;

    public AudioSource source;
    public string musicToPlayOnStart;
    public bool switchsong;

    void Awake()
    {
        DefineAsound(musicToPlayOnStart);
        source.playOnAwake = false;
    }

    private void Start()
    {
        PlayAudio();
    }

    public void PlayAudio()
    {
        source.pitch = 1;
        source.volume = 1;
        source.Play();
    }

    public void StopAudio()
    {
        source.Stop();
    }

    public void DefineAsound(string name)
    {
        Sounds s = Array.Find(sound, sound => sound.name == name);
        source.clip = s.clip;
    }

    public void Decrease(bool volume)
    {
        if(volume == true)
        {
            source.volume = Mathf.Lerp(source.volume, 0, increaseDicreaseSpeed);

            if (source.volume <= 0.1)
            {
                StopAudio();
                switchsong = true;
            }
        }


        else
        {
            source.pitch = Mathf.Lerp(source.pitch, 0, increaseDicreaseSpeed);

            if (source.pitch <= 0.1)
            {
                StopAudio();
                switchsong = true;
            }
        }
    }

}
