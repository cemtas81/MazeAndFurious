using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPusher : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public GameObject agac;
    public GameObject agac2;
    public GameObject cimen;
    public GameObject kaya;
    public GameObject anahtar;
    
    // Update is called once per frame
    void Update()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {

            if (Input.GetKeyDown(KeyCode.Z))
            {
                GameObject obj = Instantiate(agac, transform);
                obj.transform.position = new Vector3(Mathf.RoundToInt(hit.point.x), 3.91f, Mathf.RoundToInt(hit.point.z));
                Debug.Log("agac ekleniyor");
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                GameObject obj = Instantiate(agac2, transform);
                obj.transform.position = new Vector3(Mathf.RoundToInt(hit.point.x), 3.7f, Mathf.RoundToInt(hit.point.z));
                Debug.Log("agac ekleniyor");
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                GameObject obj = Instantiate(cimen, transform);
                obj.transform.position = new Vector3(Mathf.RoundToInt(hit.point.x), 1.5f, Mathf.RoundToInt(hit.point.z));
                Debug.Log("agac ekleniyor");
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                GameObject obj = Instantiate(kaya, transform);
                obj.transform.position = new Vector3(Mathf.RoundToInt(hit.point.x), 0.75f, Mathf.RoundToInt(hit.point.z));
                Debug.Log("agac ekleniyor");
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                GameObject obj = Instantiate(anahtar, transform);
                obj.transform.position = new Vector3(Mathf.RoundToInt(hit.point.x), 1, Mathf.RoundToInt(hit.point.z));
                Debug.Log("agac ekleniyor");
            }

        }
    }
}
