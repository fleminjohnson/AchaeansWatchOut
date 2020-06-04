using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Restarting : MonoBehaviour
{
    public Text failText;
    public Toggle sfx;
    public Toggle music;
    public GameObject pauseMenu;

    void Start()
    {
        var escaped = GameObject.Find("Player").GetComponent<GameManager>().points;
        failText.text = "You had successfully escaped from " + escaped + " cannonballs";
    }
   
    public void Restart()
    {
        SettingsParameter.sfxMute = sfx.isOn;
        SettingsParameter.musicMute = music.isOn;
        CannonBall.particleInitializer = -1;
        SceneManager.LoadScene("Cannon Game");
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void BackButton()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void MainMenu()
    {
        SettingsParameter.sfxMute = sfx.isOn;
        SettingsParameter.musicMute = music.isOn;
        SceneManager.LoadScene("Main Menu");
    }
}
