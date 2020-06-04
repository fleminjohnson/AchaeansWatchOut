using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXStatus : MonoBehaviour
{
    public Toggle SFX;
    // Start is called before the first frame update
    void Awake()
    {
        SFX.isOn = SettingsParameter.sfxMute;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
