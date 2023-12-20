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

public class trapDetector_upExit : MonoBehaviour
{
    public Transform kayro;

    void Start()
    {
        DOTween.Init();   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "zemin")
            Debug.Log("kup burda");
    }

    /*private void OnTriggerExit(Collider other)
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

                kayro.DOMoveZ(swipteInput.goWay, 0.19f);
                Debug.Log("im trapDetectorExit_up");
            }
        }

        if (swipteInput.tuzakDirection == 4)
        {
            
        }
    }*/
}
