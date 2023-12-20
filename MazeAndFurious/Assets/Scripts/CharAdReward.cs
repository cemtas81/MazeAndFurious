using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using System;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using GameAnalyticsSDK;

public class CharAdReward : MonoBehaviour
{
    private RewardBasedVideoAd rAd;

    private string idAndroid = "ca-app-pub-9585813676258300/4883262026";

    private string idIOS = "ca-app-pub-9585813676258300/8504627040";

    private int gemReward = 200;

    public Button rewardButton;
    public Button reward2Button;

    public static int odulAlindi = 0;

    public int gem;
    public int finalGem;
    private int selectReward = 2;

    [SerializeField]
    GameObject panel;
    Sequence gemAnimation;

    [SerializeField]
    GameObject prefab;

    [SerializeField]
    GameObject button;

    GameObject a;
    private int rewardType;

    private int ekSure = 30;
    private int ekGem = 150;

    private int anahtar;
    private int anahtarCounter;

    private int levelSave;
    private int level;

    string currentRewardedVideoPlacement = "CharAdReward";

    private swipteInput swipte;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "New Scene")
            swipte = GameObject.Find("karakter_anim (1)").GetComponent<swipteInput>();
    }

    void Start()
    {
        odulAlindi = 0;
        ekSure = 30;
        ekGem = 150;
        anahtar = 3;

        //rewardButton = GameObject.Find("Ads").GetComponent<Button>();

        levelSave = PlayerPrefs.GetInt("lastLevel");
        


        DOTween.Init();


        rewardButton.interactable = false;

        rAd = RewardBasedVideoAd.Instance;

        rAd.OnAdRewarded += VideoRewarded;
        rAd.OnAdClosed += VideoClosed;

        this.RequestAds();
    }

    private void FixedUpdate()
    {
        finalGem = PlayerPrefs.GetInt("totalGem");
    }

    private void RequestAds()
    {
#if UNITY_ANDROID
        string id = idAndroid;
#elif UNITY_IPHONE
       string id = idIOS;
#else
       string id = "unexpected_platform";
#endif

        // Called when an ad request has successfully loaded.
        this.rAd.OnAdLoaded += HandleRewardedAdLoaded;

        // Called when an ad is shown.
        this.rAd.OnAdOpening += HandleRewardedAdOpening;

        // Called when the user should be rewarded for interacting with the ad.
        this.rAd.OnAdRewarded += HandleUserEarnedReward;

        // Called when the ad is closed.
        this.rAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();

        this.rAd.LoadAd(request, id);

    }

    private void VideoRewarded(object sender, EventArgs e)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Reward();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (selectReward == 0)
            {
                RewardTime();
                swipte.PauseAd();
                odulAlindi = 0;
                selectReward = 2;
            }
            if (selectReward == 1)
            {
                RewardNext();
                selectReward = 2;
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            RewardKey();
        }
    }

    private void VideoClosed(object sender, EventArgs e)
    {

        // Called when an ad request has successfully loaded.
        this.rAd.OnAdLoaded -= HandleRewardedAdLoaded;

        // Called when an ad is shown.
        this.rAd.OnAdOpening -= HandleRewardedAdOpening;

        // Called when the user should be rewarded for interacting with the ad.
        this.rAd.OnAdRewarded -= HandleUserEarnedReward;

        // Called when the ad is closed.
        this.rAd.OnAdClosed -= HandleRewardedAdClosed;

        if (PlayerPrefs.GetInt("music") == 0)
        {
            musicON();
        }

        RequestAds();
    }

    public void ShowAds()
    {
        this.rAd.Show();
    }

    private void Reward() //totalGeme 15 ekler.
    {
        ekGem = 150;
        finalGem += ekGem;
        PlayerPrefs.SetInt("totalGem", finalGem);
        rewardButton.interactable = false;
        GameAnalytics.NewAdEvent(GAAdAction.Clicked, GAAdType.RewardedVideo, "admob", "gemButton");

    }

    private void RewardTime()//sureye 15sn ekler.
    {
        ekSure = 30;
        swipteInput.sure += ekSure;
        rewardButton.interactable = false;
        odulAlindi = 1;
        GameObject.Find("FailPanel").SetActive(false);
        GameObject.Find("blackEffect").SetActive(false);
        GameAnalytics.NewAdEvent(GAAdAction.Clicked, GAAdType.RewardedVideo, "admob", "sureButton");

    }

    private void RewardNext()//bir sonraki levela geçişi sağlar.
    {
        levelSave = PlayerPrefs.GetInt("lastLevel");
        level = levelSave + 1;
        PlayerPrefs.SetInt("lastLevel", level);
        if (PlayerPrefs.GetInt("removeAd") == 0)
        {
            GameObject.Find("AdMobRemove").GetComponent<AdMobBanner>().CleanBanner();
            GameObject.Find("AdMobRemove").GetComponent<AdMobIntestitial>().CleanAd();
        }
        SceneManager.LoadScene(2);
        GameAnalytics.NewAdEvent(GAAdAction.Clicked, GAAdType.RewardedVideo, "admob", "levelNextButton");

    }

    private void RewardKey()//3 anahtar verir.
    {
        PlayerPrefs.SetInt("key", 3);
        GameAnalytics.NewAdEvent(GAAdAction.Clicked, GAAdType.RewardedVideo, "admob", "keyButton");

    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (rAd.IsLoaded())
            {

                rewardButton.interactable = true;

            }
            else
            {
                rewardButton.interactable = false;
            }
        }

        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (rAd.IsLoaded())
            {

                rewardButton.interactable = true;

            }
            else
            {
                rewardButton.interactable = false;
            }
        }

        else
        {
            if (rAd.IsLoaded())
            {
                if (swipteInput.sure <= 0)
                {
                    rewardButton.interactable = true;
                    reward2Button.interactable = true;
                }
                else
                {
                    rewardButton.interactable = false;
                    reward2Button.interactable = false;
                }
            }
            else
            {
                rewardButton.interactable = false;
                reward2Button.interactable = false;
            }
        }
    }
    public void timeReward()// new scenedeki zaman alımını tetikler.
    {
        selectReward = 0;
        Debug.Log("time reward is here" + selectReward);
    }

    public void levelReward()// new scenedeki level geçişi tetikler.
    {
        selectReward = 1;
        Debug.Log("level reward is here " + selectReward);
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        // keep track of current rewarded video ad
        string currentRewardedVideoPlacement = "CharAdReward";
        // start timer for this ad identifier
        GameAnalytics.StartTimer(currentRewardedVideoPlacement);

        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    void OnApplicationPause(bool paused)
    {
        if (paused)
        {
            if (currentRewardedVideoPlacement != null)
            {
                GameAnalytics.PauseTimer(currentRewardedVideoPlacement);
            }
        }
        else
        {
            if (currentRewardedVideoPlacement != null)
            {
                GameAnalytics.ResumeTimer(currentRewardedVideoPlacement);
            }
        }
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {

        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        GameAnalytics.NewAdEvent(GAAdAction.RewardReceived, GAAdType.RewardedVideo, "admob", "CharAdReward");

        if (currentRewardedVideoPlacement != null)
        {
            long elapsedTime = GameAnalytics.StopTimer(currentRewardedVideoPlacement);
            // send ad event for tracking elapsedTime
            GameAnalytics.NewAdEvent(GAAdAction.Show, GAAdType.RewardedVideo, "admob", "CharAdReward", elapsedTime);
            currentRewardedVideoPlacement = null;
        }



        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }

    public void musicOFF()
    {
        if (SceneManager.GetActiveScene().name == "characterSelect")
        {
            GameObject.Find("settings_Music").GetComponent<AudioSource>().mute = true;
        }
        else if (SceneManager.GetActiveScene().name == "New Scene")
        {
            GameObject.Find("fail_Music").GetComponent<AudioSource>().mute = true;
        }
        else if (SceneManager.GetActiveScene().name == "chestScene")
        {
            GameObject.Find("satinalma_Music").GetComponent<AudioSource>().mute = true;
        }
    }

    public void musicON()
    {
        if (SceneManager.GetActiveScene().name == "characterSelect")
        {
            GameObject.Find("settings_Music").GetComponent<AudioSource>().mute = false;
        }
        else if (SceneManager.GetActiveScene().name == "New Scene")
        {
            GameObject.Find("fail_Music").GetComponent<AudioSource>().mute = false;
        }
        else if (SceneManager.GetActiveScene().name == "chestScene")
        {
            GameObject.Find("satinalma_Music").GetComponent<AudioSource>().mute = false;
        }
    }
}