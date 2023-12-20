using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class controller_List : MonoBehaviour
{
    Rect fpsRect;
    float fps;

    public Transform kup;
    Vector3[] positionArrayx = new Vector3[25];
    Vector3[] positionArrayz = new Vector3[25];
    bool[][] boolPosition = {};
    private int boolCounter;
    private int score;
    HashSet<Tuple<int, int>> visitedNodes;

    void Start()
    {
        Application.targetFrameRate = 300;
        fpsRect = new Rect(100, 100, 400, 100);
        StartCoroutine(RecalculateFPS());

        visitedNodes = new HashSet<Tuple<int, int>>();
        InvokeRepeating("Update", 0, 0.000015f);
    }

    // Start is called before the first frame update
    /* void Start()
     {
         for (int i = 1; i < 15; i++)
         {
             for(int j= 1;j<20;j++)
             {
                 positionArrayx[i] = new Vector3(i, 0.5f, 0);
                 positionArrayz[j] = new Vector3(0, 0.5f, j);
                 boolPosition[i][j] = false;

             }
         }
         DOTween.Init();
     }*/
    private void Update()
    {

        int xCoordinate = Mathf.FloorToInt(kup.position.x);
        int zCoordinate = Mathf.FloorToInt(kup.position.z);
        

        if (!visitedNodes.Contains(new Tuple<int, int>(xCoordinate, zCoordinate)))
        {
            visitedNodes.Add(new Tuple<int, int>(xCoordinate, zCoordinate));

            score++;
            print(score);
        }
        if (visitedNodes.Contains(new Tuple<int, int>(xCoordinate, zCoordinate)))
        {
            print("üstünden geçildi");
        }
        if (visitedNodes.Count == 131)
        {
            print("OYUN BİTTİ");
        }


    }
        /*for (int i = 1; i < 14; i++)
         {
             for (int j = 1; j < 19; j++)
             {
                 if(kup.position.x>=positionArrayx[i].x && kup.position.x < positionArrayx[i+1].x)
                     if (kup.position.z >= positionArrayz[j].z && kup.position.z < positionArrayz[j + 1].z)
                 {
                     //print("selam" + i +"  " + j );
                      //   print(swipteInput.score);
                         visitedNodes.Add(new Tuple<int, int>(i, j));

                     }
             }
         }

        for (int i = 1; i < 14; i++)
        {
            for (int j = 1; j < 19; j++)
            {
                print(visitedNodes);
                if (visitedNodes.Contains(new Tuple<int, int>((int)positionArrayx[i].x, (int)positionArrayz[j].z)))
                {
                    visitedNodes.Add(new Tuple<int, int>((int)positionArrayx[i].x, (int)positionArrayz[j].z));

                    score++;
                    print(score);
                }
            }
        }
        
       
    }*/

   
    private IEnumerator RecalculateFPS()
    {
        while (true)
        {
            fps = 1 / Time.deltaTime;
            yield return new WaitForSeconds(1);
            print(fps);
        }
    }
}

