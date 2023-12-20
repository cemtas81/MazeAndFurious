using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class popUp_buttons : MonoBehaviour
{
    Scene scene;
    private int levelIndex;

    public GameObject pausePopUp;

    public GameObject pausePU;

    public GameObject pauseOpen;

    public GameObject pauseClose;

    public GameObject shieldButton;

    public int level;

    public int levelSave;

    public GameObject blackPanel;

    public GameObject adRemover;

    public GameObject pauseAnim;
    public GameObject pausePos;

    private float screenHeight;
    private float screenWidth;
    private float screenSize;
    private Vector3 textpos;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        levelIndex = scene.buildIndex;
        levelSave = PlayerPrefs.GetInt("lastLevel");

        screenHeight = Screen.height;
        screenWidth = Screen.width;
        screenSize = (((screenHeight / screenWidth) * 200)) / 1.66f;

        textpos = pausePos.transform.position;
        
        pauseAnim.transform.position = textpos;
        pauseAnim.transform.DOScale(new Vector3(screenSize, screenSize, screenSize), 0);
    }

    public void LevelRestart()
    {
        
        SceneManager.LoadScene(levelIndex);
        swipteInput.toplamScore = 1;
        swipteInput.scoreConverter = 0;
        Time.timeScale = 1;
        //swipteInput.levelEnd = 0;
        GameAnalytics.NewDesignEvent("pauseRestart");
    }

    public void PausePopUpOpen()
    {
        pausePU.SetActive(true);
        //timeBool = false;
        //controlBool = false;
        //pauseClose.SetActive(true);
        pauseOpen.SetActive(false);
        adRemover.SetActive(false);
        Time.timeScale = 0;
        swipteInput.levelEnd = 2;
        blackPanel.SetActive(true);
        pauseAnim.SetActive(true);
        GameAnalytics.NewDesignEvent("pauseOn");

    }

    public void PausePopUpClose()
    {

        pausePU.SetActive(false);
        //timeBool = true;
        //controlBool = true;
        //pauseClose.SetActive(false);
        pauseOpen.SetActive(true);
        adRemover.SetActive(true);
        Time.timeScale = 1;
        swipteInput.levelEnd = 0;
        blackPanel.SetActive(false);
        pauseAnim.SetActive(false);
        GameAnalytics.NewDesignEvent("pauseOff");
        GameAnalytics.NewDesignEvent("pausePlay");
    }

    public void nextLevel()
	{
		
        level = levelSave + 1;
        PlayerPrefs.SetInt("lastLevel", level);
        GameAnalytics.NewDesignEvent("levelNext");
        
    }

    public void LoadNewScene()
    {
        PlayerPrefs.SetInt("tutorial", 1);
    }
}
