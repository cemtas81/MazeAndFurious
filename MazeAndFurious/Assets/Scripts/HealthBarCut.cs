using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
using TMPro;
public class HealthBarCut : MonoBehaviour
{
    public GameObject text;
    byte y = 0;


    public int ekcik=0;
    private const float BAR_WIDTH = 320f; 
    public Image barImage;
    private Image barsure;
    private HealthSystem healthSystem;
    float maxTime=7.5f;
    public GameObject bar;
    private Transform damagedBarTemplate;

    private void Awake()
    {
        //barImage = transform.Find("bar").GetComponent<Image>();
        damagedBarTemplate = transform.Find("demagedBar");
        text.SetActive(false);
        barsure = bar.GetComponent<Image>();

    }
    public void Start()
    {
        healthSystem = gameObject.AddComponent<HealthSystem>();
        healthSystem = new HealthSystem(60);
        SerHealth(healthSystem.GetHealthNormalized());
        healthSystem.OnDamaged += HealthSystem_OnDamaged;
        healthSystem.OnDamaged += HealthSystem_OnDamaged;
        healthSystem.OnHealed += HealthSystem_OnHealed;
    }
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    void FixedUpdate()
    {
        
            //timeLeft -= Time.deltaTime;
            //barsure.fillAmount -= 0.01f / maxTime;
    }
    public void eklecıkar(int x)
    {
        if(x>0)
        {
            healthSystem.Heal(x);
        }
        else if(x<0)
        {
            text.GetComponent<UnityEngine.UI.Text>().text = x.ToString() ;
            //text.GetComponent<TextMeshProUGUI>().text = x.ToString();
            healthSystem.Damage(-x);
        }
    }
    public void damage2()
         {
        eklecıkar(ekcik);
           }

    public void renk3()
    {
        y = 0;
        barImage.color = new Color32(0, 128, 0, 100);
    }
    public void damage()
    {
        int damagee =5;

        text.GetComponent<UnityEngine.UI.Text>().text = "-" + damagee;
        //text.GetComponent<TextMeshProUGUI>().text = "-" + damagee;
        healthSystem.Damage(damagee);
    }
    
    public void heal()
    {
        healthSystem.Heal(10);
    }
 

    private void HealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        SerHealth(healthSystem.GetHealthNormalized());
    }
    private void HealthSystem_OnDamaged(object sender,System.EventArgs e)
    {
        if (swipteInput.sure < 500)
        {
            text.SetActive(true);
            float beforeDamagedBarFillAmount = barImage.fillAmount;
            SerHealth(healthSystem.GetHealthNormalized());
            Transform damagedBar = Instantiate(damagedBarTemplate, transform);
            damagedBar.gameObject.SetActive(true);
            damagedBar.GetComponent<RectTransform>().transform.position = new Vector2(GameObject.Find("TextFallDown").transform.position.x, GameObject.Find("TextFallDown").transform.position.y);//-barImage.fillAmount * BAR_WIDTH, damagedBar.GetComponent<RectTransform>().anchoredPosition.y
            damagedBar.GetComponent<Image>().fillAmount = beforeDamagedBarFillAmount - barImage.fillAmount;

            damagedBar.gameObject.AddComponent<HealtBarCutFallDown>();
            text.SetActive(false);
        }
    }
    private void SerHealth(float healtNormalized)
    {
        barImage.fillAmount = healtNormalized;
    }



    public void bekle1()
    {
        y++;
        // barImage.color = new Color32(255,0,0,100);     
        barImage.color = new Color32(y, y, y, 100);
    }
    public void renk2()
    {
        y = 0;
        barImage.color = new Color32(0, 255, 0, 100);
    }

}
