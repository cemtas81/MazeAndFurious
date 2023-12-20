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

public class trapDetectorExit : MonoBehaviour
{
    public Transform kayro;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
    }
    //triggerExit olan floora yavaslatıcı görsel eklenecek.
    //triggerExit hızı normal kayro hızından daha hızlı

    private void OnTriggerExit(Collider other)
    {

        if (swipteInput.tuzakDirection == 1)
        {

        }

        if (swipteInput.tuzakDirection == 2)
        {

        }

        if (swipteInput.tuzakDirection == 3)
        {
            Debug.Log("yukarı exit");
        }

        if (swipteInput.tuzakDirection == 4)
        {
            if (other.gameObject.tag == "Cube")
            {

                kayro.DOMoveZ(swipteInput.goWay, 0.19f);
                Debug.Log("im trapDetectorExit");
            }
        }
    }

}

