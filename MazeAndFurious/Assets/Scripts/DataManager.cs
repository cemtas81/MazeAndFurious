using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DataManager : Singleton<DataManager>
{
    public Text goldAmountText;

    public GameObject noAdsButton;

    private int goldAmount = 0;

    private bool noAds = false;

    private int totalGem;

    private void Awake()
    {
        noAds = false;
        if(PlayerPrefs.GetInt("music") == 0)
            GameObject.Find("satinalma_Music").GetComponent<AudioSource>().mute = false;
        else
            GameObject.Find("satinalma_Music").GetComponent<AudioSource>().mute = true;
    }

    public void Start()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");
        if (goldAmountText != null)
            goldAmountText.text = totalGem.ToString();
    }

    public void AddGold(int amount)
    {
        totalGem = PlayerPrefs.GetInt("totalGem");
        totalGem += amount;
        PlayerPrefs.SetInt("totalGem",totalGem);
        if(goldAmountText != null)
            goldAmountText.text = totalGem.ToString();
    }
    private void Update()
    {
        totalGem = PlayerPrefs.GetInt("totalGem");
        if (goldAmountText != null)
            goldAmountText.text = totalGem.ToString();
    }

    public void RemoveAds()
    {
        PlayerPrefs.SetInt("removeAd", 1);
        noAds = true;
        noAdsButton.SetActive(false);
    }
}
