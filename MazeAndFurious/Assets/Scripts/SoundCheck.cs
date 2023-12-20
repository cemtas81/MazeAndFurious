using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class SoundCheck : MonoBehaviour
{
    public GameObject soundClosePause;
    public GameObject soundOpenPause;

    //public GameObject soundCloseEnd;
    //public GameObject soundOpenEnd;

    public int soundCheck;
    public int soundVol;
    private void Start()
    {
        soundCheck = PlayerPrefs.GetInt("sound");
        if(soundCheck == 0)
        {
            soundOpenPause.SetActive(false);
            soundClosePause.SetActive(true);

            //AudioListener.pause = false;
        }
        else
        {
            soundClosePause.SetActive(false);
            soundOpenPause.SetActive(true);

            //AudioListener.pause = true;

        }


    }

    public void SoundOpen()
    {
        soundVol = 0;
        PlayerPrefs.SetInt("sound", soundVol);
        //AudioListener.pause = false;
        soundClosePause.SetActive(true);
        soundOpenPause.SetActive(false);
        GameAnalytics.NewDesignEvent("pauseSoundOn");


    }

    public void SoundClose()
    {
        soundVol = 1;
        PlayerPrefs.SetInt("sound", soundVol);
        //AudioListener.pause = true;
        soundClosePause.SetActive(false);
        soundOpenPause.SetActive(true);
        GameAnalytics.NewDesignEvent("pauseSoundOff");
    }
}
