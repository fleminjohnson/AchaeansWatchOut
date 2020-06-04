using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        GameObject[]  music = GameObject.FindGameObjectsWithTag("Manage");

        if (music.Length > 1)
        {
            Destroy(this.gameObject);

        }
            DontDestroyOnLoad(this.gameObject);

    }


}
