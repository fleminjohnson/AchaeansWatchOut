using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightManager : MonoBehaviour
{
    int count = 0;
    public GameObject[] knightHealth;
    public GameObject Knight;
    public Sprite profilepic;
    public GameObject pauseMenu;
    public GameObject failMenu;
    public Text deadText;
    Text dead;
    GameManager gameManager;
    // Update is called once per frame
   
    void Awake()
    {
        gameManager = GameObject.Find("Player").GetComponent<GameManager>();
        dead = GetComponent<Text>();
    }
    void Update()
    {

        foreach (var k in knightHealth)
        {
            if (!k.activeInHierarchy)
            {
                count += 1;
            }
        }

        if (count == 3)
        {
            gameManager.deadCount++;
            if (gameManager.deadCount <= 2)
            {
                pauseMenu.SetActive(true);
            }
            if (gameManager.deadCount > 2)
            {
                Time.timeScale = 0f;
                failMenu.SetActive(true);
                AdManager.instance.ShowFullScreenAd();
            }
            GameObject.Find("notifyPic").GetComponent<Image>().sprite = profilepic;

            deadText.text = dead.text;
            deadText.color = dead.color;
            Knight.SetActive(false);
            Destroy(gameObject);
        }


        count = 0;
    }
}
