using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicAudioSource;

    void Start()
    {
        // Bắt đầu phát nhạc nền 
        musicAudioSource.Play();
    }

}
