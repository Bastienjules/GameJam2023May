using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioTriggerType
{
    volume, pitch
}
public class AudioTriggerV2 : MonoBehaviour
{
    public AudioTriggerType audioTriggertype;
    public string songToPlay;
    AudioManagerV2 audioManagerV2;
    bool enter = false, switched = false, volume;

    // Start is called before the first frame update
    void Start()
    {
        switch(audioTriggertype)
        {
            case AudioTriggerType.volume:
                volume = true;
                break;

            case AudioTriggerType.pitch:
                volume = false;
                break;
        }
        audioManagerV2 = FindObjectOfType<AudioManagerV2>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            if(switched == false)
            {
                if (enter == true)
                {
                    audioManagerV2.Decrease(volume);

                    if (audioManagerV2.switchsong == true)
                    {
                        StartCoroutine(switchSongTIme());
                    }
                }
            }
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && enter == false)
        {
            enter = true;
           //StartCoroutine(switchSongTIme());
        }
    }
    IEnumerator switchSongTIme()
    {
        yield return new WaitForSeconds(audioManagerV2.transitionTime); 

        audioManagerV2.DefineAsound(songToPlay);
        audioManagerV2.PlayAudio();
        audioManagerV2.switchsong = false;
        enter = false;
        switched = true;

    }
}
