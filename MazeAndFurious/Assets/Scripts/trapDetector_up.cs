﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

public class trapDetector_up : MonoBehaviour
{
    public Transform kayro;

    private void Start()
    {
        DOTween.Init();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (swipteInput.tuzakDirection == 1)
        {

        }

        if (swipteInput.tuzakDirection == 2)
        {

        }

        if (swipteInput.tuzakDirection == 3)
        {
            if (other.gameObject.tag == "Cube")
            {
                kayro.DOMoveZ(swipteInput.slowerZ_2 + 3, 0.25f);
                Debug.Log("im trapDetector_Up");

            }
        }

        if (swipteInput.tuzakDirection == 4)
        {
            
        }
    }
}
