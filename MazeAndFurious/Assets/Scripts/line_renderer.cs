using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class line_renderer : MonoBehaviour
{
    public Transform kup;
    public LineRenderer lineRenderer;
    public int wayPoint = 1;
    public Vector3 gitZ = new Vector3(0, 0, 5);
    public Vector3 gitX = new Vector3(5, 0, 0);
    public int counterOfWP = 2;
    public int a = 0;

    List<LineRenderer> lines = new List<LineRenderer>();
    public LineRenderer linePrefab;
    public LineRenderer l;


    private void Start()
{
    

    DOTween.Init();
}

private void Update()
{
    lineRenderer.SetVertexCount(counterOfWP);


    if (Input.GetKeyDown(KeyCode.W))
    {
        l = Instantiate(linePrefab, transform);
            l.SetPosition(1, new Vector3(9, 1, 1));

        while (a <= wayPoint)
        {
            wayPoint++;
            lineRenderer.SetPosition(a+1,kup.position + gitZ);
            //lineRenderer.SetPosition(wayPoint, kup.position);
            a++;
            //counterOfWP++;
            if (Input.anyKeyDown)
            {
                print("girdim");
                counterOfWP++;
                break;
            }



        }

        //wayPoint++;
        Debug.Log(wayPoint);
        //lineRenderer.SetVertexCount(wayPoint+1);
        //lineRenderer.SetPosition(wayPoint+1, kup.position + gitZ);
        int int_git = (int)(gitZ.z);
        kup.DOMoveZ(int_git, 1);
        //Debug.Log(wayPoint);
    }

    if (Input.GetKeyDown(KeyCode.S))
    {

        while (a <= wayPoint)
        {
            wayPoint++;
            lineRenderer.SetPosition(a+1,kup.position - gitZ);
            //lineRenderer.SetPosition(wayPoint, kup.position);
            a++;
            //counterOfWP++;
            if (Input.anyKeyDown)
            {   
                counterOfWP++;
                break;
            }


        }

        //wayPoint++;
        //lineRenderer.SetVertexCount(wayPoint+1);
        //lineRenderer.SetPosition(wayPoint+1, kup.position + gitZ);
        int int_git = (int)(gitZ.z);
        kup.DOMoveZ(-int_git, 1);
    }

    if (Input.GetKeyDown(KeyCode.A))
    {
        while (a <= wayPoint)
        {
            wayPoint++;
            lineRenderer.SetPosition(a+1,kup.position - gitX);
            //lineRenderer.SetPosition(wayPoint, kup.position);
            a++;
            //counterOfWP++;
            if (Input.anyKeyDown)
            {
                counterOfWP++;
                break;
            }


        }


        //wayPoint++;
        //lineRenderer.SetVertexCount(wayPoint+1);
        //lineRenderer.SetPosition(wayPoint+1, kup.position + gitX);
        int int_git = (int)(gitX.x);
        kup.DOMoveX(-int_git, 1);
    }

    if (Input.GetKeyDown(KeyCode.D))
    {
        while (a <= wayPoint)
        {
            wayPoint++;
            lineRenderer.SetPosition(a+1, kup.position + gitX);

            a++;
            //counterOfWP++;
            if (Input.anyKeyDown)
            {
                counterOfWP++;
                break;
            }


        }

        //wayPoint++;
        //lineRenderer.SetVertexCount(wayPoint+1);
        //lineRenderer.SetPosition(wayPoint+1, kup.position + gitX);
        int int_git = (int)(gitX.x);
        kup.DOMoveX(int_git, 1);
    }

    lineRenderer.SetPosition(wayPoint, kup.position);
}























/* public LineRenderer linePrefab;
 public LineRenderer l1;
 public LineRenderer l2;
 public LineRenderer l3;
 public LineRenderer l4;

 public Material lineMaterial;

 List<LineRenderer> lines = new List<LineRenderer>();

 // Start is called before the first frame update
 void Start()
 {
     l1 = Instantiate(linePrefab, transform);
     l2 = Instantiate(linePrefab, transform);
     l3 = Instantiate(linePrefab, transform);
     l4 = Instantiate(linePrefab, transform);


     lines.Add(l1);
     lines.Add(l2);
     lines.Add(l3);
     lines.Add(l4);

     foreach (var line in lines)
     {
         line.material = lineMaterial;
         line.material.color = Color.red;
     }
 }

 // Update is called once per frame
 void Update()
 {
     for (int i = 0; i < lines.Count; i++)
     {
         var currentLine = lines[i];

         if(i < am)
     }
 }*/
}
