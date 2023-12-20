using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;
//using GameAnalyticsSDK;


public class Vibrations : MonoBehaviour
{
    private int vibCheck;
    private int vib;

    public GameObject vibrateOn;
    public GameObject vibrateOff;

    private void Start()
    {
        vib = PlayerPrefs.GetInt("vibrate");
        if(vib == 0)
        {
            vibrateOff.SetActive(false);
            vibrateOn.SetActive(true);
            MMVibrationManager.SetHapticsActive(true);
        }

        else
        {
            vibrateOff.SetActive(true);
            vibrateOn.SetActive(false);
            MMVibrationManager.SetHapticsActive(false);
        }

    }

    //titreşim kapanır
    public void vibrationOn()
    {
        vibCheck = 1;
        PlayerPrefs.SetInt("vibrate", vibCheck);

        vibrateOff.SetActive(true);
        vibrateOn.SetActive(false);

        MMVibrationManager.SetHapticsActive(false);

        //GameAnalytics.NewDesignEvent("pauseVibrateOff");
    }

    //titreşim açılır
    public void vibrationOff()
    {
        vibCheck = 0;
        PlayerPrefs.SetInt("vibrate", vibCheck);

        vibrateOff.SetActive(false);
        vibrateOn.SetActive(true);
        MMVibrationManager.SetHapticsActive(true);
        MMVibrationManager.Vibrate();

        //GameAnalytics.NewDesignEvent("pauseVibrateOn");
    }


}
