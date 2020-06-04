
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float movSpeed;
    [SerializeField]
    private GameObject button;
    public Touch touch;
    public Rigidbody2D rb;
    public int health;
    public float acceleration = 250;

    public GameObject[] hearts;

    private AudioSource audio_Source;
    float sound;
    int r;
    public GameObject pauseMenu;


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
    // Update is called once per frame
    public void FixedUpdate()
    {
        int i = 0;
        sound = ((transform.position.x)/5);
        audio_Source.panStereo = sound;

        //if (!SettingsParameter.firstTime)
        //{
            if (Input.GetKey(KeyCode.A))
            {
                Move(-acceleration);
            }

            if (Input.GetKey(KeyCode.D))
            {
                Move(acceleration);
            }
        //}


        if (button.activeInHierarchy)
        {
            while (i < Input.touchCount)
            {

                if (Input.GetTouch(i).position.x < (Screen.width / 2))
                {
                    Move(-acceleration);
                }

                if (Input.GetTouch(i).position.x > (Screen.width / 2))
                {
                    Move(acceleration);
                }
                i++;
            }
        }

    }

    public void Move(float force)
    {
        if (!pauseMenu.activeInHierarchy)
        {
            rb.AddForce(new Vector2(force, 0));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "Cannon")
        {
            int r = Random.Range(0, hearts.Length);
            for (int i = 0; i < hearts.Length; i++)
            {
                if (hearts[r].activeInHierarchy) break;
                if (++r >= hearts.Length) r = 0;
            }
            //hearts[r] may not necessarily be inactive if everything was inactive
            hearts[r].SetActive(false);

            audio_Source.Play();
        }
    }
}
