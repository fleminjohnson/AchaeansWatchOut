using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    public Toggle sfx;
    public Toggle music;
    public static int score;
    public TMP_Text High;
    void Awake()
    {
        if (SettingsParameter.sfxMute)
        {
            sfx.isOn = true;
        }
        else
        {
            sfx.isOn = false;
        }
        if (SettingsParameter.musicMute)
        {
            music.isOn = true;
        }
        else
        {
            music.isOn = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        High.text = PlayerPrefs.GetInt("HighScore", 1).ToString();
        AdManager.instance.RequestBanner();
    }
    public void Play()
    {
        SettingsParameter.musicMute = music.isOn;
        SettingsParameter.sfxMute = sfx.isOn;
        CannonBall.particleInitializer = -1;
        SceneManager.LoadScene("Cannon Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    void Update()
    {
        SettingsParameter.musicMute = music.isOn;
    }
 
}
