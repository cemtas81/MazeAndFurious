using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class levelSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;
    public float percentThreshold = 0.2f;
    public float easing = 0f;
    public int totalPages = 3;
    private int currentPage = 1;

    public GameObject nextSign;
    public GameObject backSign;
    public Text pageText;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.width + "+" + Screen.height);
        panelLocation = transform.position;
    }
    public void OnDrag(PointerEventData data)
    {
        float difference = data.pressPosition.x - data.position.x;
        transform.position = panelLocation - new Vector3(difference, 0, 0);
    }
    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if (Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;
            if (percentage > 0 && currentPage < totalPages)
            {
                currentPage++;
                newLocation += new Vector3(-Screen.width, 0, 0);
            }
            else if (percentage < 0 && currentPage > 1)
            {
                currentPage--;
                newLocation += new Vector3(Screen.width, 0, 0);
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        }
        else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }

        if(currentPage == 1)
        {
            backSign.SetActive(false);
            nextSign.SetActive(true);
            if (pageText != null)
                pageText.text = currentPage.ToString();
        }
        else if(currentPage == 2)
        {
            backSign.SetActive(true);
            nextSign.SetActive(true);
            if (pageText != null)
                pageText.text = currentPage.ToString();
        }
        else if(currentPage == 3)
        {
            backSign.SetActive(true);
            nextSign.SetActive(false);
            if (pageText != null)
                pageText.text = currentPage.ToString();
        }

    }
    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }

    
}