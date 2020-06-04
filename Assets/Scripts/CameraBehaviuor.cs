

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviuor : MonoBehaviour
{
    Camera a;
    float timePassed = 0;
    float timeToMove = 5;
    float initialPos = 5;
    float zoomedPos  = 1.07f;
    Vector3 locationA = new Vector3(0, 0, -10);
    Vector3 locationB = new Vector3(4.43f, -1.81f, -10f);
    bool finishedanimation;
    [SerializeField]
    private GameObject right;

    public GameObject[] assets;

    // Start is called before the first frame update
    void Start()
    {
         a = GetComponent<Camera>();
        if (SettingsParameter.firstTime)
        {
            a.orthographicSize = zoomedPos;
            transform.Translate(locationB);
        }
        else
        {
            for (int i = 1; i < assets.Length; i++)
            {
                assets[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!finishedanimation & SettingsParameter.firstTime)
        {
            if (locationA != locationB)
            {
                timePassed += Time.deltaTime;

                float normalizedTime = timePassed / timeToMove;
                transform.position = Vector3.Lerp(locationB, locationA, normalizedTime);
                a.orthographicSize = Mathf.Lerp(zoomedPos, initialPos, normalizedTime);
                if (transform.position == locationA & a.orthographicSize == initialPos)
                {
                    finishedanimation = true;
                    SettingsParameter.firstTime = false;
                    for(int i =0; i < assets.Length; i++)
                    {
                        assets[i].SetActive(true);
                    }

                }
            }
        }
    }

    public void Activator()
    {
        if (SettingsParameter.firstClicked)
        {
            right.SetActive(true);
            SettingsParameter.firstClicked = false;
        }
    }

}
