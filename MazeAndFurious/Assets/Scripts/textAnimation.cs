using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class textAnimation : MonoBehaviour
{
    public PathType pathsystem = PathType.CatmullRom;

    private Vector3[] timePathFast = new Vector3[5];
    private Vector3[] timePathSlow = new Vector3[4];

    public GameObject timeOBJ;
    private GameObject timePrefab;

    void Start()
    {
        DOTween.Init();
    }

    public void TimeAnimation(int score0, int score1)
    {
        //timePathFast[0] = GameObject.Find("timePath1").transform.position;
        timePathFast[0] = GameObject.Find("timePath2").transform.position;
        timePathFast[1] = GameObject.Find("timePath3").transform.position;
        timePathFast[2] = GameObject.Find("timePath4").transform.position;
        timePathFast[3] = GameObject.Find("timePath5").transform.position;
        timePathFast[4] = GameObject.Find("timePath6").transform.position;

        timePathSlow[0] = GameObject.Find("timePath6").transform.position;
        timePathSlow[1] = GameObject.Find("timePath5").transform.position;
        timePathSlow[2] = GameObject.Find("timePath4").transform.position;
        timePathSlow[3] = GameObject.Find("timePath3").transform.position;




        if ((score0 + score1) > 0)
        {
            timePrefab = Instantiate(timeOBJ, transform);
            timePrefab.transform.position = GameObject.Find("timePath6").transform.position;

            timePrefab.GetComponent<Text>().color = Color.green;
            timePrefab.GetComponent<Text>().text = "+" + (score0 + score1).ToString();
            timePrefab.GetComponent<Animator>().SetTrigger("bigText");
            timePrefab.transform.DOPath(timePathSlow, 0.75f, pathsystem).OnComplete(() => Destroy(GameObject.Find("TimeFallDown(Clone)")));

        }
        else if ((score0 + score1) < 0)
        {
            timePrefab = Instantiate(timeOBJ, transform);
            timePrefab.transform.position = GameObject.Find("timePath2").transform.position;

            timePrefab.GetComponent<Text>().color = Color.red;
            timePrefab.GetComponent<Text>().text = (score0 + score1).ToString();
            timePrefab.GetComponent<Animator>().SetTrigger("bigText");
            timePrefab.transform.DOPath(timePathFast, 0.75f, pathsystem).OnComplete(() => Destroy(GameObject.Find("TimeFallDown(Clone)")));
        }

        

        //timePathSlow[0] = GameObject.Find("timePath4").transform.position;
        //timePathSlow[1] = GameObject.Find("timePath5").transform.position;
        //timePathSlow[2] = GameObject.Find("timePath6").transform.position;

        //timeOBJ.transform.DOPath(timePathFast, 0.5f, pathsystem).OnStepComplete(() => timeOBJ.transform.DOPath(timePathSlow, 0.75f, pathsystem));

    }
}
