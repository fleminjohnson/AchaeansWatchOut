using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperLink : MonoBehaviour
{
    public int number;
    string url;

    void Awake()
    {
        switch (number)
        {
            case 0: 
                url = "https://pixabay.com/users/graphicmama-team-2641041/?tab=about";
                break;
            case 1:
                url = "https://pixabay.com/users/openclipart-vectors-30363/?tab=about";
                break;
            case 2:
                url = "https://pixabay.com/users/skeeze-272447/?tab=about";
                break;
            case 3:
                url = "https://opengameart.org/users/yd";
                break;
            case 4:
                url = "https://www.instagram.com/rafaelkrux/";
                break;
            case 5:
                url = "https://assetstore.unity.com/publishers/19898";
                break;
            case 6:
                url = "https://www.instagram.com/making3magic3/";
                break;
            case 7:
                url = "https://acheanswatchout.wixsite.com/website";
                break;

        }
    }
    public void OpenUrl()
    {
        Application.OpenURL(url);
    }
}
