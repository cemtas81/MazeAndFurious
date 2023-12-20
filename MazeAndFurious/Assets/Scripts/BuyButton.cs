using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuyButton : MonoBehaviour
{
    public enum ItemType
    {
        Gold500,
        Gold750,
        Gold1000,
        NoAds
    }

    public ItemType itemtype;

    public Text priceText;

    private string defaultText;

    private IAPManager iapmanager;

    // Start is called before the first frame update
    void Start()
    {
        iapmanager = GameObject.Find("IAPManager").GetComponent<IAPManager>();
        defaultText = priceText.text;
        StartCoroutine(LoadPriceRoutine());
    }

    public void ClickBuy()
    {
        switch(itemtype)
        {
            case ItemType.Gold500:
                IAPManager.Instance.Buy500Gold();
                break;

            case ItemType.Gold750:
                IAPManager.Instance.Buy750Gold();
                break;

            case ItemType.Gold1000:
                IAPManager.Instance.Buy1000Gold();
                break;

            case ItemType.NoAds:
                IAPManager.Instance.BuyNoAds();
                break;
        }
    }

    private IEnumerator LoadPriceRoutine()
    {
        while (!IAPManager.Instance.IsInitialized())
            yield return null;

        string loadedPrice = "";

        switch(itemtype)
        {
            case ItemType.Gold500:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.GOLD_500);
                break;

            case ItemType.Gold750:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.GOLD_750);
                break;

            case ItemType.Gold1000:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.GOLD_1000);
                break;

            case ItemType.NoAds:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.REMOVE_ADS);
                break;

        }

        priceText.text = loadedPrice;
    }

    public void Go2Purchase()
    {
        SceneManager.LoadScene("PurchaseScreen");
        PlayerPrefs.SetInt("satinalma", 2);
        Time.timeScale = 1;
    }

    public void Go2Char()
    {
        if (PlayerPrefs.GetInt("satinalma") == 1)
            SceneManager.LoadScene("characterSelect");
        else
            SceneManager.LoadScene("New Scene");
    }
}