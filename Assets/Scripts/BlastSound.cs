using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastSound : MonoBehaviour
{
    public bool isHit = false;
    public float stereoRange = 0;
    private AudioSource audio_Source;

    void Awake()
    {
        audio_Source = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (SettingsParameter.sfxMute)
        {
            audio_Source.mute = true;
        }
        else
        {
            audio_Source.mute = false;
        }
    }

    void Update()
    {
        if (isHit)
        {
            audio_Source.Play();
            isHit = false;
        }
    }
}
