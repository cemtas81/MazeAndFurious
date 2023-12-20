using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;


public class chestRoom : MonoBehaviour
{
    private int random;
    private int keyCount;
    private int key;
    private int totalGem;
    private int levelGem;

    public GameObject extraKeyButton;
    public GameObject backtogameButton;

    public Text keyCountText;
    public Text totalGemText;

    public Text reward1;
    public Text reward2;
    public Text reward3;
    public Text reward4;
    public Text reward5;
    public Text reward6;
    public Text reward7;
    public Text reward8;
    public Text reward9;

    public GameObject removeAd;

    private Animator animator;

    private bool chest1 = false;
    private bool chest2 = false;
    private bool chest3 = false;
    private bool chest4 = false;
    private bool chest5 = false;
    private bool chest6 = false;
    private bool chest7 = false;
    private bool chest8 = false;
    private bool chest9 = false;

    public GameObject d1;
    public GameObject d2;
    public GameObject d3;
    public GameObject d4;
    public GameObject d5;
    public GameObject d6;
    public GameObject d7;
    public GameObject d8;
    public GameObject d9;

    private GameObject d1Dup;
    private GameObject d2Dup;
    private GameObject d3Dup;
    private GameObject d4Dup;
    private GameObject d5Dup;
    private GameObject d6Dup;
    private GameObject d7Dup;
    private GameObject d8Dup;
    private GameObject d9Dup;

    private bool back2gameButton;
    private bool diamondAnimBool;

    public GameObject key1;
    public GameObject key2;
    public GameObject key3;

    public PathType pathsystem = PathType.CatmullRom;
    private Vector3[] gemPath = new Vector3[14];

    public AudioClip kasacmaClip;
    private AudioSource kasacmaSource;

    public AudioClip elmasClip;
    private AudioSource elmasSource;


    private void Awake()
    {
        kasacmaSource = GameObject.Find("kasaacma").GetComponent<AudioSource>();
        elmasSource = GameObject.Find("sayma").GetComponent<AudioSource>();

        /*if (PlayerPrefs.GetInt("removeAd") == 1)
        {
            removeAd.SetActive(false);
            removeAd.GetComponent<AdMobBanner>().enabled = false;
        }*/

        if (PlayerPrefs.GetInt("music") == 0)
            GameObject.Find("satinalma_Music").GetComponent<AudioSource>().Play();
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            kasacmaSource.mute = true;
            GameObject.Find("sayma").GetComponent<AudioSource>().mute = true;
        }

        //gemPath[0] = GameObject.Find("path1").transform.position;
        //gemPath[1] = GameObject.Find("path2").transform.position;
        gemPath[0] = GameObject.Find("path2").transform.position;
        gemPath[1] = GameObject.Find("path4").transform.position;
        gemPath[2] = GameObject.Find("path5").transform.position;
        gemPath[3] = GameObject.Find("path6").transform.position;
        gemPath[4] = GameObject.Find("path7").transform.position;
        gemPath[5] = GameObject.Find("path8").transform.position;
        gemPath[6] = GameObject.Find("path9").transform.position;
        gemPath[7] = GameObject.Find("path10").transform.position;
        gemPath[8] = GameObject.Find("path11").transform.position;
        gemPath[9] = GameObject.Find("path12").transform.position;
        gemPath[10] = GameObject.Find("path13").transform.position;
        gemPath[11] = GameObject.Find("path14").transform.position;
        gemPath[12] = GameObject.Find("path15").transform.position;
        gemPath[13] = GameObject.Find("elmasAnim").transform.position;

        back2gameButton = false;
        diamondAnimBool = false;

        chest1 = true;
        chest2 = true;
        chest3 = true;
        chest4 = true;
        chest5 = true;
        chest6 = true;
        chest7 = true;
        chest8 = true;
        chest9 = true;

        DOTween.Init();

        if (PlayerPrefs.GetInt("removeAd") == 1)
            removeAd.SetActive(false);

        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("key", 9);

        keyCount = 0;

        totalGem = PlayerPrefs.GetInt("totalGem");

        if (totalGemText != null)
            totalGemText.text = totalGem.ToString();

    }

    private void Update()
    {
        key = PlayerPrefs.GetInt("key");

        KeyColor();

        if (totalGemText != null)
            totalGemText.text = totalGem.ToString();

        if (keyCountText != null)
        {
            keyCountText.text = "keycount = " + keyCount.ToString();
        }
        random = Random.Range(0, 100);

        if (key == 0 && keyCount != 6)
        {
            extraKeyButton.SetActive(true);
            //backtogameButton.SetActive(true);
            if (!back2gameButton)
            {
                back2gameButton = true;
                Invoke("BackToGame", 2.7f);
            }
        }
        else if (key == 3)
        {
            extraKeyButton.SetActive(false);
            backtogameButton.SetActive(false);
        }

        else if (key == 0 && keyCount == 6)
        {
            extraKeyButton.SetActive(false);
            backtogameButton.SetActive(true);
        }

        else if(key == 0 && keyCount >6)
        {
            extraKeyButton.SetActive(false);
            //backtogameButton.SetActive(true);
            if (!back2gameButton)
            {
                Invoke("BackToGame", 2.7f);
            }
        }
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void BackToGame()
    {
        backtogameButton.SetActive(true);
    }

    public void GameLoad()
    {
        SceneManager.LoadScene("New Scene");
        PlayerPrefs.SetInt("keyCount", 0);
    }

    private void DiamondAnim()
    {
        
    }

    private void KeyColor()
    {
        if(key == 3)
        {
            key1.GetComponent<Image>().color = Color.white;
            key2.GetComponent<Image>().color = Color.white;
            key3.GetComponent<Image>().color = Color.white;
        }
        else if(key == 2)
        {
            key1.GetComponent<Image>().color = Color.black;
            key2.GetComponent<Image>().color = Color.white;
            key3.GetComponent<Image>().color = Color.white;
        }
        else if(key == 1)
        {
            key1.GetComponent<Image>().color = Color.black;
            key2.GetComponent<Image>().color = Color.black;
            key3.GetComponent<Image>().color = Color.white;
        }
        else
        {
            key1.GetComponent<Image>().color = Color.black;
            key2.GetComponent<Image>().color = Color.black;
            key3.GetComponent<Image>().color = Color.black;
        }
    }

    public void Click1()
    {
        if (key > 0 && chest1 == true)
        {
            animator = GameObject.Find("Chest").GetComponent<Animator>();
            animator.SetBool("chestBool", true);
            chest1 = false;
            key--;
            keyCount++;
            PlayerPrefs.SetInt("key", key);
            Invoke("DestroyChest1", 1.2f);
            Invoke("Click1Invoke", 1.21f);
            kasaAcmaSound();
        }
    }
   
    public void Click2()
    {
        if (key > 0 && chest2 == true)
        {
            animator = GameObject.Find("Chest2").GetComponent<Animator>();
            animator.SetBool("chestBool", true);
            chest2 = false;
            key--;
            keyCount++;
            PlayerPrefs.SetInt("key", key);
            Invoke("DestroyChest2", 1.2f);
            Invoke("Click2Invoke", 1.2f);
            kasaAcmaSound();
        }
    }

    public void Click3()
    {
        if (key > 0 && chest3 == true)
        {
            animator = GameObject.Find("Chest3").GetComponent<Animator>();
            animator.SetBool("chestBool", true);
            chest3 = false;
            key--;
            keyCount++;
            PlayerPrefs.SetInt("key", key);
            Invoke("DestroyChest3", 1.2f);
            Invoke("Click3Invoke", 1.2f);
            kasaAcmaSound();
        }
    }

    public void Click4()
    {
        if (key > 0 && chest4 == true)
        {
            animator = GameObject.Find("Chest4").GetComponent<Animator>();
            animator.SetBool("chestBool", true);
            chest4 = false;
            key--;
            keyCount++;
            PlayerPrefs.SetInt("key", key);
            Invoke("DestroyChest4", 1.2f);
            Invoke("Click4Invoke", 1.21f);
            kasaAcmaSound();
        }
    }

    public void Click5()
    {
        if (key > 0 && chest5 == true)
        {
            animator = GameObject.Find("Chest5").GetComponent<Animator>();
            animator.SetBool("chestBool", true);
            chest5 = false;
            key--;
            keyCount++;
            PlayerPrefs.SetInt("key", key);
            Invoke("DestroyChest5", 1.2f);
            Invoke("Click5Invoke", 1.21f);
            kasaAcmaSound();
        }
    }

    public void Click6()
    {
        if (key > 0 && chest6 == true)
        {
            animator = GameObject.Find("Chest6").GetComponent<Animator>();
            animator.SetBool("chestBool", true);
            chest6 = false;
            key--;
            keyCount++;
            PlayerPrefs.SetInt("key", key);
            Invoke("DestroyChest6", 1.2f);
            Invoke("Click6Invoke", 1.21f);
            kasaAcmaSound();
        }
    }

    public void Click7()
    {
        if (key > 0 && chest7 == true)
        {
            animator = GameObject.Find("Chest7").GetComponent<Animator>();
            animator.SetBool("chestBool", true);
            chest7 = false;
            key--;
            keyCount++;
            PlayerPrefs.SetInt("key", key);
            Invoke("DestroyChest7", 1.2f);
            Invoke("Click7Invoke", 1.21f);
            kasaAcmaSound();
        }
    }

    public void Click8()
    {
        if (key > 0 && chest8 == true)
        {
            animator = GameObject.Find("Chest8").GetComponent<Animator>();
            animator.SetBool("chestBool", true);
            chest8 = false;
            key--;
            keyCount++;
            PlayerPrefs.SetInt("key", key);
            Invoke("DestroyChest8", 1.2f);
            Invoke("Click8Invoke", 1.21f);
            kasaAcmaSound();
        }
    }

    public void Click9()
    {
        if (key > 0 && chest9 == true)
        {
            animator = GameObject.Find("Chest9").GetComponent<Animator>();
            animator.SetBool("chestBool", true);
            chest9 = false;
            key--;
            keyCount++;
            PlayerPrefs.SetInt("key", key);
            Invoke("DestroyChest9", 1.2f);
            Invoke("Click9Invoke", 1.21f);
            kasaAcmaSound();
        }
    }

    public void Click1Invoke()
    {
        d1.SetActive(true);
        GameObject.Find("D1").GetComponent<Animator>().SetTrigger("diamonTrigger");

        if (random > 0 && random <= 30)
        {
            Debug.Log("30 elmas kazandınız");

            if (reward1 != null)
                reward1.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 31 && random <= 50)
        {
            Debug.Log("40 elmas kazandınız");
            if (reward1 != null)
                reward1.text = "+40";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 40;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 51 && random <= 70)
        {
            Debug.Log("50 elmas kazandınız");
            if (reward1 != null)
                reward1.text = "+50";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 50;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 71 && random <= 74)
        {
            Debug.Log("250 elmas kazandınız");
            if (reward1 != null)
                reward1.text = "+250";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 250;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 81 && random <= 82)
        {
            Debug.Log("350 elmas kazandınız");
            if (reward1 != null)
                reward1.text = "+350";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 350;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random == 86)
        {
            Debug.Log("500 elmas kazandınız");
            if (reward1 != null)
                reward1.text = "+500";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 500;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else
        {
            Debug.Log("30 elmas kazandınız");

            if (reward1 != null)
                reward1.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);
        }

        GameObject dup1;
        GameObject dup2;
        GameObject dup3;
        GameObject dup4;
        GameObject dup5;

        d1Dup = Instantiate(d1,transform);
        dup1 = Instantiate(d1, transform);
        dup2 = Instantiate(d1, transform);
        dup3 = Instantiate(d1, transform);
        dup4 = Instantiate(d1, transform);
        dup5 = Instantiate(d1, transform);

        d1Dup.transform.position = d1.transform.position;
        dup1.transform.position = d1.transform.position;
        dup2.transform.position = d1.transform.position;
        dup3.transform.position = d1.transform.position;
        dup4.transform.position = d1.transform.position;
        dup5.transform.position = d1.transform.position;
        //d1Dup.transform.DOPath(gemPath, 2, pathsystem).OnPlay(() => d1Dup.transform.DOScale(new Vector3(1.65f, 1.65f, 1.65f),2));
        //d1Dup.transform.DOPath(gemPath, 1.5f, pathsystem).OnStepComplete(() => Destroy(d1Dup));
        d1Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => Destroy(d1Dup));
        d1Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => elmasSound());
        dup1.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.2f).OnStepComplete(() => Destroy(dup1));
        dup2.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.4f).OnStepComplete(() => Destroy(dup2));
        dup3.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.6f).OnStepComplete(() => Destroy(dup3));
        dup4.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.8f).OnStepComplete(() => Destroy(dup4));
        dup5.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 2).OnStepComplete(() => Destroy(dup5));

    }

    public void Click2Invoke()
    {
        d2.SetActive(true);
        GameObject.Find("D2").GetComponent<Animator>().SetTrigger("diamonTrigger");


        if (random > 0 && random <= 30)
        {
            Debug.Log("30 elmas kazandınız");

            if (reward2 != null)
                reward2.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 31 && random <= 50)
        {
            Debug.Log("40 elmas kazandınız");
            if (reward2 != null)
                reward2.text = "+40";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 40;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 51 && random <= 70)
        {
            Debug.Log("50 elmas kazandınız");
            if (reward2 != null)
                reward2.text = "+50";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 50;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 71 && random <= 74)
        {
            Debug.Log("250 elmas kazandınız");
            if (reward2 != null)
                reward2.text = "+250";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 250;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 81 && random <= 82)
        {
            Debug.Log("350 elmas kazandınız");
            if (reward2 != null)
                reward2.text = "+350";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 350;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random == 86)
        {
            Debug.Log("500 elmas kazandınız");
            if (reward2 != null)
                reward2.text = "+500";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 500;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else
        {
            Debug.Log("30 elmas kazandınız");

            if (reward2 != null)
                reward2.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);


        }

        GameObject dup1;
        GameObject dup2;
        GameObject dup3;
        GameObject dup4;
        GameObject dup5;

        d2Dup = Instantiate(d2, transform);
        dup1 = Instantiate(d2, transform);
        dup2 = Instantiate(d2, transform);
        dup3 = Instantiate(d2, transform);
        dup4 = Instantiate(d2, transform);
        dup5 = Instantiate(d2, transform);

        d2Dup.transform.position = d2.transform.position;
        dup1.transform.position = d2.transform.position;
        dup2.transform.position = d2.transform.position;
        dup3.transform.position = d2.transform.position;
        dup4.transform.position = d2.transform.position;
        dup5.transform.position = d2.transform.position;
        //d2Dup.transform.DOPath(gemPath, 2, pathsystem).OnPlay(() => d2Dup.transform.DOScale(new Vector3(1.65f, 1.65f, 1.65f), 2));
        //d2Dup.transform.DOPath(gemPath, 1.5f, pathsystem).OnStepComplete(() => Destroy(d2Dup));
        d2Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => Destroy(d2Dup));
        d2Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => elmasSound());
        dup1.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.2f).OnStepComplete(() => Destroy(dup1));
        dup2.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.4f).OnStepComplete(() => Destroy(dup2));
        dup3.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.6f).OnStepComplete(() => Destroy(dup3));
        dup4.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.8f).OnStepComplete(() => Destroy(dup4));
        dup5.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 2).OnStepComplete(() => Destroy(dup5));

    }

    public void Click3Invoke()
    {
        d3.SetActive(true);
        GameObject.Find("D3").GetComponent<Animator>().SetTrigger("diamonTrigger");

        if (random > 0 && random <= 30)
        {
            Debug.Log("30 elmas kazandınız");

            if (reward3 != null)
                reward3.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 31 && random <= 50)
        {
            Debug.Log("40 elmas kazandınız");
            if (reward3 != null)
                reward3.text = "+40";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 40;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 51 && random <= 70)
        {
            Debug.Log("50 elmas kazandınız");
            if (reward3 != null)
                reward3.text = "+50";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 50;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 71 && random <= 74)
        {
            Debug.Log("250 elmas kazandınız");
            if (reward3 != null)
                reward3.text = "+250";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 250;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 81 && random <= 82)
        {
            Debug.Log("350 elmas kazandınız");
            if (reward3 != null)
                reward3.text = "+350";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 350;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random == 86)
        {
            Debug.Log("500 elmas kazandınız");
            if (reward3 != null)
                reward3.text = "+500";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 500;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else
        {
            Debug.Log("30 elmas kazandınız");

            if (reward3 != null)
                reward3.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);


        }

        GameObject dup1;
        GameObject dup2;
        GameObject dup3;
        GameObject dup4;
        GameObject dup5;

        d3Dup = Instantiate(d3, transform);
        dup1 = Instantiate(d3, transform);
        dup2 = Instantiate(d3, transform);
        dup3 = Instantiate(d3, transform);
        dup4 = Instantiate(d3, transform);
        dup5 = Instantiate(d3, transform);

        d3Dup.transform.position = d3.transform.position;
        dup1.transform.position = d3.transform.position;
        dup2.transform.position = d3.transform.position;
        dup3.transform.position = d3.transform.position;
        dup4.transform.position = d3.transform.position;
        dup5.transform.position = d3.transform.position;
        //d3Dup.transform.DOPath(gemPath, 2, pathsystem).OnPlay(() => d3Dup.transform.DOScale(new Vector3(1.65f, 1.65f, 1.65f), 2));
        //d3Dup.transform.DOPath(gemPath, 1.5f, pathsystem).OnStepComplete(() => Destroy(d3Dup));
        d3Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => Destroy(d3Dup));
        d3Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => elmasSound());
        dup1.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.2f).OnStepComplete(() => Destroy(dup1));
        dup2.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.4f).OnStepComplete(() => Destroy(dup2));
        dup3.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.6f).OnStepComplete(() => Destroy(dup3));
        dup4.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.8f).OnStepComplete(() => Destroy(dup4));
        dup5.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 2).OnStepComplete(() => Destroy(dup5));

    }

    public void Click4Invoke()
    {
        d4.SetActive(true);
        GameObject.Find("D4").GetComponent<Animator>().SetTrigger("diamonTrigger");

        if (random > 0 && random <= 30)
        {
            Debug.Log("30 elmas kazandınız");

            if (reward4 != null)
                reward4.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 31 && random <= 50)
        {
            Debug.Log("40 elmas kazandınız");
            if (reward4 != null)
                reward4.text = "+40";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 40;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 51 && random <= 70)
        {
            Debug.Log("50 elmas kazandınız");
            if (reward4 != null)
                reward4.text = "+50";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 50;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 71 && random <= 74)
        {
            Debug.Log("250 elmas kazandınız");
            if (reward4 != null)
                reward4.text = "+250";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 250;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 81 && random <= 82)
        {
            Debug.Log("350 elmas kazandınız");
            if (reward4 != null)
                reward4.text = "+350";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 350;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random == 86)
        {
            Debug.Log("500 elmas kazandınız");
            if (reward4 != null)
                reward4.text = "+500";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 500;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else
        {
            Debug.Log("30 elmas kazandınız");

            if (reward4 != null)
                reward4.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);


        }

        GameObject dup1;
        GameObject dup2;
        GameObject dup3;
        GameObject dup4;
        GameObject dup5;

        d4Dup = Instantiate(d4, transform);
        dup1 = Instantiate(d4, transform);
        dup2 = Instantiate(d4, transform);
        dup3 = Instantiate(d4, transform);
        dup4 = Instantiate(d4, transform);
        dup5 = Instantiate(d4, transform);

        d4Dup.transform.position = d4.transform.position;
        dup1.transform.position = d4.transform.position;
        dup2.transform.position = d4.transform.position;
        dup3.transform.position = d4.transform.position;
        dup4.transform.position = d4.transform.position;
        dup5.transform.position = d4.transform.position;
        //d4Dup.transform.DOPath(gemPath, 1.5f, pathsystem).OnStepComplete(() => Destroy(d4Dup));
        d4Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => Destroy(d4Dup));
        d4Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => elmasSound());
        dup1.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.2f).OnStepComplete(() => Destroy(dup1));
        dup2.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.4f).OnStepComplete(() => Destroy(dup2));
        dup3.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.6f).OnStepComplete(() => Destroy(dup3));
        dup4.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.8f).OnStepComplete(() => Destroy(dup4));
        dup5.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 2).OnStepComplete(() => Destroy(dup5));

    }

    public void Click5Invoke()
    {
        d5.SetActive(true);
        GameObject.Find("D5").GetComponent<Animator>().SetTrigger("diamonTrigger");

        if (random > 0 && random <= 30)
        {
            Debug.Log("30 elmas kazandınız");

            if (reward5 != null)
                reward5.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 31 && random <= 50)
        {
            Debug.Log("40 elmas kazandınız");
            if (reward5 != null)
                reward5.text = "+40";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 40;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 51 && random <= 70)
        {
            Debug.Log("50 elmas kazandınız");
            if (reward5 != null)
                reward5.text = "+50";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 50;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 71 && random <= 74)
        {
            Debug.Log("250 elmas kazandınız");
            if (reward5 != null)
                reward5.text = "+250";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 250;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 81 && random <= 82)
        {
            Debug.Log("350 elmas kazandınız");
            if (reward5 != null)
                reward5.text = "+350";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 350;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random == 86)
        {
            Debug.Log("500 elmas kazandınız");
            if (reward5 != null)
                reward5.text = "+500";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 500;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else
        {
            Debug.Log("30 elmas kazandınız");

            if (reward5 != null)
                reward5.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);


        }

        GameObject dup1;
        GameObject dup2;
        GameObject dup3;
        GameObject dup4;
        GameObject dup5;

        d5Dup = Instantiate(d5, transform);
        dup1 = Instantiate(d5, transform);
        dup2 = Instantiate(d5, transform);
        dup3 = Instantiate(d5, transform);
        dup4 = Instantiate(d5, transform);
        dup5 = Instantiate(d5, transform);

        d5Dup.transform.position = d5.transform.position;
        dup1.transform.position = d5.transform.position;
        dup2.transform.position = d5.transform.position;
        dup3.transform.position = d5.transform.position;
        dup4.transform.position = d5.transform.position;
        dup5.transform.position = d5.transform.position;
        //d5Dup.transform.DOPath(gemPath, 1.5f, pathsystem).OnStepComplete(() => Destroy(d5Dup));
        d5Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => Destroy(d5Dup));
        d5Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => elmasSound());
        dup1.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.2f).OnStepComplete(() => Destroy(dup1));
        dup2.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.4f).OnStepComplete(() => Destroy(dup2));
        dup3.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.6f).OnStepComplete(() => Destroy(dup3));
        dup4.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.8f).OnStepComplete(() => Destroy(dup4));
        dup5.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 2).OnStepComplete(() => Destroy(dup5));

    }

    public void Click6Invoke()
    {
        d6.SetActive(true);
        GameObject.Find("D6").GetComponent<Animator>().SetTrigger("diamonTrigger");

        if (random > 0 && random <= 30)
        {
            Debug.Log("30 elmas kazandınız");

            if (reward6 != null)
                reward6.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 31 && random <= 50)
        {
            Debug.Log("40 elmas kazandınız");
            if (reward6 != null)
                reward6.text = "+40";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 40;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 51 && random <= 70)
        {
            Debug.Log("50 elmas kazandınız");
            if (reward6 != null)
                reward6.text = "+50";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 50;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 71 && random <= 74)
        {
            Debug.Log("250 elmas kazandınız");
            if (reward6 != null)
                reward6.text = "+250";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 250;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 81 && random <= 82)
        {
            Debug.Log("350 elmas kazandınız");
            if (reward6 != null)
                reward6.text = "+350";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 350;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random == 86)
        {
            Debug.Log("500 elmas kazandınız");
            if (reward6 != null)
                reward6.text = "+500";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 500;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else
        {
            Debug.Log("30 elmas kazandınız");

            if (reward6 != null)
                reward6.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);


        }

        GameObject dup1;
        GameObject dup2;
        GameObject dup3;
        GameObject dup4;
        GameObject dup5;

        d6Dup = Instantiate(d6, transform);
        dup1 = Instantiate(d6, transform);
        dup2 = Instantiate(d6, transform);
        dup3 = Instantiate(d6, transform);
        dup4 = Instantiate(d6, transform);
        dup5 = Instantiate(d6, transform);

        d6Dup.transform.position = d6.transform.position;
        dup1.transform.position = d6.transform.position;
        dup2.transform.position = d6.transform.position;
        dup3.transform.position = d6.transform.position;
        dup4.transform.position = d6.transform.position;
        dup5.transform.position = d6.transform.position;
        //d6Dup.transform.DOPath(gemPath, 1.5f, pathsystem).OnStepComplete(() => Destroy(d6Dup));
        d6Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => Destroy(d6Dup));
        d6Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => elmasSound());
        dup1.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.2f).OnStepComplete(() => Destroy(dup1));
        dup2.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.4f).OnStepComplete(() => Destroy(dup2));
        dup3.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.6f).OnStepComplete(() => Destroy(dup3));
        dup4.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.8f).OnStepComplete(() => Destroy(dup4));
        dup5.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 2).OnStepComplete(() => Destroy(dup5));

    }

    public void Click7Invoke()
    {
        d7.SetActive(true);
        GameObject.Find("D7").GetComponent<Animator>().SetTrigger("diamonTrigger");

        if (random > 0 && random <= 30)
        {
            Debug.Log("30 elmas kazandınız");

            if (reward7 != null)
                reward7.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 31 && random <= 50)
        {
            Debug.Log("40 elmas kazandınız");
            if (reward7 != null)
                reward7.text = "+40";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 40;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 51 && random <= 70)
        {
            Debug.Log("50 elmas kazandınız");
            if (reward7 != null)
                reward7.text = "+50";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 50;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 71 && random <= 74)
        {
            Debug.Log("250 elmas kazandınız");
            if (reward7 != null)
                reward7.text = "+250";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 250;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 81 && random <= 82)
        {
            Debug.Log("350 elmas kazandınız");
            if (reward7 != null)
                reward7.text = "+350";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 350;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random == 86)
        {
            Debug.Log("500 elmas kazandınız");
            if (reward7 != null)
                reward7.text = "+500";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 500;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else
        {
            Debug.Log("30 elmas kazandınız");

            if (reward7 != null)
                reward7.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);


        }

        GameObject dup1;
        GameObject dup2;
        GameObject dup3;
        GameObject dup4;
        GameObject dup5;

        d7Dup = Instantiate(d7, transform);
        dup1 = Instantiate(d7, transform);
        dup2 = Instantiate(d7, transform);
        dup3 = Instantiate(d7, transform);
        dup4 = Instantiate(d7, transform);
        dup5 = Instantiate(d7, transform);

        d7Dup.transform.position = d7.transform.position;
        dup1.transform.position = d7.transform.position;
        dup2.transform.position = d7.transform.position;
        dup3.transform.position = d7.transform.position;
        dup4.transform.position = d7.transform.position;
        dup5.transform.position = d7.transform.position;
        //d7Dup.transform.DOPath(gemPath, 1.5f, pathsystem).OnStepComplete(() => Destroy(d7Dup));
        d7Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => Destroy(d7Dup));
        d7Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => elmasSound());
        dup1.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.2f).OnStepComplete(() => Destroy(dup1));
        dup2.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.4f).OnStepComplete(() => Destroy(dup2));
        dup3.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.6f).OnStepComplete(() => Destroy(dup3));
        dup4.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.8f).OnStepComplete(() => Destroy(dup4));
        dup5.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 2).OnStepComplete(() => Destroy(dup5));

    }

    public void Click8Invoke()
    {
        d8.SetActive(true);
        GameObject.Find("D8").GetComponent<Animator>().SetTrigger("diamonTrigger");

        if (random > 0 && random <= 30)
        {
            Debug.Log("30 elmas kazandınız");

            if (reward8 != null)
                reward8.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 31 && random <= 50)
        {
            Debug.Log("40 elmas kazandınız");
            if (reward8 != null)
                reward8.text = "+40";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 40;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 51 && random <= 70)
        {
            Debug.Log("50 elmas kazandınız");
            if (reward8 != null)
                reward8.text = "+50";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 50;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 71 && random <= 74)
        {
            Debug.Log("250 elmas kazandınız");
            if (reward8 != null)
                reward8.text = "+250";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 250;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 81 && random <= 82)
        {
            Debug.Log("350 elmas kazandınız");
            if (reward8 != null)
                reward8.text = "+350";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 350;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random == 86)
        {
            Debug.Log("500 elmas kazandınız");
            if (reward8 != null)
                reward8.text = "+500";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 500;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else
        {
            Debug.Log("30 elmas kazandınız");

            if (reward8 != null)
                reward8.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);


        }

        GameObject dup1;
        GameObject dup2;
        GameObject dup3;
        GameObject dup4;
        GameObject dup5;

        d8Dup = Instantiate(d8, transform);
        dup1 = Instantiate(d8, transform);
        dup2 = Instantiate(d8, transform);
        dup3 = Instantiate(d8, transform);
        dup4 = Instantiate(d8, transform);
        dup5 = Instantiate(d8, transform);

        d8Dup.transform.position = d8.transform.position;
        dup1.transform.position = d8.transform.position;
        dup2.transform.position = d8.transform.position;
        dup3.transform.position = d8.transform.position;
        dup4.transform.position = d8.transform.position;
        dup5.transform.position = d8.transform.position;
        //d8Dup.transform.DOPath(gemPath, 1.5f, pathsystem).OnStepComplete(() => Destroy(d8Dup));
        d8Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => Destroy(d8Dup));
        d8Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => elmasSound());
        dup1.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.2f).OnStepComplete(() => Destroy(dup1));
        dup2.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.4f).OnStepComplete(() => Destroy(dup2));
        dup3.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.6f).OnStepComplete(() => Destroy(dup3));
        dup4.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.8f).OnStepComplete(() => Destroy(dup4));
        dup5.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 2).OnStepComplete(() => Destroy(dup5));

    }

    public void Click9Invoke()
    {
        d9.SetActive(true);
        GameObject.Find("D9").GetComponent<Animator>().SetTrigger("diamonTrigger");

        if (random > 0 && random <= 30)
        {
            Debug.Log("30 elmas kazandınız");

            if (reward9 != null)
                reward9.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 31 && random <= 50)
        {
            Debug.Log("40 elmas kazandınız");
            if (reward9 != null)
                reward9.text = "+40";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 40;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 51 && random <= 70)
        {
            Debug.Log("50 elmas kazandınız");
            if (reward9 != null)
                reward9.text = "+50";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 50;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 71 && random <= 74)
        {
            Debug.Log("250 elmas kazandınız");
            if (reward9 != null)
                reward9.text = "+250";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 250;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random >= 81 && random <= 82)
        {
            Debug.Log("350 elmas kazandınız");
            if (reward9 != null)
                reward9.text = "+350";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 350;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else if (random == 86)
        {
            Debug.Log("500 elmas kazandınız");
            if (reward9 != null)
                reward9.text = "+500";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 500;
            PlayerPrefs.SetInt("totalGem", totalGem);

        }
        else
        {
            Debug.Log("30 elmas kazandınız");

            if (reward9 != null)
                reward9.text = "+30";

            totalGem = PlayerPrefs.GetInt("totalGem");
            totalGem += 30;
            PlayerPrefs.SetInt("totalGem", totalGem);


        }

        GameObject dup1;
        GameObject dup2;
        GameObject dup3;
        GameObject dup4;
        GameObject dup5;

        d9Dup = Instantiate(d9, transform);
        dup1 = Instantiate(d9, transform);
        dup2 = Instantiate(d9, transform);
        dup3 = Instantiate(d9, transform);
        dup4 = Instantiate(d9, transform);
        dup5 = Instantiate(d9, transform);

        d9Dup.transform.position = d9.transform.position;
        dup1.transform.position = d9.transform.position;
        dup2.transform.position = d9.transform.position;
        dup3.transform.position = d9.transform.position;
        dup4.transform.position = d9.transform.position;
        dup5.transform.position = d9.transform.position;
        //d9Dup.transform.DOPath(gemPath, 1.5f, pathsystem).OnStepComplete(() => Destroy(d9Dup));

        d9Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => Destroy(d9Dup));
        d9Dup.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1).OnStepComplete(() => elmasSound());
        dup1.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.2f).OnStepComplete(() => Destroy(dup1));
        dup2.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.4f).OnStepComplete(() => Destroy(dup2));
        dup3.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.6f).OnStepComplete(() => Destroy(dup3));
        dup4.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 1.8f).OnStepComplete(() => Destroy(dup4));
        dup5.transform.DOMove(GameObject.Find("elmasAnim").transform.position, 2).OnStepComplete(() => Destroy(dup5));

    }

    public void DestroyChest1()
    {
        Destroy(GameObject.Find("Chest"));
    }
    public void DestroyChest2()
    {
        Destroy(GameObject.Find("Chest2"));
    }
    public void DestroyChest3()
    {
        Destroy(GameObject.Find("Chest3"));
    }
    public void DestroyChest4()
    {
        Destroy(GameObject.Find("Chest4"));
    }
    public void DestroyChest5()
    {
        Destroy(GameObject.Find("Chest5"));
    }
    public void DestroyChest6()
    {
        Destroy(GameObject.Find("Chest6"));
    }
    public void DestroyChest7()
    {
        Destroy(GameObject.Find("Chest7"));
    }
    public void DestroyChest8()
    {
        Destroy(GameObject.Find("Chest8"));
    }
    public void DestroyChest9()
    {
        Destroy(GameObject.Find("Chest9"));
    }

    private void kasaAcmaSound()
    {
        kasacmaSource.PlayOneShot(kasacmaClip, 1);
    }

    private void elmasSound()
    {
        elmasSource.PlayOneShot(elmasClip, 1);
    }
}
