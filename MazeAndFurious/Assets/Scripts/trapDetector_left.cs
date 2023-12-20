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


public class trapDetector_left : MonoBehaviour
{
    private Transform key;
    public GameObject keyPrefab;
    private GameObject keyGO;
    public static int KeyColor = 0;
    private Vector3 keyPlace;
    private int height;
    private int width;

    private void Start()
    {
        width = (Screen.width / 2);
        height = (Screen.height / 2);
    }

    private void Update()
    {
        if(KeyColor == 1)
        {
            keyPrefab.SetActive(true);
            keyPrefab.transform.position = GameObject.Find("keyWay").transform.position;

            keyPrefab.transform.DOMove(GameObject.Find("key1").transform.position, 1).OnComplete(() => Destroy(GameObject.Find("keyprefab")));
            
            KeyColor = 0;
        }
    }

}
