using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundStatus : MonoBehaviour
{
    public Toggle music;
    private AudioSource musicSound;
    // Start is called before the first frame update
    void Awake()
    {
        musicSound = GetComponent<AudioSource>();
        music.isOn = SettingsParameter.musicMute;
    }

    void Start()
    {
        if (music.isOn)
        {
            musicSound.mute = true;
        }

        else
        {
            musicSound.mute = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SettingsParameter.musicMute = music.isOn;
        
    }
}
