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

public class trapDetector : MonoBehaviour
{
    private Transform kayro;
    private float count = 10f;

    private Material mat;

    private int key;
    private int keyCount;
    private int countforKey;
    private int totalKey;

    public Text keyTime;


    public AudioClip kasacmaClip;
    private AudioSource kasacmaSource;

    private void Awake()
    {
        kasacmaSource = GameObject.Find("kazanma3").GetComponent<AudioSource>();
    }


    private void Start()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
            kasacmaSource.mute = true;

        keyCount = PlayerPrefs.GetInt("key");
        countforKey = PlayerPrefs.GetInt("keyCount");
        DOTween.Init();

        //kayro = GameObject.Find("karakter_anim (1)").transform;

    }

    public void Update()
    {
        count -= Time.deltaTime;

        if (keyTime != null)
            keyTime.text = count.ToString("0");

        if (count <= 0)
            Destroy(GameObject.Find("key(Clone)"));

        /*mat = GameObject.Find("circle").GetComponent<SpriteRenderer>().material;
        mat.SetFloat("_Arc1", count*36);
        mat.DOColor(Color.red, 30);*/
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "karakter_anim (1)")
        {
            kasacmaSource.PlayOneShot(kasacmaClip, 1);
            totalKey = PlayerPrefs.GetInt("totalKey");
            Destroy(GameObject.Find("key(Clone)"));
            Debug.Log("im trapDetector");
            totalKey += 1;
            key = keyCount + 1;
            countforKey += 1;
            PlayerPrefs.SetInt("totalKey", totalKey);
            PlayerPrefs.SetInt("key", key);
            PlayerPrefs.SetInt("keyCount", countforKey);
            Debug.Log("KEY: " + key);
            trapDetector_left.KeyColor = 1;
        }
    }
}
