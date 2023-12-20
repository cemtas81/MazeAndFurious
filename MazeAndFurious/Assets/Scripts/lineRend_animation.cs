using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineRend_animation : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private float counter;
    private float dist;

    public Transform origin;
    public Transform destination;

    public float lineDrawSpeed = 6f;

    


    // Start is called before the first frame update
    void Start()
    {
        
        lineRenderer = GetComponent<LineRenderer>();
        

        dist = Vector3.Distance(origin.position, destination.position);

    }

    // Update is called once per frame
    void Update()
    {
        
        origin = GameObject.FindWithTag("Cube").transform;
        destination = GameObject.FindWithTag("Sphere").transform;
        lineRenderer.SetPosition(0, origin.position);
        if (counter < dist)
        {
            counter += .1f / lineDrawSpeed;

            float x = Mathf.Lerp(0, dist, counter);

            Vector3 A = origin.position;
            Vector3 B = destination.position;

            Vector3 pointAlongLine =x * Vector3.Normalize(B - A) + A;

            lineRenderer.SetPosition(1, pointAlongLine);
        }
    }
}
