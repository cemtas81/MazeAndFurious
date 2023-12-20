using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using DG.Tweening;
using GameAnalyticsSDK;

public class AdMobIntestitial : MonoBehaviour
{

    private InterstitialAd inter;

    private string idAndroid = "ca-app-pub-9585813676258300/5750648802";

    private string idIOS = "ca-app-pub-9585813676258300/7317853675";

    public int level;

    public void Start()
    {
        level = PlayerPrefs.GetInt("lastLevel");

        DOTween.Init();
        this.Request();
    }

    private void Request()
    {
#if UNITY_ANDROID
        string id = idAndroid;
#elif UNITY_IPHONE
        string id = idIOS;
#else
        string id = "unexpected_platform";
#endif

        this.inter = new InterstitialAd(id);
        // Called when an ad request has successfully loaded.
        this.inter.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.inter.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.inter.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.inter.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.inter.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        this.inter.OnAdClosed += InterstitialClosed;

        AdRequest request = new AdRequest.Builder().Build();

        this.inter.LoadAd(request);
    }

    private void InterstitialClosed(object sender, EventArgs e)
    {
        // Called when an ad request has successfully loaded.
        this.inter.OnAdLoaded -= HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.inter.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.inter.OnAdOpening -= HandleOnAdOpened;
        // Called when the ad is closed.
        this.inter.OnAdClosed -= HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.inter.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
        this.inter.OnAdClosed -= InterstitialClosed;
        this.Request();

        if(PlayerPrefs.GetInt("music") == 0)
            GameObject.Find("backGround_Music").GetComponent<AudioSource>().mute = false;

    }

    public void ShowAd()
    {
        if (PlayerPrefs.GetInt("music") == 0)
            GameObject.Find("backGround_Music").GetComponent<AudioSource>().mute = true;

        this.inter.Show();
    }

    public void CleanAd()
    {
        if (PlayerPrefs.GetInt("removeAd") == 0)
        { inter.Destroy(); }
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        GameAnalytics.NewAdEvent(GAAdAction.Show, GAAdType.Interstitial, "admob", "AdMobIntestitial");
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        GameAnalytics.NewAdEvent(GAAdAction.Clicked, GAAdType.Interstitial, "admob", "AdMobIntestitial");
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
}