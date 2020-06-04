using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggling : MonoBehaviour
{
    public GameObject right;
    public GameObject left;
    bool something = true;
    private AudioSource audio_Source;
    // Start is called before the first frame update

    void Awake()
    {
        audio_Source = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (SettingsParameter.musicMute)
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
        SettingsParameter.musicMute = audio_Source.mute;
        if (!left.activeInHierarchy & something == true)
        {
            right.SetActive(true);
            something = false;
        }
    }

}
