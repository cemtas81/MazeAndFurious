using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class mainMenu : MonoBehaviour
{
    public TouchScreenKeyboard keyboard;
    private String playername;

    public GameObject settingsPanel;

    public GameObject pauseText;

    public GameObject blackPanel;

    public GameObject karakter;


    public void NextSceneMenu()
    {
       
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("New Scene");
    }
    public void Tutorial()
    {
        //ana menuden start a basıldığında shopa yada oyuna gidilmesi için
        //0 shopa gitmesini sağlar.
        if (PlayerPrefs.GetInt("shop") == 0)
        {
            SceneManager.LoadScene("characterSelect");
        }
        else
        {
            //if (PlayerPrefs.GetInt("tutorial") == 0)
              //  SceneManager.LoadScene("Tutorial");
            //else
                SceneManager.LoadScene("New Scene");
        }
    }

    public void NextSceneSelectScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        //charSelect = 1 ise Menuden geçişi gösterir.
        PlayerPrefs.SetInt("charSelect", 1);

    }

    public void BackHome()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
        GameAnalytics.NewDesignEvent("pauseHome");
    }

    public void BackScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void openSettings()
    {
        blackPanel.SetActive(true);
        settingsPanel.SetActive(true);
        pauseText.SetActive(false);
        karakter.SetActive(false);
        GameAnalytics.NewDesignEvent("pauseSettings");
    }

    public void closeSettings()
    {
        blackPanel.SetActive(false);
        settingsPanel.SetActive(false);
        pauseText.SetActive(true);
        karakter.SetActive(true);
    }

    public void openInstagram()
    {
        Application.OpenURL("https://www.situla.com.tr/");
    }
}
