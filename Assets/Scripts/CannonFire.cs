using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    public float timer, minTime, maxTime;
    public GameObject cannonBall;
    public bool reloaded = true;
    public AudioClip cannonSound;
    public AudioSource soundManager;
    float distancebetween;
    GameObject player;
    // Update is called once per frame

    void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Start()
    {
        soundManager.clip = cannonSound;
        if (SettingsParameter.sfxMute)
        {
            soundManager.mute = true;
        }
        else
        {
            soundManager.mute = false;
        }
    }
    void Update()
    {
        SettingsParameter.sfxMute = soundManager.mute;
        distancebetween = Mathf.Abs(transform.position.x - player.transform.position.x);
        if (distancebetween > 6) {
            if (reloaded)
            {
                StopCoroutine("Timer");
                Instantiate(cannonBall, transform.position, transform.rotation);
                soundManager.Play();
                timer = Random.Range(minTime, maxTime);
                reloaded = false;
            }
            else
            {
                StartCoroutine("Timer");
            }
        }

        
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timer);
        reloaded = true;
    }
}
