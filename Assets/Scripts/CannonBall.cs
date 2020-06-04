
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public Rigidbody2D rb;
    private float range = 0;
    private Transform target;
    private Transform carrier;
    public float offset = 0;
    private float sign;
    private int points = 0;
    private GameObject avtaar;
    private AudioSource blast;
    private BlastSound blast_Sound;
    public GameObject explosion;
    public static int particleInitializer = -1;


    void Awake()
    {
        target = GameObject.Find("Player").transform;
        avtaar = GameObject.Find("Player");
        blast_Sound = GameObject.Find("Floor").GetComponent<BlastSound>();
    }
    void Start()
    {

        if (transform.position.x < Screen.width/2)
        {
            sign = (Mathf.Abs(target.position.x - transform.position.x)) / (target.position.x - transform.position.x);
            range = (target.position.x - transform.position.x -(sign * offset)) / 0.020849496f;
            rb.AddForce(new Vector2(range, 200));
        }
    }
    
    void Update()
    {
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

            Destroy(gameObject);
            particleInitializer += 1;
        }

        if (other.tag == "Ground")
        {
            Instantiate(explosion, transform.position + (Vector3.down)/2, Quaternion.identity);
            blast_Sound.isHit = true;
            avtaar.GetComponent<GameManager>().points++;   
            Destroy(gameObject);
        }
    }
}
