using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{

    public static AdManager instance;

    private string appID = "ca-app-pub-8509807543700886~9684676266";

    private BannerView bannerView;
    private string bannerID = "ca-app-pub-8509807543700886/5234295362";

    private InterstitialAd fullScreenAd;
    private string fullScreenAdID = "ca-app-pub-8509807543700886/4240777892";




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        RequestFullScreenAd();
    }


    public void RequestBanner()
    {
        bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Top);

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);

        bannerView.Show();
    }

    public void HideBanner()
    {
        bannerView.Hide();
    }

    public void RequestFullScreenAd()
    {
        fullScreenAd = new InterstitialAd(fullScreenAdID);

        AdRequest request = new AdRequest.Builder().Build();

        fullScreenAd.LoadAd(request);

    }

    public void ShowFullScreenAd()
    {
        if (fullScreenAd.IsLoaded())
        {
            fullScreenAd.Show();
            print("fullscreenAd showing");
        }
        else
        {
            Debug.Log("Full screen ad not loaded");
        }
    }
}

