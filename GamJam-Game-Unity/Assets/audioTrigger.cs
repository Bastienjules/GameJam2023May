using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioTriggerType
{
    increase, decrease
}

public enum VolumeOrPitch
{
    volume, pitch
}
public class audioTrigger : MonoBehaviour
{
    public AudioTriggerType audioTriggerType;
    public VolumeOrPitch volumeOrPitch;

    AudioManager audioManager;
    public string audioname;
    bool enter = false, volume;
    // Start is called before the first frame update
    void Start()
    {
        switch(volumeOrPitch)
        {
            case VolumeOrPitch.volume:
                volume = true;
                break;

            case VolumeOrPitch.pitch:
                volume = false;
                break;
        }
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enter == true)
        {

            switch (audioTriggerType)
            {
                case AudioTriggerType.increase:

                    // audioManager.Increase(volume, audioname);
                    audioManager.Play(audioname);
                    break;

                case AudioTriggerType.decrease:
                    audioManager.Decrease( volume, audioname);
                    break;

            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && enter == false)
        {
            enter = true;
        }
    }
}
