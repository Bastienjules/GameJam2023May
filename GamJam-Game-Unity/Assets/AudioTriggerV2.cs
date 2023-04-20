using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayOrStop
{
    play, stop, increase, decrease
}
public class AudioTriggerV2 : MonoBehaviour
{
    public PlayOrStop playOrStop;
    public string songToPlay;

    AudioManagerV2 audioManagerV2;
    bool enter;

    // Start is called before the first frame update
    void Start()
    {
        audioManagerV2 = FindObjectOfType<AudioManagerV2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enter == true)
        {
            switch (playOrStop)
            {
                case PlayOrStop.increase:
                    audioManagerV2.DefineAsound(songToPlay);
                    audioManagerV2.Increase();
                    break;

                case PlayOrStop.decrease:
                    audioManagerV2.Decrease();
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && enter == false)
        {
            enter = true;
            switch(playOrStop)
            {
                case PlayOrStop.play:
                    audioManagerV2.DefineAsound(songToPlay);
                    audioManagerV2.PlayAudio();
                    break;

                case PlayOrStop.stop:
                    audioManagerV2.StopAudio();
                    break;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        enter = false;
    }
}
