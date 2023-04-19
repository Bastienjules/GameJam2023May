using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds sounds;
    public float increaseDicreaseSpeed = 0.1f;
    public KeyCode playSound = KeyCode.Keypad1, stopSOund = KeyCode.Keypad2;
    AudioSource audiosource;

    int selectedSound;
    
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        selectedSound = 0;
        SelecteSound();
    }

    // Update is called once per frame
    void Update()
    {
        Play();
        Stop();
        IncreaseDecreasePitch();
    }

    void SelecteSound()
    {
        audiosource.clip = sounds.music[selectedSound];
    }

    void Play()
    {
        if (Input.GetKey(playSound))
        {
            audiosource.Play();
        }
    }

    void Stop()
    {
        if (Input.GetKey(stopSOund))
        {
            audiosource.Stop();
        }
    }

    void IncreaseDecreasePitch()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            audiosource.pitch = Mathf.Lerp(audiosource.pitch, 3, increaseDicreaseSpeed);
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            audiosource.pitch = Mathf.Lerp(audiosource.pitch, -3, increaseDicreaseSpeed);
        }
    }
}
