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
public class trapDetector_right : MonoBehaviour
{
    public GameObject adRemoveGo;

    void Awake()
    {
        if (PlayerPrefs.GetInt("removeAd") == 1)
        {
            adRemoveGo.SetActive(false);
            adRemoveGo.GetComponent<AdMobBanner>().enabled = false;
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("music") == 0)
        {
            GameObject.Find("satinalma_Music").GetComponent<AudioSource>().Play();
        }
    }
}
