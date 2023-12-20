using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    //public GameObject StartButton;
    //public GameObject LevelsButton;
    public GameObject KayrosButton;
    //public GameObject LeaderBoardButton;

    public GameObject select1;
    public GameObject select2;

    public static int kayroSelecter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void openKayros()
    {
        KayrosButton.SetActive(true);
    }

    public void kayroSelect1()
    {
        select1.SetActive(true);
        select2.SetActive(false);
        kayroSelecter = 1;
        KayrosButton.SetActive(false);
    }

    public void kayroSelect2()
    {
        select2.SetActive(true);
        select1.SetActive(false);
        kayroSelecter = 2;
        KayrosButton.SetActive(false);
    }

    public void closeKayros()
    {
        KayrosButton.SetActive(false);
    }
}
