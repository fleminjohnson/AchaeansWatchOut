using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int deadCount = 0;
    [HideInInspector]
    public int points = 0;
    private GameObject escaped;
    [HideInInspector]
    public GameObject notifyFailed;
    [HideInInspector]
    public bool failed = false;

    void Start()
    { 
        Time.timeScale = 1f;
        escaped = GameObject.Find("Escaped");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(deadCount == 1)
        {
           GetComponent<Player>().acceleration = 200;
        }
        if(deadCount == 2)
        {
            GetComponent<Player>().acceleration = 150;
        }
        if(deadCount == 3)
        {
            GetComponent<Player>().acceleration = 0;
        }

        escaped.GetComponent<Text>().text = points.ToString();
        if(points > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", points);
        }
    }
}
