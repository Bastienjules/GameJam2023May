using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManagerV2 : MonoBehaviour
{
    public float increaseDicreaseSpeed = 0.001f;
    public Sounds[] sound;

    public AudioSource source;
    public string musicToPlayOnStart;

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

    public void Decrease()
    {
        source.volume = Mathf.Lerp(source.volume, 0, increaseDicreaseSpeed);
    }

    public void Increase()
    {
        source.Play();
        source.volume = Mathf.Lerp(source.volume, 1, increaseDicreaseSpeed);
    }

}
