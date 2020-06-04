using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSManager : MonoBehaviour
{
    public ParticleSystem[] smoke;
    bool u = true;
    private int count = 0;
    public float angler;

    void Update()
    {
        /*var x = smoke[1].shape.rotation;
        x.z = 45.0f;
        for(int i = 0 ; i < 8; i ++)
        {
            x = smoke[i].shape.rotation;
            x.z = 45.0f;
        }*/
        if (CannonBall.particleInitializer % 2 == 0 && u == true)
        {
            smoke[count].Play();
            u = false;
            count += 1;
            smoke[count].Play();
            count += 1;
        }

        if (CannonBall.particleInitializer % 2 == 1)
        {
            u = true;
        }
    }

    /*private Type myVar;

    // New way
    public static Type MyVar => myVar;

    // Old way
    public static Type MyVar
    {
        get { return myVar; }
    }*/
    
}
