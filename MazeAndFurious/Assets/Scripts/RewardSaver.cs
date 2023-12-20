using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

public class RewardSaver : MonoBehaviour
{
    public static int gem;

    public Text gemText;
    public Text pauseGemText;
    public Text endGemText;

    public int level;
    public int levelSave;
    public int gemCounter;

    private void Start()
    {
        levelSave = PlayerPrefs.GetInt("lastLevel");
    }

    private void Update()
    {
        //PlayerPrefs.SetInt("gem", gem);
        gemCounter = PlayerPrefs.GetInt("totalGem");
        if (gemText != null)
            gemText.text = gemCounter.ToString();

        if (pauseGemText != null)
            pauseGemText.text = gemCounter.ToString();
        if (endGemText != null)
            endGemText.text = gemCounter.ToString();
    }

    public void nextLevel()
    {
        SceneManager.LoadScene("New Scene");
        level = levelSave + 1;
        PlayerPrefs.SetInt("lastLevel", level);
        gemCounter += 25;
        PlayerPrefs.SetInt("gem", gemCounter);


    }
}
