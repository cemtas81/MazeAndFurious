using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Coloring : MonoBehaviour
{
    private bool turn = true;
    private bool turnZemin = true;
    private bool turnSlow = true;

    private int zeminCounter;

    public Transform kayro;
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "zemin")
        {
            Debug.Log("*****IM IN*****");
            Texture texture = Resources.Load("Textures/deneme") as Texture;
            other.gameObject.GetComponent<Renderer>().material.mainTexture = texture;
        }
    }*/
    private void Start()
    {
        DOTween.Init();
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "zemin")
        {
            if (swipteInput.ifcase == 1)
            {
                Debug.Log("****im in RIGHT*****");
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 90, 0), 0.5f);
            }
            else if (swipteInput.ifcase == 2)
            {
                Debug.Log("****im in LEFT*****");
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 0), 0.5f);
            }

            else if (swipteInput.ifcase == 3)
            {
                Debug.Log("****im in UP*****");
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(90, 0, 0), 0.5f);
            }

            else if (swipteInput.ifcase == 4)
            {
                Debug.Log("****im in DOWN*****");
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-90, 0, 0), 0.5f);
                zeminCounter++;
                Debug.Log(zeminCounter);
            }

        }
        else if (collision.gameObject.tag == "slow")
        {
            if (swipteInput.ifcase == 1)
            {
                Debug.Log("****im in RIGHT*****");
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 90, 0), 0.5f);
            }
            else if (swipteInput.ifcase == 2)
            {
                Debug.Log("****im in LEFT*****");
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 0), 0.5f);
            }

            else if (swipteInput.ifcase == 3)
            {
                Debug.Log("****im in UP*****");
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(90, 0, 0), 0.5f);
            }

            else if (swipteInput.ifcase == 4)
            {
                Debug.Log("****im in DOWN*****");
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-90, 0, 0), 0.5f);
            }
        }

        else if (collision.gameObject.tag == "slow2")
        {
            if (swipteInput.ifcase == 1)
            {
                Debug.Log("****im in RIGHT*****");
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 90, 0), 0.5f);
            }
            else if (swipteInput.ifcase == 2)
            {
                Debug.Log("****im in LEFT*****");
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 0), 0.5f);
            }

            else if (swipteInput.ifcase == 3)
            {
                Debug.Log("****im in UP*****");
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(90, 0, 0), 0.5f);
            }

            else if (swipteInput.ifcase == 4)
            {
                Debug.Log("****im in DOWN*****");
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-90, 0, 0), 0.5f);
            }
        }

        else if (collision.gameObject.tag == "tuzak")
        {
            if (swipteInput.ifcase == 1)
            {
                Debug.Log("****im in RIGHT*****");
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0).OnComplete(() => turnZemin = false);
            }
            else if (swipteInput.ifcase == 2)
            {
                Debug.Log("****im in LEFT*****");
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0).OnComplete(() => turnZemin = false);
            }

            else if (swipteInput.ifcase == 3)
            {
                Debug.Log("****im in UP*****");
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0).OnComplete(() => turnZemin = false);
            }

            else if (swipteInput.ifcase == 4)
            {
                Debug.Log("****im in DOWN*****");
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0).OnComplete(() => turnZemin = false);
            }


        }

        else if (collision.gameObject.tag == "slower" && turn == true)
        {
            if (swipteInput.ifcase == 3)
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0).OnComplete(() => kayro.DOMoveZ(swipteInput.slower, 0)).OnComplete(() => kayro.DOMoveZ(swipteInput.goWay, 0.5f));
            else if (swipteInput.ifcase == 4)
                collision.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0).OnComplete(() => kayro.DOMoveZ(swipteInput.slower, 0)).OnComplete(() => kayro.DOMoveZ(swipteInput.goWay, 0.5f));
        }

        if (turnZemin == false && collision.gameObject.tag == "tuzak")
            swipteInput.sure -= 2;


    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "zemin")
        {
            if (swipteInput.ifcase == 1)
            {
                Debug.Log("****im in RIGHT*****");
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);
            }
            else if (swipteInput.ifcase == 2)
            {
                Debug.Log("****im in LEFT*****");
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);
            }

            else if (swipteInput.ifcase == 3)
            {
                Debug.Log("****im in UP*****");
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
            }

            else if (swipteInput.ifcase == 4)
            {
                Debug.Log("****im in DOWN*****");
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);
                zeminCounter++;
                Debug.Log(zeminCounter);
            }

        }
        else if (other.gameObject.tag == "slow")
        {
            if (swipteInput.ifcase == 1)
            {
                Debug.Log("****im in RIGHT*****");
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 90, 0), 0.5f);
            }
            else if (swipteInput.ifcase == 2)
            {
                Debug.Log("****im in LEFT*****");
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 0), 0.5f);
            }

            else if (swipteInput.ifcase == 3)
            {
                Debug.Log("****im in UP*****");
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(90, 0, 0), 0.5f);
            }

            else if (swipteInput.ifcase == 4)
            {
                Debug.Log("****im in DOWN*****");
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-90, 0, 0), 0.5f);
            }
        }

        else if (other.gameObject.tag == "slow2")
        {
            if (swipteInput.ifcase == 1)
            {
                Debug.Log("****im in RIGHT*****");
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(0, 90, 0), 0.5f);
            }
            else if (swipteInput.ifcase == 2)
            {
                Debug.Log("****im in LEFT*****");
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 0), 0.5f);
            }

            else if (swipteInput.ifcase == 3)
            {
                Debug.Log("****im in UP*****");
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(90, 0, 0), 0.5f);
            }

            else if (swipteInput.ifcase == 4)
            {
                Debug.Log("****im in DOWN*****");
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-90, 0, 0), 0.5f);
            }
        }

        else if (other.gameObject.tag == "tuzak")
        {
            if (swipteInput.ifcase == 1)
            {
                Debug.Log("****im in RIGHT*****");
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0).OnComplete(() => turnZemin = false);
            }
            else if (swipteInput.ifcase == 2)
            {
                Debug.Log("****im in LEFT*****");
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0).OnComplete(() => turnZemin = false);
            }

            else if (swipteInput.ifcase == 3)
            {
                Debug.Log("****im in UP*****");
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0).OnComplete(() => turnZemin = false);
            }

            else if (swipteInput.ifcase == 4)
            {
                Debug.Log("****im in DOWN*****");
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0).OnComplete(() => turnZemin = false);
            }

            
        }

        else if (other.gameObject.tag == "slower" && turn == true)
        {
            if (swipteInput.ifcase == 3)
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0).OnComplete(() => kayro.DOMoveZ(swipteInput.slower, 0)).OnComplete(() => kayro.DOMoveZ(swipteInput.goWay, 0.5f));
            else if (swipteInput.ifcase == 4)
                other.gameObject.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0).OnComplete(() => kayro.DOMoveZ(swipteInput.slower, 0)).OnComplete(() => kayro.DOMoveZ(swipteInput.goWay, 0.5f));
        }

        if (turnZemin == false && other.gameObject.tag == "tuzak")
            swipteInput.sure -= 2;

                   
    }
}
