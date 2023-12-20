using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.IO;

public class kayro_pos : MonoBehaviour
{
    public static int sesDurum = 0;

    public int floor_X;
    public int floor_Z;

    public int floorCount;

    public GameObject[] floors;

    private void Awake()
    {
        
        if (sesDurum == 0)
            SoundOpen();
        else
            SoundClose();
    }
    
    private void Start()
    {
        if (floors == null)
            floors = GameObject.FindGameObjectsWithTag("zemin");

        floorCount = GameObject.FindGameObjectsWithTag("zemin").Length;

        //floor_X = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("zemin").transform.position.x);
        floor_Z = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("zemin").transform.position.z);

        floor_X = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("zemin").GetComponent<Transform>().position.x);
        

        if (sesDurum == 0)
            SoundOpen();
        else
            SoundClose();
    }

    public void SoundOpen()
    {
        sesDurum = 1;
        AudioListener.pause = false;
        Debug.Log(sesDurum);

        //GameObject.Find("soundClose").SetActive(true);
        //GameObject.Find("soundOpen").SetActive(false);

        //GameObject.FindGameObjectWithTag("close").SetActive(true);
        //GameObject.FindGameObjectWithTag("open").SetActive(false);
        //soundClose.SetActive(true);
        //soundOpen.SetActive(false);

    }

    public void SoundClose()
    {

        sesDurum = 0;
        AudioListener.pause = true;
        Debug.Log(sesDurum);

        //GameObject.Find("soundClose").SetActive(false);
        //GameObject.Find("soundOpen").SetActive(true);

        //GameObject.FindGameObjectWithTag("close").SetActive(false);
        //GameObject.FindGameObjectWithTag("open").SetActive(true);
        //soundClose.SetActive(false);
        //soundOpen.SetActive(true);
    }
}