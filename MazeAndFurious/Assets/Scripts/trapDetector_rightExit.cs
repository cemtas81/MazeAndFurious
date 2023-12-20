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

public class trapDetector_rightExit : MonoBehaviour
{
    public Transform kayro;

    void Start()
    {
        DOTween.Init();
    }

    private void OnTriggerExit(Collider other)
    {
        if (swipteInput.tuzakDirection == 1)
        {
            if (other.gameObject.tag == "Cube")
            {
                kayro.DOMoveX(swipteInput.goWay, 0.27f);
            }
        }

        if (swipteInput.tuzakDirection == 2)
        {
        }

        if (swipteInput.tuzakDirection == 3)
        {
        }

        if (swipteInput.tuzakDirection == 4)
        {
        }
    }
}