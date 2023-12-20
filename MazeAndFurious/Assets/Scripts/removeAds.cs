/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class removeAds : MonoBehaviour
{
    public GameObject adRemoveGo;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("removeAd") == 1)
        {
            adRemoveGo.SetActive(false);
            adRemoveGo.GetComponent<AdMobBanner>().enabled = false;
        }
    }
}
*/