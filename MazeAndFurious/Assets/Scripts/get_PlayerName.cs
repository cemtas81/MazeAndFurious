using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class get_PlayerName : MonoBehaviour
{
    public string showName;
    public string PlayerName;

    public GameObject inputfield;

    public InputField input;

    private void Start()
    {
        
    }

    public void SaveAndNext()
    {        
        PlayerName = inputfield.GetComponent<Text>().text.ToString().ToUpper();
        PlayerPrefs.SetString("playerName", PlayerName);
        showName = PlayerPrefs.GetString("playerName");

        if (showName.Length <= 0)
            Debug.Log("plase enter name");
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
                
        Debug.Log(showName.Length);

    }
}
