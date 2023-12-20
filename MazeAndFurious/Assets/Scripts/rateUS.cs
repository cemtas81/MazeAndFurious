using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class rateUS : Singleton<rateUS>
{
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject star4;
    public GameObject star5;

    public GameObject later;
    public GameObject rateit;

    public GameObject rateusPanel;

    public GameObject blackPanel;
    public GameObject closeText;

    static public int star;
    public Text thanksText;

    public void click1()
    {
        star = 1;
        star1.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        star2.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        star3.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        star4.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        star5.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
    }

    public void click2()
    {
        star = 2;
        star1.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        star2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        star3.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        star4.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        star5.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
    }

    public void click3()
    {
        star = 3;
        star1.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        star2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        star3.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        star4.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        star5.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
    }

    public void click4()
    {
        star = 4;
        star1.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        star2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        star3.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        star4.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        star5.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
    }

    public void click5()
    {
        star = 5;
        star1.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        star2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        star3.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        star4.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        star5.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void rateMechanic()
    {
        if(star >= 1 && star <=3)
        {
            if (thanksText != null)
                thanksText.text = "Thanks For Rate Us!";
            closeText.SetActive(false);
            later.SetActive(false);
            rateit.SetActive(false);
            Invoke("closeRateUs", 0.75f);
            PlayerPrefs.SetInt("rateus", 1);
        }
        else if(star >= 4 && star <= 5)
        {
            PlayerPrefs.SetInt("rateus", 1);
#if UNITY_ANDROID

            Application.OpenURL("https://www.situla.com.tr/");
            closeRateUs();
            //Application.OpenURL("market://details?id=YOUR_APP_ID");
#elif UNITY_IPHONE
            closeRateUs();
       Application.OpenURL("https://www.situla.com.tr/");
     //Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_APP_ID");
#endif
        }
    }

    public void laterButton()
    {
        star = 0;
        Time.timeScale = 1;
        blackPanel.SetActive(false);
        rateusPanel.SetActive(false);
    }

    private void closeRateUs()
    {
        Time.timeScale = 1;
        blackPanel.SetActive(false);
        rateusPanel.SetActive(false);
    }
}
