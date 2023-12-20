using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class yourClass : MonoBehaviour
{
    public GameObject musicOFF;
    public GameObject musicON;

    private int musicCheck;
    private int musicVol;

    private string sceneName;

    private AudioSource menuBackground;
    private AudioSource shopBackground;
    private AudioSource failBackground;

    private bool backgroundBool = false;
    private bool failBool = false;

    private void Start()
    {
        
        //PlayerPrefs.SetInt("totalGem", 15000);
        //PlayerPrefs.SetInt("lastLevel", 1);
        //PlayerPrefs.SetInt("ekstra", 0);
        //PlayerPrefs.SetInt("totalKey", 799);


        backgroundBool = false;
        failBool = false;
        //PlayerPrefs.SetInt("lastLevel", 49);
        //PlayerPrefs.DeleteAll();

        menuBackground = GameObject.Find("backGround_Music").GetComponent<AudioSource>();
        shopBackground = GameObject.Find("settings_Music").GetComponent<AudioSource>();
        failBackground = GameObject.Find("fail_Music").GetComponent<AudioSource>();

        sceneName = SceneManager.GetActiveScene().name;
        musicCheck = PlayerPrefs.GetInt("music");

        if (musicCheck == 0)
        {
            musicOFF.SetActive(true);
            musicON.SetActive(false);

            GameObject.Find("backGround_Music").GetComponent<AudioSource>().mute = false;
            GameObject.Find("settings_Music").GetComponent<AudioSource>().mute = false;
            GameObject.Find("fail_Music").GetComponent<AudioSource>().mute = false;

        }


        else
        {
            musicOFF.SetActive(false);
            musicON.SetActive(true);

            GameObject.Find("backGround_Music").GetComponent<AudioSource>().mute = true;
            GameObject.Find("settings_Music").GetComponent<AudioSource>().mute = true;
            GameObject.Find("fail_Music").GetComponent<AudioSource>().mute = true;
        }

        if (sceneName == "Menu")
        {
            shopBackground.Stop();
            menuBackground.Play();
        }
        else if (sceneName == "New Scene")
        {
            shopBackground.Stop();
            menuBackground.Play();
        }
        else if (sceneName == "characterSelect")
        {
            menuBackground.Stop();
            shopBackground.Play();
        }
        else if (sceneName == "Tutorial")
        {
            menuBackground.Play();
        }
        else if (sceneName == "chestScene")
        {
            shopBackground.Stop();
            menuBackground.Play();
        }
        
    }
    private void Update()
    {
        if (sceneName == "New Scene" && PlayerPrefs.GetInt("music") == 0)
        {
            if (swipteInput.sure <= 0 && !backgroundBool)
            {
                menuBackground.GetComponent<AudioSource>().mute = true;
                failBackground.Play();
                failBackground.GetComponent<AudioSource>().mute = false;
                backgroundBool = true;
                failBool = false;
            }
            else if (swipteInput.sure > 0 && !failBool)
            {
                failBackground.Stop();
                failBackground.GetComponent<AudioSource>().mute = true;
                menuBackground.GetComponent<AudioSource>().mute = false;
                failBool = true;
                backgroundBool = false;
            }
        }
    }

    //muzik acılır.
    public void musicOn()
    {
        musicVol = 0;
        PlayerPrefs.SetInt("music", musicVol);

        GameObject.Find("backGround_Music").GetComponent<AudioSource>().mute = false;
        GameObject.Find("fail_Music").GetComponent<AudioSource>().mute = false;
        GameObject.Find("pause_Music").GetComponent<AudioSource>().mute = false;
        GameObject.Find("settings_Music").GetComponent<AudioSource>().mute = false;

        musicOFF.SetActive(true);
        musicON.SetActive(false);

        GameAnalytics.NewDesignEvent("pauseMusicOn");

        //AudioListener.pause = true;

    }

    //muzik kapanır
    public void musicOff()
    {
        musicVol = 1;
        PlayerPrefs.SetInt("music", musicVol);

        GameObject.Find("backGround_Music").GetComponent<AudioSource>().mute = true;
        GameObject.Find("fail_Music").GetComponent<AudioSource>().mute = true;
        GameObject.Find("pause_Music").GetComponent<AudioSource>().mute = true;
        GameObject.Find("settings_Music").GetComponent<AudioSource>().mute = true;

        musicOFF.SetActive(false);
        musicON.SetActive(true);

        GameAnalytics.NewDesignEvent("pauseMusicOff");

        //AudioListener.pause = false;

    }

    public void ChestScene()
    {
        SceneManager.LoadScene("chestScene");
    }
}