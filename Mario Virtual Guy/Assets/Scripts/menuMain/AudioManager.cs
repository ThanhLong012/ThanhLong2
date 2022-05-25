using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource myAudioSource;
    float musicVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        myAudioSource.volume = musicVolume;
    }
    public void Volume(float volume)
    {
        musicVolume = volume;
    }
}
