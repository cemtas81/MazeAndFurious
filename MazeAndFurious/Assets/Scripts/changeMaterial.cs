using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeMaterial : MonoBehaviour
{
    //public Material material;
    public static int selectSkin;
    public int goLastLevel;
    public GameObject removeAd;
    public Image mainChar;

    public Sprite[] mainCharSprite;

    public Text characterNameText;

    private AudioSource chooseSource;
    public AudioClip chooseClip;

    private AudioSource buttonSource;
    public AudioClip buttonClip;

    private AudioSource lockedSource;
    public AudioClip lockedClip;

    private AudioSource BuySource;
    public AudioClip BuyClip;

    public GameObject ch1Shadow;
    public GameObject ch2Shadow;
    public GameObject ch3Shadow;
    public GameObject ch4Shadow;
    public GameObject ch5Shadow;
    public GameObject ch6Shadow;
    public GameObject ch7Shadow;
    public GameObject ch8Shadow;
    public GameObject ch9Shadow;
    public GameObject ch10Shadow;
    public GameObject ch11Shadow;
    public GameObject ch12Shadow;
    public GameObject ch13Shadow;
    public GameObject ch14Shadow;
    public GameObject ch15Shadow;
    public GameObject ch16Shadow;
    public GameObject ch17Shadow;
    public GameObject ch18Shadow;
    public GameObject ch19Shadow;
    public GameObject ch20Shadow;

    public GameObject skinBG1;
    public GameObject skinBG2;
    public GameObject skinBG3;
    public GameObject skinBG4;
    public GameObject skinBG5;
    public GameObject skinBG6;
    public GameObject skinBG7;
    public GameObject skinBG8;
    public GameObject skinBG9;
    public GameObject skinBG10;
    public GameObject skinBG11;

    public GameObject backbutton;
    public GameObject gemRewardOBJ;
    public GameObject gemRewardButton;
    public GameObject character;
    public GameObject eyeL;
    public GameObject eyeR;

    public GameObject coronaMaske;
    public GameObject yilbasiSapka;
    public GameObject gozluk;
    public GameObject kaykay;
    public GameObject sapka;
    public GameObject askerimigfer;
    public GameObject maske;
    public GameObject dikenlimigfer;
    public GameObject kulaklik;
    public GameObject roket;
    public GameObject spartamigfer;

    public static int skin1 = 0;
    public static int skin2 = 0;
    public static int skin3 = 0;
    public static int skin4 = 0;
    public static int skin5 = 0;
    public static int skin6 = 0;
    public static int skin7 = 0;
    public static int skin8 = 0;
    public static int skin9 = 0;
    public static int skin10 = 0;
    public static int skin11 = 0;

    public GameObject c1Text;
    public GameObject c2Text;
    public GameObject c3Text;
    public GameObject c4Text;
    public GameObject c5Text;
    public GameObject c6Text;
    public GameObject c7Text;
    public GameObject c8Text;
    public GameObject c9Text;
    public GameObject c10Text;
    public GameObject c11Text;
    public GameObject c12Text;
    public GameObject c13Text;
    public GameObject c14Text;
    public GameObject c15Text;
    public GameObject c16Text;
    public GameObject c17Text;
    public GameObject c18Text;
    public GameObject c19Text;

    public GameObject s1Text;
    public GameObject s2Text;
    public GameObject s3Text;
    public GameObject s4Text;
    public GameObject s5Text;
    public GameObject s6Text;
    public GameObject s7Text;
    public GameObject s8Text;
    public GameObject s9Text;
    public GameObject s10Text;
    public GameObject s11Text;

    private int skin;
    private int equipment;

    private void Start()
    {
        skin = PlayerPrefs.GetInt("skin");
        equipment = PlayerPrefs.GetInt("equip");

        DOTween.Init();

        if(PlayerPrefs.GetInt("charSelect") == 1)
        {
            backbutton.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("charSelect") == 2)
        {
            backbutton.SetActive(false);
            gemRewardButton.transform.DOMove(gemRewardOBJ.transform.position, 0);
        }


        goLastLevel = PlayerPrefs.GetInt("lastLevel");

        

        if (selectSkin >= 1 && selectSkin <= 19 || skin >= 0 && skin <= 19)
            CharSpriteSave();
        else
            CharSelect1();
        skinSave();

        //tıklama sesleri.
        chooseSource = GameObject.Find("gecis").GetComponent<AudioSource>();
        buttonSource = GameObject.Find("menuAcilma").GetComponent<AudioSource>();
        lockedSource = GameObject.Find("locked").GetComponent<AudioSource>();
        BuySource = GameObject.Find("buy").GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("sound") == 1)
        {
            lockedSource.mute = true;
            BuySource.mute = true;
        }
    }

    public void Go2Purchase()
    {
        SceneManager.LoadScene("PurchaseScreen");
        PlayerPrefs.SetInt("satinalma", 1);
    }

    public void CharSelect5()
    {
        if (PlayerPrefs.GetInt("char4") == 1)
        {
            CharSelectSound();

            selectSkin = 5;
            PlayerPrefs.SetInt("skin", 5);

            //seçilen karakterin gölgesini etkinleştirir.
            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(true);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(false);

            //seçilen karakterin ismini ve görselini ekranda gösterir.
            Material materiall = Resources.Load("Materials/karakterTextures/512/ninjaMat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

            mainChar.sprite = mainCharSprite[0];
            if (characterNameText != null)
                characterNameText.text = "NINJA".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(false);
            c3Text.SetActive(false);
            c4Text.SetActive(false);
            c5Text.SetActive(true);
            c6Text.SetActive(false);
            c7Text.SetActive(false);
            c8Text.SetActive(false);
            c9Text.SetActive(false);
            c10Text.SetActive(false);
            c11Text.SetActive(false);
            c12Text.SetActive(false);
            c13Text.SetActive(false);
            c14Text.SetActive(false);
            c15Text.SetActive(false);
            c16Text.SetActive(false);
            c17Text.SetActive(false);
            c18Text.SetActive(false);
            c19Text.SetActive(false);

        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }

    public void CharSelect2()
    {
        if (PlayerPrefs.GetInt("char1") == 1)
        {
            CharSelectSound();

            selectSkin = 2;
            PlayerPrefs.SetInt("skin", 2);

            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(true);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(false);

            Material materiall = Resources.Load("Materials/karakterTextures/512/kissMat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

            mainChar.sprite = mainCharSprite[2];
            if (characterNameText != null)
                characterNameText.text = "RAINBOW".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(true);
            c3Text.SetActive(false);
            c4Text.SetActive(false);
            c5Text.SetActive(false);
            c6Text.SetActive(false);
            c7Text.SetActive(false);
            c8Text.SetActive(false);
            c9Text.SetActive(false);
            c10Text.SetActive(false);
            c11Text.SetActive(false);
            c12Text.SetActive(false);
            c13Text.SetActive(false);
            c14Text.SetActive(false);
            c15Text.SetActive(false);
            c16Text.SetActive(false);
            c17Text.SetActive(false);
            c18Text.SetActive(false);
            c19Text.SetActive(false);


        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }

    public void CharSelect3()
    {
        if (PlayerPrefs.GetInt("char2") == 1)
        {
            CharSelectSound();

            selectSkin = 3;
            PlayerPrefs.SetInt("skin", 3);

            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(true);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(false);

            Material materiall = Resources.Load("Materials/karakterTextures/512/pandaMat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

            mainChar.sprite = mainCharSprite[3];
            if (characterNameText != null)
                characterNameText.text = "PANDA".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(false);
            c3Text.SetActive(true);
            c4Text.SetActive(false);
            c5Text.SetActive(false);
            c6Text.SetActive(false);
            c7Text.SetActive(false);
            c8Text.SetActive(false);
            c9Text.SetActive(false);
            c10Text.SetActive(false);
            c11Text.SetActive(false);
            c12Text.SetActive(false);
            c13Text.SetActive(false);
            c14Text.SetActive(false);
            c15Text.SetActive(false);
            c16Text.SetActive(false);
            c17Text.SetActive(false);
            c18Text.SetActive(false);
            c19Text.SetActive(false);

        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }
    public void CharSelect4()
    {
        if (PlayerPrefs.GetInt("char3") == 1)
        {
            CharSelectSound();

            selectSkin = 4;
            PlayerPrefs.SetInt("skin", 4);

            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(true);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(false);

            Material materiall = Resources.Load("Materials/karakterTextures/512/punisherMat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

            mainChar.sprite = mainCharSprite[4];
            if (characterNameText != null)
                characterNameText.text = "IMMORTAL".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(false);
            c3Text.SetActive(false);
            c4Text.SetActive(true);
            c5Text.SetActive(false);
            c6Text.SetActive(false);
            c7Text.SetActive(false);
            c8Text.SetActive(false);
            c9Text.SetActive(false);
            c10Text.SetActive(false);
            c11Text.SetActive(false);
            c12Text.SetActive(false);
            c13Text.SetActive(false);
            c14Text.SetActive(false);
            c15Text.SetActive(false);
            c16Text.SetActive(false);
            c17Text.SetActive(false);
            c18Text.SetActive(false);
            c19Text.SetActive(false);

        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }

    public void CharSelect1()
    {
        selectSkin = 1;
        PlayerPrefs.SetInt("skin", 1);
        Material materiall = Resources.Load("Materials/karakterTextures/512/bowinMat") as Material;
        character.GetComponent<SkinnedMeshRenderer>().material = materiall;
        eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
        eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

        ch1Shadow.SetActive(true);
        ch2Shadow.SetActive(false);
        ch3Shadow.SetActive(false);
        ch4Shadow.SetActive(false);
        ch5Shadow.SetActive(false);
        ch6Shadow.SetActive(false);
        ch7Shadow.SetActive(false);
        ch8Shadow.SetActive(false);
        ch9Shadow.SetActive(false);
        ch10Shadow.SetActive(false);
        ch11Shadow.SetActive(false);
        ch12Shadow.SetActive(false);
        ch13Shadow.SetActive(false);
        ch14Shadow.SetActive(false);
        ch15Shadow.SetActive(false);
        ch16Shadow.SetActive(false);
        ch17Shadow.SetActive(false);
        ch18Shadow.SetActive(false);
        ch19Shadow.SetActive(false);

        if (characterNameText != null)
            characterNameText.text = "BOWIN".ToString();

        c1Text.SetActive(true);
        c2Text.SetActive(false);
        c3Text.SetActive(false);
        c4Text.SetActive(false);
        c5Text.SetActive(false);
        c6Text.SetActive(false);
        c7Text.SetActive(false);
        c8Text.SetActive(false);
        c9Text.SetActive(false);
        c10Text.SetActive(false);
        c11Text.SetActive(false);
        c12Text.SetActive(false);
        c13Text.SetActive(false);
        c14Text.SetActive(false);
        c15Text.SetActive(false);
        c16Text.SetActive(false);
        c17Text.SetActive(false);
        c18Text.SetActive(false);
        c19Text.SetActive(false);

    }

    public void CharSelect6()
    {
        if (PlayerPrefs.GetInt("char5") == 1)
        {
            CharSelectSound();

            selectSkin = 6;
            PlayerPrefs.SetInt("skin", 6);

            Material materiall = Resources.Load("Materials/karakterTextures/512/color1Mat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
            //mainChar.sprite = mainCharSprite[4];

            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(true);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(false);

            if (characterNameText != null)
                characterNameText.text = "POLITE".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(false);
            c3Text.SetActive(false);
            c4Text.SetActive(false);
            c5Text.SetActive(false);
            c6Text.SetActive(true);
            c7Text.SetActive(false);
            c8Text.SetActive(false);
            c9Text.SetActive(false);
            c10Text.SetActive(false);
            c11Text.SetActive(false);
            c12Text.SetActive(false);
            c13Text.SetActive(false);
            c14Text.SetActive(false);
            c15Text.SetActive(false);
            c16Text.SetActive(false);
            c17Text.SetActive(false);
            c18Text.SetActive(false);
            c19Text.SetActive(false);

        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }

    public void CharSelect7()
    {
        if (PlayerPrefs.GetInt("char6") == 1)
        {
            CharSelectSound();

            selectSkin = 7;
            PlayerPrefs.SetInt("skin", 7);

            Material materiall = Resources.Load("Materials/karakterTextures/512/lemonMat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
            //mainChar.sprite = mainCharSprite[4];

            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(true);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(false);

            if (characterNameText != null)
                characterNameText.text = "ZOMB".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(false);
            c3Text.SetActive(false);
            c4Text.SetActive(false);
            c5Text.SetActive(false);
            c6Text.SetActive(false);
            c7Text.SetActive(true);
            c8Text.SetActive(false);
            c9Text.SetActive(false);
            c10Text.SetActive(false);
            c11Text.SetActive(false);
            c12Text.SetActive(false);
            c13Text.SetActive(false);
            c14Text.SetActive(false);
            c15Text.SetActive(false);
            c16Text.SetActive(false);
            c17Text.SetActive(false);
            c18Text.SetActive(false);
            c19Text.SetActive(false);


        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }

    public void CharSelect8()
    {
        if (PlayerPrefs.GetInt("char7") == 1)
        {
            CharSelectSound();

            selectSkin = 8;
            PlayerPrefs.SetInt("skin", 8);

            Material materiall = Resources.Load("Materials/karakterTextures/512/strawberryMat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
            //mainChar.sprite = mainCharSprite[4];

            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(true);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(false);

            if (characterNameText != null)
                characterNameText.text = "SWEET".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(false);
            c3Text.SetActive(false);
            c4Text.SetActive(false);
            c5Text.SetActive(false);
            c6Text.SetActive(false);
            c7Text.SetActive(false);
            c8Text.SetActive(true);
            c9Text.SetActive(false);
            c10Text.SetActive(false);
            c11Text.SetActive(false);
            c12Text.SetActive(false);
            c13Text.SetActive(false);
            c14Text.SetActive(false);
            c15Text.SetActive(false);
            c16Text.SetActive(false);
            c17Text.SetActive(false);
            c18Text.SetActive(false);
            c19Text.SetActive(false);

        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }
    public void CharSelect9()
    {
        if (PlayerPrefs.GetInt("char8") == 1)
        {
            CharSelectSound();

            selectSkin = 9;
            PlayerPrefs.SetInt("skin", 9);

            Material materiall = Resources.Load("Materials/karakterTextures/512/nightMat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
            //mainChar.sprite = mainCharSprite[4];

            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(true);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(false);

            if (characterNameText != null)
                characterNameText.text = "NIGHT".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(false);
            c3Text.SetActive(false);
            c4Text.SetActive(false);
            c5Text.SetActive(false);
            c6Text.SetActive(false);
            c7Text.SetActive(false);
            c8Text.SetActive(false);
            c9Text.SetActive(true);
            c10Text.SetActive(false);
            c11Text.SetActive(false);
            c12Text.SetActive(false);
            c13Text.SetActive(false);
            c14Text.SetActive(false);
            c15Text.SetActive(false);
            c16Text.SetActive(false);
            c17Text.SetActive(false);
            c18Text.SetActive(false);
            c19Text.SetActive(false);

        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }

    public void CharSelect10()
    {
        if (PlayerPrefs.GetInt("char9") == 1)
        {
            CharSelectSound();

            selectSkin = 10;
            PlayerPrefs.SetInt("skin", 10);

            Material materiall = Resources.Load("Materials/karakterTextures/512/clownMat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
            //mainChar.sprite = mainCharSprite[4];

            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(true);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(false);


            if (characterNameText != null)
                characterNameText.text = "CLOWN".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(false);
            c3Text.SetActive(false);
            c4Text.SetActive(false);
            c5Text.SetActive(false);
            c6Text.SetActive(false);
            c7Text.SetActive(false);
            c8Text.SetActive(false);
            c9Text.SetActive(false);
            c10Text.SetActive(true);
            c11Text.SetActive(false);
            c12Text.SetActive(false);
            c13Text.SetActive(false);
            c14Text.SetActive(false);
            c15Text.SetActive(false);
            c16Text.SetActive(false);
            c17Text.SetActive(false);
            c18Text.SetActive(false);
            c19Text.SetActive(false);
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }
    public void CharSelect11()
    {
        if (PlayerPrefs.GetInt("char10") == 1)
        {
            CharSelectSound();

            selectSkin = 11;
            PlayerPrefs.SetInt("skin", 11);

            Material materiall = Resources.Load("Materials/karakterTextures/512/covidMat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
            //mainChar.sprite = mainCharSprite[4];

            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(true);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(false);

            if (characterNameText != null)
                characterNameText.text = "COVID".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(false);
            c3Text.SetActive(false);
            c4Text.SetActive(false);
            c5Text.SetActive(false);
            c6Text.SetActive(false);
            c7Text.SetActive(false);
            c8Text.SetActive(false);
            c9Text.SetActive(false);
            c10Text.SetActive(false);
            c11Text.SetActive(true);
            c12Text.SetActive(false);
            c13Text.SetActive(false);
            c14Text.SetActive(false);
            c15Text.SetActive(false);
            c16Text.SetActive(false);
            c17Text.SetActive(false);
            c18Text.SetActive(false);
            c19Text.SetActive(false);

        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }
    public void CharSelect12()
    {
        if (PlayerPrefs.GetInt("char11") == 1)
        {
            CharSelectSound();

            selectSkin = 12;
            PlayerPrefs.SetInt("skin", 12);

            Material materiall = Resources.Load("Materials/karakterTextures/512/frenkieMat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
            //mainChar.sprite = mainCharSprite[4];

            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(true);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(false);

            if (characterNameText != null)
                characterNameText.text = "FRANKIE".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(false);
            c3Text.SetActive(false);
            c4Text.SetActive(false);
            c5Text.SetActive(false);
            c6Text.SetActive(false);
            c7Text.SetActive(false);
            c8Text.SetActive(false);
            c9Text.SetActive(false);
            c10Text.SetActive(false);
            c11Text.SetActive(false);
            c12Text.SetActive(true);
            c13Text.SetActive(false);
            c14Text.SetActive(false);
            c15Text.SetActive(false);
            c16Text.SetActive(false);
            c17Text.SetActive(false);
            c18Text.SetActive(false);
            c19Text.SetActive(false);
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }
    public void CharSelect13()
    {
        if (PlayerPrefs.GetInt("char12") == 1)
        {
            CharSelectSound();

            selectSkin = 13;
            PlayerPrefs.SetInt("skin", 13);

            Material materiall = Resources.Load("Materials/karakterTextures/512/mummyMat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
            //mainChar.sprite = mainCharSprite[4];

            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(true);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(false);

            if (characterNameText != null)
                characterNameText.text = "MUMMY".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(false);
            c3Text.SetActive(false);
            c4Text.SetActive(false);
            c5Text.SetActive(false);
            c6Text.SetActive(false);
            c7Text.SetActive(false);
            c8Text.SetActive(false);
            c9Text.SetActive(false);
            c10Text.SetActive(false);
            c11Text.SetActive(false);
            c12Text.SetActive(false);
            c13Text.SetActive(true);
            c14Text.SetActive(false);
            c15Text.SetActive(false);
            c16Text.SetActive(false);
            c17Text.SetActive(false);
            c18Text.SetActive(false);
            c19Text.SetActive(false);
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }
    public void CharSelect14()
    {
        if (PlayerPrefs.GetInt("char13") == 1)
        {
            CharSelectSound();

            selectSkin = 14;
            PlayerPrefs.SetInt("skin", 14);

            Material materiall = Resources.Load("Materials/karakterTextures/512/skeletonMat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
            //mainChar.sprite = mainCharSprite[4];

            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(true);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(false);

            if (characterNameText != null)
                characterNameText.text = "SKELETON".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(false);
            c3Text.SetActive(false);
            c4Text.SetActive(false);
            c5Text.SetActive(false);
            c6Text.SetActive(false);
            c7Text.SetActive(false);
            c8Text.SetActive(false);
            c9Text.SetActive(false);
            c10Text.SetActive(false);
            c11Text.SetActive(false);
            c12Text.SetActive(false);
            c13Text.SetActive(false);
            c14Text.SetActive(true);
            c15Text.SetActive(false);
            c16Text.SetActive(false);
            c17Text.SetActive(false);
            c18Text.SetActive(false);
            c19Text.SetActive(false);
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }
    public void CharSelect15()
    {
        if (PlayerPrefs.GetInt("char14") == 1)
        {
            CharSelectSound();

            selectSkin = 15;
            PlayerPrefs.SetInt("skin", 15);

            Material materiall = Resources.Load("Materials/karakterTextures/512/superhero1Mat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
            //mainChar.sprite = mainCharSprite[4];

            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(true);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(false);

            if (characterNameText != null)
                characterNameText.text = "HERO".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(false);
            c3Text.SetActive(false);
            c4Text.SetActive(false);
            c5Text.SetActive(false);
            c6Text.SetActive(false);
            c7Text.SetActive(false);
            c8Text.SetActive(false);
            c9Text.SetActive(false);
            c10Text.SetActive(false);
            c11Text.SetActive(false);
            c12Text.SetActive(false);
            c13Text.SetActive(false);
            c14Text.SetActive(false);
            c15Text.SetActive(true);
            c16Text.SetActive(false);
            c17Text.SetActive(false);
            c18Text.SetActive(false);
            c19Text.SetActive(false);
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }
    public void CharSelect16()
    {
        if (PlayerPrefs.GetInt("char15") == 1)
        {
            CharSelectSound();

            selectSkin = 16;
            PlayerPrefs.SetInt("skin", 16);

            Material materiall = Resources.Load("Materials/karakterTextures/512/superhero2Mat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
            //mainChar.sprite = mainCharSprite[4];

            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(true);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(false);

            if (characterNameText != null)
                characterNameText.text = "JUDGE".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(false);
            c3Text.SetActive(false);
            c4Text.SetActive(false);
            c5Text.SetActive(false);
            c6Text.SetActive(false);
            c7Text.SetActive(false);
            c8Text.SetActive(false);
            c9Text.SetActive(false);
            c10Text.SetActive(false);
            c11Text.SetActive(false);
            c12Text.SetActive(false);
            c13Text.SetActive(false);
            c14Text.SetActive(false);
            c15Text.SetActive(false);
            c16Text.SetActive(true);
            c17Text.SetActive(false);
            c18Text.SetActive(false);
            c19Text.SetActive(false);
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }
    public void CharSelect17()
    {
        if (PlayerPrefs.GetInt("char16") == 1)
        {
            CharSelectSound();

            selectSkin = 17;
            PlayerPrefs.SetInt("skin", 17);

            Material materiall = Resources.Load("Materials/karakterTextures/512/partymaskMat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
            //mainChar.sprite = mainCharSprite[4];

            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(true);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(false);


            if (characterNameText != null)
                characterNameText.text = "MYSTIC".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(false);
            c3Text.SetActive(false);
            c4Text.SetActive(false);
            c5Text.SetActive(false);
            c6Text.SetActive(false);
            c7Text.SetActive(false);
            c8Text.SetActive(false);
            c9Text.SetActive(false);
            c10Text.SetActive(false);
            c11Text.SetActive(false);
            c12Text.SetActive(false);
            c13Text.SetActive(false);
            c14Text.SetActive(false);
            c15Text.SetActive(false);
            c16Text.SetActive(false);
            c17Text.SetActive(true);
            c18Text.SetActive(false);
            c19Text.SetActive(false);
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }
    public void CharSelect18()
    {
        if (PlayerPrefs.GetInt("char17") == 1)
        {
            CharSelectSound();

            selectSkin = 18;
            PlayerPrefs.SetInt("skin", 18);

            Material materiall = Resources.Load("Materials/karakterTextures/512/balkabagiMat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
            //mainChar.sprite = mainCharSprite[4];

            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(true);
            ch19Shadow.SetActive(false);


            if (characterNameText != null)
                characterNameText.text = "PUMPKING".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(false);
            c3Text.SetActive(false);
            c4Text.SetActive(false);
            c5Text.SetActive(false);
            c6Text.SetActive(false);
            c7Text.SetActive(false);
            c8Text.SetActive(false);
            c9Text.SetActive(false);
            c10Text.SetActive(false);
            c11Text.SetActive(false);
            c12Text.SetActive(false);
            c13Text.SetActive(false);
            c14Text.SetActive(false);
            c15Text.SetActive(false);
            c16Text.SetActive(false);
            c17Text.SetActive(false);
            c18Text.SetActive(true);
            c19Text.SetActive(false);
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }
    public void CharSelect19()
    {
        if (PlayerPrefs.GetInt("char18") == 1)
        {
            CharSelectSound();

            selectSkin = 19;
            PlayerPrefs.SetInt("skin", 19);

            Material materiall = Resources.Load("Materials/karakterTextures/512/terminatorMat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
            //mainChar.sprite = mainCharSprite[4];

            ch1Shadow.SetActive(false);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(true);

            if (characterNameText != null)
                characterNameText.text = "DESTROYER".ToString();

            c1Text.SetActive(false);
            c2Text.SetActive(false);
            c3Text.SetActive(false);
            c4Text.SetActive(false);
            c5Text.SetActive(false);
            c6Text.SetActive(false);
            c7Text.SetActive(false);
            c8Text.SetActive(false);
            c9Text.SetActive(false);
            c10Text.SetActive(false);
            c11Text.SetActive(false);
            c12Text.SetActive(false);
            c13Text.SetActive(false);
            c14Text.SetActive(false);
            c15Text.SetActive(false);
            c16Text.SetActive(false);
            c17Text.SetActive(false);
            c18Text.SetActive(false);
            c19Text.SetActive(true);
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }
    private void CharSpriteSave()
    {
        if (PlayerPrefs.GetInt("char4") == 1)
        {
            if (selectSkin == 5 || skin == 5)
            {
                Material materiall = Resources.Load("Materials/karakterTextures/512/ninjaMat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[0];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(false);
                ch3Shadow.SetActive(false);
                ch4Shadow.SetActive(false);
                ch5Shadow.SetActive(true);
                ch6Shadow.SetActive(false);
                ch7Shadow.SetActive(false);
                ch8Shadow.SetActive(false);
                ch9Shadow.SetActive(false);
                ch10Shadow.SetActive(false);
                ch11Shadow.SetActive(false);
                ch12Shadow.SetActive(false);
                ch13Shadow.SetActive(false);
                ch14Shadow.SetActive(false);
                ch15Shadow.SetActive(false);
                ch16Shadow.SetActive(false);
                ch17Shadow.SetActive(false);
                ch18Shadow.SetActive(false);
                ch19Shadow.SetActive(false);

                if (characterNameText != null)
                    characterNameText.text = "NINJA".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(false);
                c3Text.SetActive(false);
                c4Text.SetActive(false);
                c5Text.SetActive(true);
                c6Text.SetActive(false);
                c7Text.SetActive(false);
                c8Text.SetActive(false);
                c9Text.SetActive(false);
                c10Text.SetActive(false);
                c11Text.SetActive(false);
                c12Text.SetActive(false);
                c13Text.SetActive(false);
                c14Text.SetActive(false);
                c15Text.SetActive(false);
                c16Text.SetActive(false);
                c17Text.SetActive(false);
                c18Text.SetActive(false);
                c19Text.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("char1") == 1)
        {
            if (selectSkin == 2 || skin == 2)
            {

                Material materiall = Resources.Load("Materials/karakterTextures/512/kissMat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[2];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(true);
                ch3Shadow.SetActive(false);
                ch4Shadow.SetActive(false);
                ch5Shadow.SetActive(false);
                ch6Shadow.SetActive(false);
                ch7Shadow.SetActive(false);
                ch8Shadow.SetActive(false);
                ch9Shadow.SetActive(false);
                ch10Shadow.SetActive(false);
                ch11Shadow.SetActive(false);
                ch12Shadow.SetActive(false);
                ch13Shadow.SetActive(false);
                ch14Shadow.SetActive(false);
                ch15Shadow.SetActive(false);
                ch16Shadow.SetActive(false);
                ch17Shadow.SetActive(false);
                ch18Shadow.SetActive(false);
                ch19Shadow.SetActive(false);

                if (characterNameText != null)
                    characterNameText.text = "RAINBOW".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(true);
                c3Text.SetActive(false);
                c4Text.SetActive(false);
                c5Text.SetActive(false);
                c6Text.SetActive(false);
                c7Text.SetActive(false);
                c8Text.SetActive(false);
                c9Text.SetActive(false);
                c10Text.SetActive(false);
                c11Text.SetActive(false);
                c12Text.SetActive(false);
                c13Text.SetActive(false);
                c14Text.SetActive(false);
                c15Text.SetActive(false);
                c16Text.SetActive(false);
                c17Text.SetActive(false);
                c18Text.SetActive(false);
                c19Text.SetActive(false);

            }
        }
        if (PlayerPrefs.GetInt("char2") == 1)
        {
            if (selectSkin == 3 || skin == 3)
            {

                Material materiall = Resources.Load("Materials/karakterTextures/512/pandaMat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[3];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(false);
                ch3Shadow.SetActive(true);
                ch4Shadow.SetActive(false);
                ch5Shadow.SetActive(false);
                ch6Shadow.SetActive(false);
                ch7Shadow.SetActive(false);
                ch8Shadow.SetActive(false);
                ch9Shadow.SetActive(false);
                ch10Shadow.SetActive(false);
                ch11Shadow.SetActive(false);
                ch12Shadow.SetActive(false);
                ch13Shadow.SetActive(false);
                ch14Shadow.SetActive(false);
                ch15Shadow.SetActive(false);
                ch16Shadow.SetActive(false);
                ch17Shadow.SetActive(false);
                ch18Shadow.SetActive(false);
                ch19Shadow.SetActive(false);

                if (characterNameText != null)
                    characterNameText.text = "PANDA".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(false);
                c3Text.SetActive(true);
                c4Text.SetActive(false);
                c5Text.SetActive(false);
                c6Text.SetActive(false);
                c7Text.SetActive(false);
                c8Text.SetActive(false);
                c9Text.SetActive(false);
                c10Text.SetActive(false);
                c11Text.SetActive(false);
                c12Text.SetActive(false);
                c13Text.SetActive(false);
                c14Text.SetActive(false);
                c15Text.SetActive(false);
                c16Text.SetActive(false);
                c17Text.SetActive(false);
                c18Text.SetActive(false);
                c19Text.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("char3") == 1)
        {
            if (selectSkin == 4 || skin == 4)
            {
                Material materiall = Resources.Load("Materials/karakterTextures/512/punisherMat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[4];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(false);
                ch3Shadow.SetActive(false);
                ch4Shadow.SetActive(true);
                ch5Shadow.SetActive(false);
                ch6Shadow.SetActive(false);
                ch7Shadow.SetActive(false);
                ch8Shadow.SetActive(false);
                ch9Shadow.SetActive(false);
                ch10Shadow.SetActive(false);
                ch11Shadow.SetActive(false);
                ch12Shadow.SetActive(false);
                ch13Shadow.SetActive(false);
                ch14Shadow.SetActive(false);
                ch15Shadow.SetActive(false);
                ch16Shadow.SetActive(false);
                ch17Shadow.SetActive(false);
                ch18Shadow.SetActive(false);
                ch19Shadow.SetActive(false);

                if (characterNameText != null)
                    characterNameText.text = "IMMORTAL".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(false);
                c3Text.SetActive(false);
                c4Text.SetActive(true);
                c5Text.SetActive(false);
                c6Text.SetActive(false);
                c7Text.SetActive(false);
                c8Text.SetActive(false);
                c9Text.SetActive(false);
                c10Text.SetActive(false);
                c11Text.SetActive(false);
                c12Text.SetActive(false);
                c13Text.SetActive(false);
                c14Text.SetActive(false);
                c15Text.SetActive(false);
                c16Text.SetActive(false);
                c17Text.SetActive(false);
                c18Text.SetActive(false);
                c19Text.SetActive(false);
            }
        }
        if (selectSkin == 1 || skin == 1)
        {
            Material materiall = Resources.Load("Materials/karakterTextures/512/bowinMat") as Material;
            character.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
            eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
            //mainChar.sprite = mainCharSprite[4];

            ch1Shadow.SetActive(true);
            ch2Shadow.SetActive(false);
            ch3Shadow.SetActive(false);
            ch4Shadow.SetActive(false);
            ch5Shadow.SetActive(false);
            ch6Shadow.SetActive(false);
            ch7Shadow.SetActive(false);
            ch8Shadow.SetActive(false);
            ch9Shadow.SetActive(false);
            ch10Shadow.SetActive(false);
            ch11Shadow.SetActive(false);
            ch12Shadow.SetActive(false);
            ch13Shadow.SetActive(false);
            ch14Shadow.SetActive(false);
            ch15Shadow.SetActive(false);
            ch16Shadow.SetActive(false);
            ch17Shadow.SetActive(false);
            ch18Shadow.SetActive(false);
            ch19Shadow.SetActive(false);

            if (characterNameText != null)
                characterNameText.text = "BOWIN".ToString();

            c1Text.SetActive(true);
            c2Text.SetActive(false);
            c3Text.SetActive(false);
            c4Text.SetActive(false);
            c5Text.SetActive(false);
            c6Text.SetActive(false);
            c7Text.SetActive(false);
            c8Text.SetActive(false);
            c9Text.SetActive(false);
            c10Text.SetActive(false);
            c11Text.SetActive(false);
            c12Text.SetActive(false);
            c13Text.SetActive(false);
            c14Text.SetActive(false);
            c15Text.SetActive(false);
            c16Text.SetActive(false);
            c17Text.SetActive(false);
            c18Text.SetActive(false);
            c19Text.SetActive(false);
        }
        if (PlayerPrefs.GetInt("char5") == 1)
        {
            if (selectSkin == 6 || skin == 6)
            {
                Material materiall = Resources.Load("Materials/karakterTextures/512/color1Mat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[4];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(false);
                ch3Shadow.SetActive(false);
                ch4Shadow.SetActive(false);
                ch5Shadow.SetActive(false);
                ch6Shadow.SetActive(true);
                ch7Shadow.SetActive(false);
                ch8Shadow.SetActive(false);
                ch9Shadow.SetActive(false);
                ch10Shadow.SetActive(false);
                ch11Shadow.SetActive(false);
                ch12Shadow.SetActive(false);
                ch13Shadow.SetActive(false);
                ch14Shadow.SetActive(false);
                ch15Shadow.SetActive(false);
                ch16Shadow.SetActive(false);
                ch17Shadow.SetActive(false);
                ch18Shadow.SetActive(false);
                ch19Shadow.SetActive(false);

                if (characterNameText != null)
                    characterNameText.text = "POLITE".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(false);
                c3Text.SetActive(false);
                c4Text.SetActive(false);
                c5Text.SetActive(false);
                c6Text.SetActive(true);
                c7Text.SetActive(false);
                c8Text.SetActive(false);
                c9Text.SetActive(false);
                c10Text.SetActive(false);
                c11Text.SetActive(false);
                c12Text.SetActive(false);
                c13Text.SetActive(false);
                c14Text.SetActive(false);
                c15Text.SetActive(false);
                c16Text.SetActive(false);
                c17Text.SetActive(false);
                c18Text.SetActive(false);
                c19Text.SetActive(false);

            }
        }
        if (PlayerPrefs.GetInt("char6") == 1)
        {
            if (selectSkin == 7 || skin == 7)
            {
                Material materiall = Resources.Load("Materials/karakterTextures/512/lemonMat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[4];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(false);
                ch3Shadow.SetActive(false);
                ch4Shadow.SetActive(false);
                ch5Shadow.SetActive(false);
                ch6Shadow.SetActive(false);
                ch7Shadow.SetActive(true);
                ch8Shadow.SetActive(false);
                ch9Shadow.SetActive(false);
                ch10Shadow.SetActive(false);
                ch11Shadow.SetActive(false);
                ch12Shadow.SetActive(false);
                ch13Shadow.SetActive(false);
                ch14Shadow.SetActive(false);
                ch15Shadow.SetActive(false);
                ch16Shadow.SetActive(false);
                ch17Shadow.SetActive(false);
                ch18Shadow.SetActive(false);
                ch19Shadow.SetActive(false);

                if (characterNameText != null)
                    characterNameText.text = "ZOMB".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(false);
                c3Text.SetActive(false);
                c4Text.SetActive(false);
                c5Text.SetActive(false);
                c6Text.SetActive(false);
                c7Text.SetActive(true);
                c8Text.SetActive(false);
                c9Text.SetActive(false);
                c10Text.SetActive(false);
                c11Text.SetActive(false);
                c12Text.SetActive(false);
                c13Text.SetActive(false);
                c14Text.SetActive(false);
                c15Text.SetActive(false);
                c16Text.SetActive(false);
                c17Text.SetActive(false);
                c18Text.SetActive(false);
                c19Text.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("char7") == 1)
        {
            if (selectSkin == 8 || skin == 8)
            {
                Material materiall = Resources.Load("Materials/karakterTextures/512/strawberryMat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[4];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(false);
                ch3Shadow.SetActive(false);
                ch4Shadow.SetActive(false);
                ch5Shadow.SetActive(false);
                ch6Shadow.SetActive(false);
                ch7Shadow.SetActive(false);
                ch8Shadow.SetActive(true);
                ch9Shadow.SetActive(false);
                ch10Shadow.SetActive(false);
                ch11Shadow.SetActive(false);
                ch12Shadow.SetActive(false);
                ch13Shadow.SetActive(false);
                ch14Shadow.SetActive(false);
                ch15Shadow.SetActive(false);
                ch16Shadow.SetActive(false);
                ch17Shadow.SetActive(false);
                ch18Shadow.SetActive(false);
                ch19Shadow.SetActive(false);

                if (characterNameText != null)
                    characterNameText.text = "SWEET".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(false);
                c3Text.SetActive(false);
                c4Text.SetActive(false);
                c5Text.SetActive(false);
                c6Text.SetActive(false);
                c7Text.SetActive(false);
                c8Text.SetActive(true);
                c9Text.SetActive(false);
                c10Text.SetActive(false);
                c11Text.SetActive(false);
                c12Text.SetActive(false);
                c13Text.SetActive(false);
                c14Text.SetActive(false);
                c15Text.SetActive(false);
                c16Text.SetActive(false);
                c17Text.SetActive(false);
                c18Text.SetActive(false);
                c19Text.SetActive(false);

            }
        }
        if (PlayerPrefs.GetInt("char8") == 1)
        {
            if (selectSkin == 9 || skin == 9)
            {
                Material materiall = Resources.Load("Materials/karakterTextures/512/nightMat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[4];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(false);
                ch3Shadow.SetActive(false);
                ch4Shadow.SetActive(false);
                ch5Shadow.SetActive(false);
                ch6Shadow.SetActive(false);
                ch7Shadow.SetActive(false);
                ch8Shadow.SetActive(false);
                ch9Shadow.SetActive(true);
                ch10Shadow.SetActive(false);
                ch11Shadow.SetActive(false);
                ch12Shadow.SetActive(false);
                ch13Shadow.SetActive(false);
                ch14Shadow.SetActive(false);
                ch15Shadow.SetActive(false);
                ch16Shadow.SetActive(false);
                ch17Shadow.SetActive(false);
                ch18Shadow.SetActive(false);
                ch19Shadow.SetActive(false);

                if (characterNameText != null)
                    characterNameText.text = "NIGHT".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(false);
                c3Text.SetActive(false);
                c4Text.SetActive(false);
                c5Text.SetActive(false);
                c6Text.SetActive(false);
                c7Text.SetActive(false);
                c8Text.SetActive(false);
                c9Text.SetActive(true);
                c10Text.SetActive(false);
                c11Text.SetActive(false);
                c12Text.SetActive(false);
                c13Text.SetActive(false);
                c14Text.SetActive(false);
                c15Text.SetActive(false);
                c16Text.SetActive(false);
                c17Text.SetActive(false);
                c18Text.SetActive(false);
                c19Text.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("char9") == 1)
        {
            if (selectSkin == 10 || skin == 10)
            {
                Material materiall = Resources.Load("Materials/karakterTextures/512/clownMat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[4];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(false);
                ch3Shadow.SetActive(false);
                ch4Shadow.SetActive(false);
                ch5Shadow.SetActive(false);
                ch6Shadow.SetActive(false);
                ch7Shadow.SetActive(false);
                ch8Shadow.SetActive(false);
                ch9Shadow.SetActive(false);
                ch10Shadow.SetActive(true);
                ch11Shadow.SetActive(false);
                ch12Shadow.SetActive(false);
                ch13Shadow.SetActive(false);
                ch14Shadow.SetActive(false);
                ch15Shadow.SetActive(false);
                ch16Shadow.SetActive(false);
                ch17Shadow.SetActive(false);
                ch18Shadow.SetActive(false);
                ch19Shadow.SetActive(false);

                if (characterNameText != null)
                    characterNameText.text = "CLOWN".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(false);
                c3Text.SetActive(false);
                c4Text.SetActive(false);
                c5Text.SetActive(false);
                c6Text.SetActive(false);
                c7Text.SetActive(false);
                c8Text.SetActive(false);
                c9Text.SetActive(false);
                c10Text.SetActive(true);
                c11Text.SetActive(false);
                c12Text.SetActive(false);
                c13Text.SetActive(false);
                c14Text.SetActive(false);
                c15Text.SetActive(false);
                c16Text.SetActive(false);
                c17Text.SetActive(false);
                c18Text.SetActive(false);
                c19Text.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("char10") == 1)
        {
            if (selectSkin == 11 || skin == 11)
            {
                Material materiall = Resources.Load("Materials/karakterTextures/512/covidMat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[4];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(false);
                ch3Shadow.SetActive(false);
                ch4Shadow.SetActive(false);
                ch5Shadow.SetActive(false);
                ch6Shadow.SetActive(false);
                ch7Shadow.SetActive(false);
                ch8Shadow.SetActive(false);
                ch9Shadow.SetActive(false);
                ch10Shadow.SetActive(false);
                ch11Shadow.SetActive(true);
                ch12Shadow.SetActive(false);
                ch13Shadow.SetActive(false);
                ch14Shadow.SetActive(false);
                ch15Shadow.SetActive(false);
                ch16Shadow.SetActive(false);
                ch17Shadow.SetActive(false);
                ch18Shadow.SetActive(false);
                ch19Shadow.SetActive(false);

                if (characterNameText != null)
                    characterNameText.text = "COVID".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(false);
                c3Text.SetActive(false);
                c4Text.SetActive(false);
                c5Text.SetActive(false);
                c6Text.SetActive(false);
                c7Text.SetActive(false);
                c8Text.SetActive(false);
                c9Text.SetActive(false);
                c10Text.SetActive(false);
                c11Text.SetActive(true);
                c12Text.SetActive(false);
                c13Text.SetActive(false);
                c14Text.SetActive(false);
                c15Text.SetActive(false);
                c16Text.SetActive(false);
                c17Text.SetActive(false);
                c18Text.SetActive(false);
                c19Text.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("char11") == 1)
        {
            if (selectSkin == 12 || skin == 12)
            {
                Material materiall = Resources.Load("Materials/karakterTextures/512/frenkieMat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[4];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(false);
                ch3Shadow.SetActive(false);
                ch4Shadow.SetActive(false);
                ch5Shadow.SetActive(false);
                ch6Shadow.SetActive(false);
                ch7Shadow.SetActive(false);
                ch8Shadow.SetActive(false);
                ch9Shadow.SetActive(false);
                ch10Shadow.SetActive(false);
                ch11Shadow.SetActive(false);
                ch12Shadow.SetActive(true);
                ch13Shadow.SetActive(false);
                ch14Shadow.SetActive(false);
                ch15Shadow.SetActive(false);
                ch16Shadow.SetActive(false);
                ch17Shadow.SetActive(false);
                ch18Shadow.SetActive(false);
                ch19Shadow.SetActive(false);

                if (characterNameText != null)
                    characterNameText.text = "FRANKIE".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(false);
                c3Text.SetActive(false);
                c4Text.SetActive(false);
                c5Text.SetActive(false);
                c6Text.SetActive(false);
                c7Text.SetActive(false);
                c8Text.SetActive(false);
                c9Text.SetActive(false);
                c10Text.SetActive(false);
                c11Text.SetActive(false);
                c12Text.SetActive(true);
                c13Text.SetActive(false);
                c14Text.SetActive(false);
                c15Text.SetActive(false);
                c16Text.SetActive(false);
                c17Text.SetActive(false);
                c18Text.SetActive(false);
                c19Text.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("char12") == 1)
        {
            if (selectSkin == 13 || skin == 13)
            {
                Material materiall = Resources.Load("Materials/karakterTextures/512/mummyMat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[4];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(false);
                ch3Shadow.SetActive(false);
                ch4Shadow.SetActive(false);
                ch5Shadow.SetActive(false);
                ch6Shadow.SetActive(false);
                ch7Shadow.SetActive(false);
                ch8Shadow.SetActive(false);
                ch9Shadow.SetActive(false);
                ch10Shadow.SetActive(false);
                ch11Shadow.SetActive(false);
                ch12Shadow.SetActive(false);
                ch13Shadow.SetActive(true);
                ch14Shadow.SetActive(false);
                ch15Shadow.SetActive(false);
                ch16Shadow.SetActive(false);
                ch17Shadow.SetActive(false);
                ch18Shadow.SetActive(false);
                ch19Shadow.SetActive(false);

                if (characterNameText != null)
                    characterNameText.text = "MUMMY".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(false);
                c3Text.SetActive(false);
                c4Text.SetActive(false);
                c5Text.SetActive(false);
                c6Text.SetActive(false);
                c7Text.SetActive(false);
                c8Text.SetActive(false);
                c9Text.SetActive(false);
                c10Text.SetActive(false);
                c11Text.SetActive(false);
                c12Text.SetActive(false);
                c13Text.SetActive(true);
                c14Text.SetActive(false);
                c15Text.SetActive(false);
                c16Text.SetActive(false);
                c17Text.SetActive(false);
                c18Text.SetActive(false);
                c19Text.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("char13") == 1)
        {
            if (selectSkin == 14 || skin == 14)
            {
                Material materiall = Resources.Load("Materials/karakterTextures/512/skeletonMat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[4];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(false);
                ch3Shadow.SetActive(false);
                ch4Shadow.SetActive(false);
                ch5Shadow.SetActive(false);
                ch6Shadow.SetActive(false);
                ch7Shadow.SetActive(false);
                ch8Shadow.SetActive(false);
                ch9Shadow.SetActive(false);
                ch10Shadow.SetActive(false);
                ch11Shadow.SetActive(false);
                ch12Shadow.SetActive(false);
                ch13Shadow.SetActive(false);
                ch14Shadow.SetActive(true);
                ch15Shadow.SetActive(false);
                ch16Shadow.SetActive(false);
                ch17Shadow.SetActive(false);
                ch18Shadow.SetActive(false);
                ch19Shadow.SetActive(false);

                if (characterNameText != null)
                    characterNameText.text = "SKELETON".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(false);
                c3Text.SetActive(false);
                c4Text.SetActive(false);
                c5Text.SetActive(false);
                c6Text.SetActive(false);
                c7Text.SetActive(false);
                c8Text.SetActive(false);
                c9Text.SetActive(false);
                c10Text.SetActive(false);
                c11Text.SetActive(false);
                c12Text.SetActive(false);
                c13Text.SetActive(false);
                c14Text.SetActive(true);
                c15Text.SetActive(false);
                c16Text.SetActive(false);
                c17Text.SetActive(false);
                c18Text.SetActive(false);
                c19Text.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("char14") == 1)
        {
            if (selectSkin == 15 || skin == 15)
            {
                Material materiall = Resources.Load("Materials/karakterTextures/512/superhero1Mat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[4];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(false);
                ch3Shadow.SetActive(false);
                ch4Shadow.SetActive(false);
                ch5Shadow.SetActive(false);
                ch6Shadow.SetActive(false);
                ch7Shadow.SetActive(false);
                ch8Shadow.SetActive(false);
                ch9Shadow.SetActive(false);
                ch10Shadow.SetActive(false);
                ch11Shadow.SetActive(false);
                ch12Shadow.SetActive(false);
                ch13Shadow.SetActive(false);
                ch14Shadow.SetActive(false);
                ch15Shadow.SetActive(true);
                ch16Shadow.SetActive(false);
                ch17Shadow.SetActive(false);
                ch18Shadow.SetActive(false);
                ch19Shadow.SetActive(false);

                if (characterNameText != null)
                    characterNameText.text = "HERO".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(false);
                c3Text.SetActive(false);
                c4Text.SetActive(false);
                c5Text.SetActive(false);
                c6Text.SetActive(false);
                c7Text.SetActive(false);
                c8Text.SetActive(false);
                c9Text.SetActive(false);
                c10Text.SetActive(false);
                c11Text.SetActive(false);
                c12Text.SetActive(false);
                c13Text.SetActive(false);
                c14Text.SetActive(false);
                c15Text.SetActive(true);
                c16Text.SetActive(false);
                c17Text.SetActive(false);
                c18Text.SetActive(false);
                c19Text.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("char15") == 1)
        {
            if (selectSkin == 16 || skin == 16)
            {
                Material materiall = Resources.Load("Materials/karakterTextures/512/superhero2Mat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[4];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(false);
                ch3Shadow.SetActive(false);
                ch4Shadow.SetActive(false);
                ch5Shadow.SetActive(false);
                ch6Shadow.SetActive(false);
                ch7Shadow.SetActive(false);
                ch8Shadow.SetActive(false);
                ch9Shadow.SetActive(false);
                ch10Shadow.SetActive(false);
                ch11Shadow.SetActive(false);
                ch12Shadow.SetActive(false);
                ch13Shadow.SetActive(false);
                ch14Shadow.SetActive(false);
                ch15Shadow.SetActive(false);
                ch16Shadow.SetActive(true);
                ch17Shadow.SetActive(false);
                ch18Shadow.SetActive(false);
                ch19Shadow.SetActive(false);

                if (characterNameText != null)
                    characterNameText.text = "JUDGE".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(false);
                c3Text.SetActive(false);
                c4Text.SetActive(false);
                c5Text.SetActive(false);
                c6Text.SetActive(false);
                c7Text.SetActive(false);
                c8Text.SetActive(false);
                c9Text.SetActive(false);
                c10Text.SetActive(false);
                c11Text.SetActive(false);
                c12Text.SetActive(false);
                c13Text.SetActive(false);
                c14Text.SetActive(false);
                c15Text.SetActive(false);
                c16Text.SetActive(true);
                c17Text.SetActive(false);
                c18Text.SetActive(false);
                c19Text.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("char16") == 1)
        {
            if (selectSkin == 17 || skin == 17)
            {
                Material materiall = Resources.Load("Materials/karakterTextures/512/partymaskMat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[4];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(false);
                ch3Shadow.SetActive(false);
                ch4Shadow.SetActive(false);
                ch5Shadow.SetActive(false);
                ch6Shadow.SetActive(false);
                ch7Shadow.SetActive(false);
                ch8Shadow.SetActive(false);
                ch9Shadow.SetActive(false);
                ch10Shadow.SetActive(false);
                ch11Shadow.SetActive(false);
                ch12Shadow.SetActive(false);
                ch13Shadow.SetActive(false);
                ch14Shadow.SetActive(false);
                ch15Shadow.SetActive(false);
                ch16Shadow.SetActive(false);
                ch17Shadow.SetActive(true);
                ch18Shadow.SetActive(false);
                ch19Shadow.SetActive(false);

                if (characterNameText != null)
                    characterNameText.text = "MYSTIC".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(false);
                c3Text.SetActive(false);
                c4Text.SetActive(false);
                c5Text.SetActive(false);
                c6Text.SetActive(false);
                c7Text.SetActive(false);
                c8Text.SetActive(false);
                c9Text.SetActive(false);
                c10Text.SetActive(false);
                c11Text.SetActive(false);
                c12Text.SetActive(false);
                c13Text.SetActive(false);
                c14Text.SetActive(false);
                c15Text.SetActive(false);
                c16Text.SetActive(false);
                c17Text.SetActive(true);
                c18Text.SetActive(false);
                c19Text.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("char17") == 1)
        {
            if (selectSkin == 18 || skin == 18)
            {
                Material materiall = Resources.Load("Materials/karakterTextures/512/balkabagiMat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[4];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(false);
                ch3Shadow.SetActive(false);
                ch4Shadow.SetActive(false);
                ch5Shadow.SetActive(false);
                ch6Shadow.SetActive(false);
                ch7Shadow.SetActive(false);
                ch8Shadow.SetActive(false);
                ch9Shadow.SetActive(false);
                ch10Shadow.SetActive(false);
                ch11Shadow.SetActive(false);
                ch12Shadow.SetActive(false);
                ch13Shadow.SetActive(false);
                ch14Shadow.SetActive(false);
                ch15Shadow.SetActive(false);
                ch16Shadow.SetActive(false);
                ch17Shadow.SetActive(false);
                ch18Shadow.SetActive(true);
                ch19Shadow.SetActive(false);

                if (characterNameText != null)
                    characterNameText.text = "PUMPKING".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(false);
                c3Text.SetActive(false);
                c4Text.SetActive(false);
                c5Text.SetActive(false);
                c6Text.SetActive(false);
                c7Text.SetActive(false);
                c8Text.SetActive(false);
                c9Text.SetActive(false);
                c10Text.SetActive(false);
                c11Text.SetActive(false);
                c12Text.SetActive(false);
                c13Text.SetActive(false);
                c14Text.SetActive(false);
                c15Text.SetActive(false);
                c16Text.SetActive(false);
                c17Text.SetActive(false);
                c18Text.SetActive(true);
                c19Text.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("char18") == 1)
        {
            if (selectSkin == 19 || skin == 19)
            {
                Material materiall = Resources.Load("Materials/karakterTextures/512/terminatorMat") as Material;
                character.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
                eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
                //mainChar.sprite = mainCharSprite[4];

                ch1Shadow.SetActive(false);
                ch2Shadow.SetActive(false);
                ch3Shadow.SetActive(false);
                ch4Shadow.SetActive(false);
                ch5Shadow.SetActive(false);
                ch6Shadow.SetActive(false);
                ch7Shadow.SetActive(false);
                ch8Shadow.SetActive(false);
                ch9Shadow.SetActive(false);
                ch10Shadow.SetActive(false);
                ch11Shadow.SetActive(false);
                ch12Shadow.SetActive(false);
                ch13Shadow.SetActive(false);
                ch14Shadow.SetActive(false);
                ch15Shadow.SetActive(false);
                ch16Shadow.SetActive(false);
                ch17Shadow.SetActive(false);
                ch18Shadow.SetActive(false);
                ch19Shadow.SetActive(true);

                if (characterNameText != null)
                    characterNameText.text = "DESTROYER".ToString();

                c1Text.SetActive(false);
                c2Text.SetActive(false);
                c3Text.SetActive(false);
                c4Text.SetActive(false);
                c5Text.SetActive(false);
                c6Text.SetActive(false);
                c7Text.SetActive(false);
                c8Text.SetActive(false);
                c9Text.SetActive(false);
                c10Text.SetActive(false);
                c11Text.SetActive(false);
                c12Text.SetActive(false);
                c13Text.SetActive(false);
                c14Text.SetActive(false);
                c15Text.SetActive(false);
                c16Text.SetActive(false);
                c17Text.SetActive(false);
                c18Text.SetActive(false);
                c19Text.SetActive(true);
            }
        }
    }

    public void Skin1Select()
    {
        if (skin1 == 0) //skin açma.
        {
            skin1 = 1;
            PlayerPrefs.SetInt("equip", 1);
            coronaMaske.SetActive(true);
            yilbasiSapka.SetActive(false);
            gozluk.SetActive(false);
            kaykay.SetActive(false);
            sapka.SetActive(false);
            askerimigfer.SetActive(false);
            maske.SetActive(false);
            dikenlimigfer.SetActive(false);
            kulaklik.SetActive(false);
            roket.SetActive(false);
            spartamigfer.SetActive(false);

            skinBG1.SetActive(true);
            skinBG2.SetActive(false);
            skinBG3.SetActive(false);
            skinBG4.SetActive(false);
            skinBG5.SetActive(false);
            skinBG6.SetActive(false);
            skinBG7.SetActive(false);
            skinBG8.SetActive(false);
            skinBG9.SetActive(false);
            skinBG10.SetActive(false);
            skinBG11.SetActive(false);

            s1Text.SetActive(true);
            s2Text.SetActive(false);
            s3Text.SetActive(false);
            s4Text.SetActive(false);
            s5Text.SetActive(false);
            s6Text.SetActive(false);
            s7Text.SetActive(false);
            s8Text.SetActive(false);
            s9Text.SetActive(false);
            s10Text.SetActive(false);
            s11Text.SetActive(false);

            skin2 = 0;
            skin3 = 0;
            skin4 = 0;
            skin5 = 0;
            skin6 = 0;
            skin7 = 0;
            skin8 = 0;
            skin9 = 0;
            skin10 = 0;
            skin11 = 0;

        }
        else //skin kapama.
        {
            skin1 = 0;
            PlayerPrefs.SetInt("equip", 0);

            coronaMaske.SetActive(false);
            skinBG1.SetActive(false);
            s1Text.SetActive(false);

        }
    }

    public void Skin2Select()
    {
        if (PlayerPrefs.GetInt("bskin1") == 1)
        {
            CharSelectSound();

            if (skin2 == 0)
            {
                skin2 = 1;
                PlayerPrefs.SetInt("equip", 2);

                coronaMaske.SetActive(false);
                yilbasiSapka.SetActive(true);
                gozluk.SetActive(false);
                kaykay.SetActive(false);
                sapka.SetActive(false);
                askerimigfer.SetActive(false);
                maske.SetActive(false);
                dikenlimigfer.SetActive(false);
                kulaklik.SetActive(false);
                roket.SetActive(false);
                spartamigfer.SetActive(false);

                skinBG1.SetActive(false);
                skinBG2.SetActive(true);
                skinBG3.SetActive(false);
                skinBG4.SetActive(false);
                skinBG5.SetActive(false);
                skinBG6.SetActive(false);
                skinBG7.SetActive(false);
                skinBG8.SetActive(false);
                skinBG9.SetActive(false);
                skinBG10.SetActive(false);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(true);
                s3Text.SetActive(false);
                s4Text.SetActive(false);
                s5Text.SetActive(false);
                s6Text.SetActive(false);
                s7Text.SetActive(false);
                s8Text.SetActive(false);
                s9Text.SetActive(false);
                s10Text.SetActive(false);
                s11Text.SetActive(false);

                skin1 = 0;
                skin3 = 0;
                skin4 = 0;
                skin5 = 0;
                skin6 = 0;
                skin7 = 0;
                skin8 = 0;
                skin9 = 0;
                skin10 = 0;
                skin11 = 0;

            }
            else
            {
                skin2 = 0;
                PlayerPrefs.SetInt("equip", 0);

                s2Text.SetActive(false);
                yilbasiSapka.SetActive(false);
                skinBG2.SetActive(false);
            }
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }

    public void Skin3Select()
    {
        if (PlayerPrefs.GetInt("bskin2") == 1)
        {
            CharSelectSound();

            if (skin3 == 0)
            {
                skin3 = 1;
                PlayerPrefs.SetInt("equip", 3);

                coronaMaske.SetActive(false);
                yilbasiSapka.SetActive(false);
                gozluk.SetActive(true);
                kaykay.SetActive(false);
                sapka.SetActive(false);
                askerimigfer.SetActive(false);
                maske.SetActive(false);
                dikenlimigfer.SetActive(false);
                kulaklik.SetActive(false);
                roket.SetActive(false);
                spartamigfer.SetActive(false);

                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(true);
                skinBG4.SetActive(false);
                skinBG5.SetActive(false);
                skinBG6.SetActive(false);
                skinBG7.SetActive(false);
                skinBG8.SetActive(false);
                skinBG9.SetActive(false);
                skinBG10.SetActive(false);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(true);
                s4Text.SetActive(false);
                s5Text.SetActive(false);
                s6Text.SetActive(false);
                s7Text.SetActive(false);
                s8Text.SetActive(false);
                s9Text.SetActive(false);
                s10Text.SetActive(false);
                s11Text.SetActive(false);

                skin1 = 0;
                skin2 = 0;
                skin4 = 0;
                skin5 = 0;
                skin6 = 0;
                skin7 = 0;
                skin8 = 0;
                skin9 = 0;
                skin10 = 0;
                skin11 = 0;

            }
            else
            {
                skin3 = 0;
                PlayerPrefs.SetInt("equip", 0);

                s3Text.SetActive(false);
                gozluk.SetActive(false);
                skinBG3.SetActive(false);

            }
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }

    public void Skin4Select()
    {
        if (PlayerPrefs.GetInt("bskin3") == 1)
        {
            CharSelectSound();

            if (skin4 == 0)
            {
                skin4 = 1;
                PlayerPrefs.SetInt("equip", 4);

                coronaMaske.SetActive(false);
                yilbasiSapka.SetActive(false);
                gozluk.SetActive(false);
                kaykay.SetActive(true);
                sapka.SetActive(false);
                askerimigfer.SetActive(false);
                maske.SetActive(false);
                dikenlimigfer.SetActive(false);
                kulaklik.SetActive(false);
                roket.SetActive(false);
                spartamigfer.SetActive(false);

                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(false);
                skinBG4.SetActive(true);
                skinBG5.SetActive(false);
                skinBG6.SetActive(false);
                skinBG7.SetActive(false);
                skinBG8.SetActive(false);
                skinBG9.SetActive(false);
                skinBG10.SetActive(false);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(false);
                s4Text.SetActive(true);
                s5Text.SetActive(false);
                s6Text.SetActive(false);
                s7Text.SetActive(false);
                s8Text.SetActive(false);
                s9Text.SetActive(false);
                s10Text.SetActive(false);
                s11Text.SetActive(false);

                skin1 = 0;
                skin2 = 0;
                skin3 = 0;
                skin5 = 0;
                skin6 = 0;
                skin7 = 0;
                skin8 = 0;
                skin9 = 0;
                skin10 = 0;
                skin11 = 0;

            }
            else
            {
                skin4 = 0;
                PlayerPrefs.SetInt("equip", 0);

                s4Text.SetActive(false);
                kaykay.SetActive(false);
                skinBG4.SetActive(false);
            }
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }

    public void Skin5Select()
    {
        if (PlayerPrefs.GetInt("bskin4") == 1)
        {
            CharSelectSound();

            if (skin5 == 0 || equipment == 5)
            {
                skin5 = 1;
                PlayerPrefs.SetInt("equip", 5);

                coronaMaske.SetActive(false);
                yilbasiSapka.SetActive(false);
                gozluk.SetActive(false);
                kaykay.SetActive(false);
                sapka.SetActive(true);
                askerimigfer.SetActive(false);
                maske.SetActive(false);
                dikenlimigfer.SetActive(false);
                kulaklik.SetActive(false);
                roket.SetActive(false);
                spartamigfer.SetActive(false);

                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(false);
                skinBG4.SetActive(false);
                skinBG5.SetActive(true);
                skinBG6.SetActive(false);
                skinBG7.SetActive(false);
                skinBG8.SetActive(false);
                skinBG9.SetActive(false);
                skinBG10.SetActive(false);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(false);
                s4Text.SetActive(false);
                s5Text.SetActive(true);
                s6Text.SetActive(false);
                s7Text.SetActive(false);
                s8Text.SetActive(false);
                s9Text.SetActive(false);
                s10Text.SetActive(false);
                s11Text.SetActive(false);

                skin1 = 0;
                skin2 = 0;
                skin3 = 0;
                skin4 = 0;
                skin6 = 0;
                skin7 = 0;
                skin8 = 0;
                skin9 = 0;
                skin10 = 0;
                skin11 = 0;

            }
            else
            {
                skin5 = 0;
                PlayerPrefs.SetInt("equip", 0);

                s5Text.SetActive(false);
                sapka.SetActive(false);
                skinBG5.SetActive(false);
            }
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }

    public void Skin6Select()
    {
        if (PlayerPrefs.GetInt("bskin5") == 1)
        {
            CharSelectSound();

            if (skin6 == 0 || equipment == 6)
            {
                skin6 = 1;
                PlayerPrefs.SetInt("equip", 6);
                coronaMaske.SetActive(false);
                yilbasiSapka.SetActive(false);
                gozluk.SetActive(false);
                kaykay.SetActive(false);
                sapka.SetActive(false);
                askerimigfer.SetActive(true);
                maske.SetActive(false);
                dikenlimigfer.SetActive(false);
                kulaklik.SetActive(false);
                roket.SetActive(false);
                spartamigfer.SetActive(false);

                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(false);
                skinBG4.SetActive(false);
                skinBG5.SetActive(false);
                skinBG6.SetActive(true);
                skinBG7.SetActive(false);
                skinBG8.SetActive(false);
                skinBG9.SetActive(false);
                skinBG10.SetActive(false);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(false);
                s4Text.SetActive(false);
                s5Text.SetActive(false);
                s6Text.SetActive(true);
                s7Text.SetActive(false);
                s8Text.SetActive(false);
                s9Text.SetActive(false);
                s10Text.SetActive(false);
                s11Text.SetActive(false);

                skin1 = 0;
                skin2 = 0;
                skin3 = 0;
                skin4 = 0;
                skin5 = 0;
                skin7 = 0;
                skin8 = 0;
                skin9 = 0;
                skin10 = 0;
                skin11 = 0;

            }
            else
            {
                skin6 = 0;
                PlayerPrefs.SetInt("equip", 0);

                s6Text.SetActive(false);
                askerimigfer.SetActive(false);
                skinBG6.SetActive(false);
            }
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }

    public void Skin7Select()
    {
        if (PlayerPrefs.GetInt("bskin6") == 1)
        {
            CharSelectSound();

            if (skin7 == 0 || equipment == 7)
            {
                skin7 = 1;
                PlayerPrefs.SetInt("equip", 7);
                coronaMaske.SetActive(false);
                yilbasiSapka.SetActive(false);
                gozluk.SetActive(false);
                kaykay.SetActive(false);
                sapka.SetActive(false);
                askerimigfer.SetActive(false);
                maske.SetActive(true);
                dikenlimigfer.SetActive(false);
                kulaklik.SetActive(false);
                roket.SetActive(false);
                spartamigfer.SetActive(false);

                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(false);
                skinBG4.SetActive(false);
                skinBG5.SetActive(false);
                skinBG6.SetActive(false);
                skinBG7.SetActive(true);
                skinBG8.SetActive(false);
                skinBG9.SetActive(false);
                skinBG10.SetActive(false);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(false);
                s4Text.SetActive(false);
                s5Text.SetActive(false);
                s6Text.SetActive(false);
                s7Text.SetActive(true);
                s8Text.SetActive(false);
                s9Text.SetActive(false);
                s10Text.SetActive(false);
                s11Text.SetActive(false);

                skin1 = 0;
                skin2 = 0;
                skin3 = 0;
                skin4 = 0;
                skin5 = 0;
                skin6 = 0;
                skin8 = 0;
                skin9 = 0;
                skin10 = 0;
                skin11 = 0;

            }
            else
            {
                skin7 = 0;
                PlayerPrefs.SetInt("equip", 0);

                s7Text.SetActive(false);
                maske.SetActive(false);
                skinBG7.SetActive(false);

            }
        }

        else
            lockedSource.PlayOneShot(lockedClip, 1);

    }

    public void Skin8Select()
    {
        if (PlayerPrefs.GetInt("bskin7") == 1)
        {
            CharSelectSound();

            if (skin8 == 0 || equipment == 8)
            {
                skin8 = 1;
                PlayerPrefs.SetInt("equip", 8);
                coronaMaske.SetActive(false);
                yilbasiSapka.SetActive(false);
                gozluk.SetActive(false);
                kaykay.SetActive(false);
                sapka.SetActive(false);
                askerimigfer.SetActive(false);
                maske.SetActive(false);
                dikenlimigfer.SetActive(true);
                kulaklik.SetActive(false);
                roket.SetActive(false);
                spartamigfer.SetActive(false);

                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(false);
                skinBG4.SetActive(false);
                skinBG5.SetActive(false);
                skinBG6.SetActive(false);
                skinBG7.SetActive(false);
                skinBG8.SetActive(true);
                skinBG9.SetActive(false);
                skinBG10.SetActive(false);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(false);
                s4Text.SetActive(false);
                s5Text.SetActive(false);
                s6Text.SetActive(false);
                s7Text.SetActive(false);
                s8Text.SetActive(true);
                s9Text.SetActive(false);
                s10Text.SetActive(false);
                s11Text.SetActive(false);

                skin1 = 0;
                skin2 = 0;
                skin3 = 0;
                skin4 = 0;
                skin5 = 0;
                skin6 = 0;
                skin7 = 0;
                skin9 = 0;
                skin10 = 0;
                skin11 = 0;

            }
            else
            {
                skin8 = 0;
                PlayerPrefs.SetInt("equip", 0);

                s8Text.SetActive(false);
                dikenlimigfer.SetActive(false);
                skinBG8.SetActive(false);
            }
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }

    public void Skin9Select()
    {
        if (PlayerPrefs.GetInt("bskin8") == 1)
        {
            CharSelectSound();

            if (skin9 == 0 || equipment == 9)
            {
                skin9 = 1;
                PlayerPrefs.SetInt("equip", 9);
                coronaMaske.SetActive(false);
                yilbasiSapka.SetActive(false);
                gozluk.SetActive(false);
                kaykay.SetActive(false);
                sapka.SetActive(false);
                askerimigfer.SetActive(false);
                maske.SetActive(false);
                dikenlimigfer.SetActive(false);
                kulaklik.SetActive(true);
                roket.SetActive(false);
                spartamigfer.SetActive(false);

                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(false);
                skinBG4.SetActive(false);
                skinBG5.SetActive(false);
                skinBG6.SetActive(false);
                skinBG7.SetActive(false);
                skinBG8.SetActive(false);
                skinBG9.SetActive(true);
                skinBG10.SetActive(false);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(false);
                s4Text.SetActive(false);
                s5Text.SetActive(false);
                s6Text.SetActive(false);
                s7Text.SetActive(false);
                s8Text.SetActive(false);
                s9Text.SetActive(true);
                s10Text.SetActive(false);
                s11Text.SetActive(false);

                skin1 = 0;
                skin2 = 0;
                skin3 = 0;
                skin4 = 0;
                skin5 = 0;
                skin6 = 0;
                skin7 = 0;
                skin8 = 0;
                skin10 = 0;
                skin11 = 0;

            }
            else
            {
                skin9 = 0;
                PlayerPrefs.SetInt("equip", 0);

                s9Text.SetActive(false);
                kulaklik.SetActive(false);
                skinBG9.SetActive(false);
            }
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }

    public void Skin10Select()
    {
        if (PlayerPrefs.GetInt("bskin9") == 1)
        {
            CharSelectSound();

            if (skin10 == 0 || equipment == 10)
            {
                skin10 = 1;
                PlayerPrefs.SetInt("equip", 10);
                coronaMaske.SetActive(false);
                yilbasiSapka.SetActive(false);
                gozluk.SetActive(false);
                kaykay.SetActive(false);
                sapka.SetActive(false);
                askerimigfer.SetActive(false);
                maske.SetActive(false);
                dikenlimigfer.SetActive(false);
                kulaklik.SetActive(false);
                roket.SetActive(true);
                spartamigfer.SetActive(false);

                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(false);
                skinBG4.SetActive(false);
                skinBG5.SetActive(false);
                skinBG6.SetActive(false);
                skinBG7.SetActive(false);
                skinBG8.SetActive(false);
                skinBG9.SetActive(false);
                skinBG10.SetActive(true);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(false);
                s4Text.SetActive(false);
                s5Text.SetActive(false);
                s6Text.SetActive(false);
                s7Text.SetActive(false);
                s8Text.SetActive(false);
                s9Text.SetActive(false);
                s10Text.SetActive(true);
                s11Text.SetActive(false);

                skin1 = 0;
                skin2 = 0;
                skin3 = 0;
                skin4 = 0;
                skin5 = 0;
                skin6 = 0;
                skin7 = 0;
                skin8 = 0;
                skin9 = 0;
                skin11 = 0;

            }
            else
            {
                skin10 = 0;
                PlayerPrefs.SetInt("equip", 0);

                s10Text.SetActive(false);
                roket.SetActive(false);
                skinBG10.SetActive(false);
            }
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }

    public void Skin11Select()
    {
        if (PlayerPrefs.GetInt("bskin10") == 1)
        {
            CharSelectSound();

            if (skin11 == 0 || equipment == 11)
            {
                skin11 = 1;
                PlayerPrefs.SetInt("equip", 11);
                coronaMaske.SetActive(false);
                yilbasiSapka.SetActive(false);
                gozluk.SetActive(false);
                kaykay.SetActive(false);
                sapka.SetActive(false);
                askerimigfer.SetActive(false);
                maske.SetActive(false);
                dikenlimigfer.SetActive(false);
                kulaklik.SetActive(false);
                roket.SetActive(false);
                spartamigfer.SetActive(true);

                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(false);
                skinBG4.SetActive(false);
                skinBG5.SetActive(false);
                skinBG6.SetActive(false);
                skinBG7.SetActive(false);
                skinBG8.SetActive(false);
                skinBG9.SetActive(false);
                skinBG10.SetActive(false);
                skinBG11.SetActive(true);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(false);
                s4Text.SetActive(false);
                s5Text.SetActive(false);
                s6Text.SetActive(false);
                s7Text.SetActive(false);
                s8Text.SetActive(false);
                s9Text.SetActive(false);
                s10Text.SetActive(false);
                s11Text.SetActive(true);

                skin1 = 0;
                skin2 = 0;
                skin3 = 0;
                skin4 = 0;
                skin5 = 0;
                skin6 = 0;
                skin7 = 0;
                skin8 = 0;
                skin9 = 0;
                skin10 = 0;

            }
            else
            {
                skin11 = 0;
                PlayerPrefs.SetInt("equip", 0);

                s11Text.SetActive(false);
                spartamigfer.SetActive(false);
                skinBG11.SetActive(false);

            }
        }
        else
            lockedSource.PlayOneShot(lockedClip, 1);
    }

    private void skinSave()
    {
        if (skin1 == 1 || equipment == 1)
        {
            coronaMaske.SetActive(true);
            skinBG1.SetActive(true);
            skinBG2.SetActive(false);
            skinBG3.SetActive(false);
            skinBG4.SetActive(false);
            skinBG5.SetActive(false);
            skinBG6.SetActive(false);
            skinBG7.SetActive(false);
            skinBG8.SetActive(false);
            skinBG9.SetActive(false);
            skinBG10.SetActive(false);
            skinBG11.SetActive(false);

            s1Text.SetActive(true);
            s2Text.SetActive(false);
            s3Text.SetActive(false);
            s4Text.SetActive(false);
            s5Text.SetActive(false);
            s6Text.SetActive(false);
            s7Text.SetActive(false);
            s8Text.SetActive(false);
            s9Text.SetActive(false);
            s10Text.SetActive(false);
            s11Text.SetActive(false);

            skin1 = 1;

        }
        else
        {
            s1Text.SetActive(false);
            coronaMaske.SetActive(false);
        }
        if (PlayerPrefs.GetInt("bskin1") == 1)
        {
            if (skin2 == 1 || equipment == 2)
            {
                yilbasiSapka.SetActive(true);
                skinBG1.SetActive(false);
                skinBG2.SetActive(true);
                skinBG3.SetActive(false);
                skinBG4.SetActive(false);
                skinBG5.SetActive(false);
                skinBG6.SetActive(false);
                skinBG7.SetActive(false);
                skinBG8.SetActive(false);
                skinBG9.SetActive(false);
                skinBG10.SetActive(false);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(true);
                s3Text.SetActive(false);
                s4Text.SetActive(false);
                s5Text.SetActive(false);
                s6Text.SetActive(false);
                s7Text.SetActive(false);
                s8Text.SetActive(false);
                s9Text.SetActive(false);
                s10Text.SetActive(false);
                s11Text.SetActive(false);

                skin2 = 1;

            }
            else
            {
                s2Text.SetActive(false);
                yilbasiSapka.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("bskin5") == 1)
        {
            if (skin6 == 1 || equipment == 6)
            {
                askerimigfer.SetActive(true);
                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(false);
                skinBG4.SetActive(false);
                skinBG5.SetActive(false);
                skinBG6.SetActive(true);
                skinBG7.SetActive(false);
                skinBG8.SetActive(false);
                skinBG9.SetActive(false);
                skinBG10.SetActive(false);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(false);
                s4Text.SetActive(false);
                s5Text.SetActive(false);
                s6Text.SetActive(true);
                s7Text.SetActive(false);
                s8Text.SetActive(false);
                s9Text.SetActive(false);
                s10Text.SetActive(false);
                s11Text.SetActive(false);

                skin6 = 1;
            }
            else
            {
                s6Text.SetActive(false);
                askerimigfer.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("bskin4") == 1)
        {
            if (skin5 == 1 || equipment == 5)
            {
                sapka.SetActive(true);
                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(false);
                skinBG4.SetActive(false);
                skinBG5.SetActive(true);
                skinBG6.SetActive(false);
                skinBG7.SetActive(false);
                skinBG8.SetActive(false);
                skinBG9.SetActive(false);
                skinBG10.SetActive(false);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(false);
                s4Text.SetActive(false);
                s5Text.SetActive(true);
                s6Text.SetActive(false);
                s7Text.SetActive(false);
                s8Text.SetActive(false);
                s9Text.SetActive(false);
                s10Text.SetActive(false);
                s11Text.SetActive(false);

                skin5 = 1;
            }
            else
            {
                s5Text.SetActive(false);
                sapka.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("bskin7") == 1)
        {
            if (skin8 == 1 || equipment == 8)
            {
                dikenlimigfer.SetActive(true);
                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(false);
                skinBG4.SetActive(false);
                skinBG5.SetActive(false);
                skinBG6.SetActive(false);
                skinBG7.SetActive(false);
                skinBG8.SetActive(true);
                skinBG9.SetActive(false);
                skinBG10.SetActive(false);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(false);
                s4Text.SetActive(false);
                s5Text.SetActive(false);
                s6Text.SetActive(false);
                s7Text.SetActive(false);
                s8Text.SetActive(true);
                s9Text.SetActive(false);
                s10Text.SetActive(false);
                s11Text.SetActive(false);

                skin8 = 1;
            }
            else
            {
                s8Text.SetActive(false);
                dikenlimigfer.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("bskin6") == 1)
        {
            if (skin7 == 1 || equipment == 7)
            {
                maske.SetActive(true);
                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(false);
                skinBG4.SetActive(false);
                skinBG5.SetActive(false);
                skinBG6.SetActive(false);
                skinBG7.SetActive(true);
                skinBG8.SetActive(false);
                skinBG9.SetActive(false);
                skinBG10.SetActive(false);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(false);
                s4Text.SetActive(false);
                s5Text.SetActive(false);
                s6Text.SetActive(false);
                s7Text.SetActive(true);
                s8Text.SetActive(false);
                s9Text.SetActive(false);
                s10Text.SetActive(false);
                s11Text.SetActive(false);

                skin7 = 1;
            }
            else
            {
                s7Text.SetActive(false);
                maske.SetActive(false);

            }
        }
        if (PlayerPrefs.GetInt("bskin10") == 1)
        {
            if (skin11 == 1 || equipment == 11)
            {
                spartamigfer.SetActive(true);
                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(false);
                skinBG4.SetActive(false);
                skinBG5.SetActive(false);
                skinBG6.SetActive(false);
                skinBG7.SetActive(false);
                skinBG8.SetActive(false);
                skinBG9.SetActive(false);
                skinBG10.SetActive(false);
                skinBG11.SetActive(true);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(false);
                s4Text.SetActive(false);
                s5Text.SetActive(false);
                s6Text.SetActive(false);
                s7Text.SetActive(false);
                s8Text.SetActive(false);
                s9Text.SetActive(false);
                s10Text.SetActive(false);
                s11Text.SetActive(true);

                skin11 = 1;
            }
            else
            {
                s11Text.SetActive(false);
                spartamigfer.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("bskin8") == 1)
        {
            if (skin9 == 1 || equipment == 9)
            {
                kulaklik.SetActive(true);
                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(false);
                skinBG4.SetActive(false);
                skinBG5.SetActive(false);
                skinBG6.SetActive(false);
                skinBG7.SetActive(false);
                skinBG8.SetActive(false);
                skinBG9.SetActive(true);
                skinBG10.SetActive(false);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(false);
                s4Text.SetActive(false);
                s5Text.SetActive(false);
                s6Text.SetActive(false);
                s7Text.SetActive(false);
                s8Text.SetActive(false);
                s9Text.SetActive(true);
                s10Text.SetActive(false);
                s11Text.SetActive(false);

                skin9 = 1;
            }
            else
            {
                s9Text.SetActive(false);
                kulaklik.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("bskin2") == 1)
        {
            if (skin3 == 1 || equipment == 3)
            {
                gozluk.SetActive(true);
                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(true);
                skinBG4.SetActive(false);
                skinBG5.SetActive(false);
                skinBG6.SetActive(false);
                skinBG7.SetActive(false);
                skinBG8.SetActive(false);
                skinBG9.SetActive(false);
                skinBG10.SetActive(false);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(true);
                s4Text.SetActive(false);
                s5Text.SetActive(false);
                s6Text.SetActive(false);
                s7Text.SetActive(false);
                s8Text.SetActive(false);
                s9Text.SetActive(false);
                s10Text.SetActive(false);
                s11Text.SetActive(false);

                skin3 = 1;
            }
            else
            {
                s3Text.SetActive(false);
                gozluk.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("bskin9") == 1)
        {
            if (skin10 == 1 || equipment == 10)
            {
                roket.SetActive(true);
                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(false);
                skinBG4.SetActive(false);
                skinBG5.SetActive(false);
                skinBG6.SetActive(false);
                skinBG7.SetActive(false);
                skinBG8.SetActive(false);
                skinBG9.SetActive(false);
                skinBG10.SetActive(true);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(false);
                s4Text.SetActive(false);
                s5Text.SetActive(false);
                s6Text.SetActive(false);
                s7Text.SetActive(false);
                s8Text.SetActive(false);
                s9Text.SetActive(false);
                s10Text.SetActive(true);
                s11Text.SetActive(false);

                skin10 = 1;
            }
            else
            {
                s10Text.SetActive(false);
                roket.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("bskin3") == 1)
        {
            if (skin4 == 1 || equipment == 4)
            {
                kaykay.SetActive(true);
                skinBG1.SetActive(false);
                skinBG2.SetActive(false);
                skinBG3.SetActive(false);
                skinBG4.SetActive(true);
                skinBG5.SetActive(false);
                skinBG6.SetActive(false);
                skinBG7.SetActive(false);
                skinBG8.SetActive(false);
                skinBG9.SetActive(false);
                skinBG10.SetActive(false);
                skinBG11.SetActive(false);

                s1Text.SetActive(false);
                s2Text.SetActive(false);
                s3Text.SetActive(false);
                s4Text.SetActive(true);
                s5Text.SetActive(false);
                s6Text.SetActive(false);
                s7Text.SetActive(false);
                s8Text.SetActive(false);
                s9Text.SetActive(false);
                s10Text.SetActive(false);
                s11Text.SetActive(false);

                skin4 = 1;
            }
            else
            {
                s4Text.SetActive(false);
                kaykay.SetActive(false);
            }
        }
    }

    public void PlayScene()
    {
        //ana menuden start a basıldığında shopa yada oyuna gidilmesi için
        //1 oyuna gitmesini sağlar.
        PlayerPrefs.SetInt("shop", 1);
        //karaketerlerden bir tanesi seçili değilse diğer ekrana geçilmez.
        
            /*if (PlayerPrefs.GetInt("tutorial") == 0)
                SceneManager.LoadScene("Tutorial");
            else*/
                SceneManager.LoadScene("New Scene");
        
    }

    public void BackScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void BuySound()
    {
        BuySource.PlayOneShot(BuyClip, 1);
    }

    public void CharSelectSound()
    {
        chooseSource.PlayOneShot(chooseClip, 1);
    }

    public void ButtonSound()
    {
        buttonSource.PlayOneShot(buttonClip, 1);
    }
}
