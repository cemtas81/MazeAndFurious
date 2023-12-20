using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealtBarCutFallDown : MonoBehaviour
{
    private RectTransform rectTransform;
    private float fallDownTimer;
    private float fadeTimer;
    private Image image;
    private Vector3 scaleChange;


    private Color color;

    float fallSpeed;
    float fallSpeed1;
    float fallSpeed2;
    float fallSpeed3;

    private void Awake()
    {
        rectTransform = transform.GetComponent<RectTransform>();
        image = transform.GetComponent<Image>();
        color = image.color;
        fallDownTimer = 0;
        fadeTimer = 200f;

        scaleChange = new Vector3(0, -0.1f, 0);
    }

    private void Start()
    {


    }
    private void Update()
    {
        fallDownTimer -= Time.deltaTime;
        if (fallDownTimer < 0)
        {
            // text.SetActive(false);
           
            if (SceneManager.GetActiveScene().name == "Tutorial")
            {
                fallSpeed = 300f;
                fallSpeed1 = 60f;
                fallSpeed2 = 64f;
                fallSpeed3 = 42f;
            }
            else
            {
                fallSpeed = 120f;
                fallSpeed1 = 15f;
                fallSpeed2 = 17f;
                fallSpeed3 = 11f;
            }

            fadeTimer -= Time.deltaTime;
            float alphaFadeSpeed = 5f;



            if (fadeTimer > 199.9)
            {
                rectTransform.anchoredPosition += Vector2.left * fallSpeed1 * Time.deltaTime;
                rectTransform.anchoredPosition += Vector2.up * fallSpeed2 * Time.deltaTime;
               // rectTransform.Rotate(new Vector3(0, 0,0.2f)); transform.localScale = new Vector3(1.2f, 1.2f, 1);

            }

            if (fadeTimer < 199.9)
            {
                transform.localScale = new Vector3(1.5f,1.5f , 1);
                rectTransform.anchoredPosition += Vector2.left * fallSpeed3 * Time.deltaTime;
                rectTransform.anchoredPosition += Vector2.down * fallSpeed * Time.deltaTime ;
                rectTransform.Rotate(new Vector3(0, 0, 5));
            }
           
           


            if (fadeTimer < 199.3)
            {
                color.a -= alphaFadeSpeed * Time.deltaTime;
                image.color = color;
                if (color.a <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
