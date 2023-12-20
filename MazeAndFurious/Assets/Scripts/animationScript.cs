using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;



public class animationScript : MonoBehaviour
{
    /*[SerializeField]
    GameObject panel;
    Sequence gemAnimation;

    [SerializeField]
    GameObject prefab;

    [SerializeField]
    GameObject button;*/

    [SerializeField]
    GameObject diamond;

    [SerializeField]
    GameObject diamond2;

    [SerializeField]
    GameObject diamond3;

    [SerializeField]
    GameObject diamond4;

    [SerializeField]
    GameObject diamond5;

    [SerializeField]
    GameObject diamond6;

    public PathType pathsystem = PathType.CatmullRom;

    private Vector3[] pathval = new Vector3[6];

    public Button nextButton;
    public Button againButton;
    public Button chestButton;

    private int score;
    private int dScore;
    public Text levelGemText;
    public Text totalGemText;
    
    private int totalGemYazdir;
    private int totalGemCek;

    private AudioSource countSource;
    public AudioClip countClip;

    //public GameObject gemBGanim;

    private void Start()
    {
        DOTween.Init();

        countSource = GameObject.Find("sayma").GetComponent<AudioSource>();
    }


    public void gemFilling()
    {
        totalGemYazdir = PlayerPrefs.GetInt("totalGem");
        totalGemYazdir += Mathf.RoundToInt(swipteInput.sure / 4);
        PlayerPrefs.SetInt("totalGem", totalGemYazdir);
        score = PlayerPrefs.GetInt("sure");
        totalGemCek = PlayerPrefs.GetInt("totalGem");
        dScore = totalGemCek - score;

        pathval[0] = GameObject.Find("path1").transform.position;
        pathval[1] = GameObject.Find("path2").transform.position;
        pathval[2] = GameObject.Find("path3").transform.position;
        pathval[3] = GameObject.Find("path4").transform.position;
        pathval[4] = GameObject.Find("path5").transform.position;
        pathval[5] = GameObject.Find("path6").transform.position;



        diamond.transform.DOPath(pathval, 1, pathsystem).OnPlay(() => diamond.transform.DOScale(new Vector3(0.86f, 0.94f, 1f), 1.2f)).OnStepComplete(() => StartCoroutine(ScoreUpdater()));
        diamond.transform.DOPath(pathval, 1, pathsystem).OnPlay(() => diamond.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 1.2f)).OnStepComplete(() => countSource.PlayOneShot(countClip,1));
        //diamond.transform.DOPath(pathval, 1, pathsystem).OnComplete(() => gemBGanim.SetActive(true));
        diamond2.transform.DOPath(pathval, 1.2f, pathsystem).OnPlay(() => diamond2.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 1.4f)).OnStepComplete(() => countSource.Stop());
        diamond3.transform.DOPath(pathval, 1.4f, pathsystem).OnPlay(() => diamond3.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 1.6f));
        diamond4.transform.DOPath(pathval, 1.6f, pathsystem).OnPlay(() => diamond4.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 1.8f));
        diamond5.transform.DOPath(pathval, 1.7f, pathsystem).OnPlay(() => diamond5.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 2));
        diamond6.transform.DOPath(pathval, 2, pathsystem).OnPlay(() => diamond6.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 2.2f)).OnStepComplete(() => SceneManager.LoadScene("New Scene"));



        nextButton.interactable = false;
        againButton.interactable = false;
        chestButton.interactable = false;

    }

    public void gemFilling3()
    {
        totalGemYazdir = PlayerPrefs.GetInt("totalGem");
        totalGemYazdir += Mathf.RoundToInt(swipteInput.sure / 4);
        PlayerPrefs.SetInt("totalGem", totalGemYazdir);
        score = PlayerPrefs.GetInt("sure");
        totalGemCek = PlayerPrefs.GetInt("totalGem");
        dScore = totalGemCek - score;

        pathval[0] = GameObject.Find("path1").transform.position;
        pathval[1] = GameObject.Find("path2").transform.position;
        pathval[2] = GameObject.Find("path3").transform.position;
        pathval[3] = GameObject.Find("path4").transform.position;
        pathval[4] = GameObject.Find("path5").transform.position;
        pathval[5] = GameObject.Find("path6").transform.position;



        diamond.transform.DOPath(pathval, 1, pathsystem).OnPlay(() => diamond.transform.DOScale(new Vector3(0.86f, 0.94f, 1f), 1.2f)).OnStepComplete(() => StartCoroutine(ScoreUpdater()));
        diamond.transform.DOPath(pathval, 1, pathsystem).OnPlay(() => diamond.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 1.2f)).OnStepComplete(() => countSource.PlayOneShot(countClip, 1));
        //diamond.transform.DOPath(pathval, 1, pathsystem).OnComplete(() => gemBGanim.SetActive(true));
        diamond2.transform.DOPath(pathval, 1.2f, pathsystem).OnPlay(() => diamond2.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 1.4f)).OnStepComplete(() => countSource.Stop());
        diamond3.transform.DOPath(pathval, 1.4f, pathsystem).OnPlay(() => diamond3.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 1.6f));
        diamond4.transform.DOPath(pathval, 1.6f, pathsystem).OnPlay(() => diamond4.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 1.8f));
        diamond5.transform.DOPath(pathval, 1.7f, pathsystem).OnPlay(() => diamond5.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 2));
        diamond6.transform.DOPath(pathval, 2, pathsystem).OnPlay(() => diamond6.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 2.2f)).OnStepComplete(() => SceneManager.LoadScene("Menu"));



        nextButton.interactable = false;
        againButton.interactable = false;
        chestButton.interactable = false;

    }

    public void gemFilling2()
    {
        totalGemYazdir = PlayerPrefs.GetInt("totalGem");
        totalGemYazdir += Mathf.RoundToInt(swipteInput.sure / 4);
        PlayerPrefs.SetInt("totalGem", totalGemYazdir);
        score = PlayerPrefs.GetInt("sure");
        totalGemCek = PlayerPrefs.GetInt("totalGem");
        dScore = totalGemCek - score;

        pathval[0] = GameObject.Find("path1").transform.position;
        pathval[1] = GameObject.Find("path2").transform.position;
        pathval[2] = GameObject.Find("path3").transform.position;
        pathval[3] = GameObject.Find("path4").transform.position;
        pathval[4] = GameObject.Find("path5").transform.position;
        pathval[5] = GameObject.Find("path6").transform.position;



        diamond.transform.DOPath(pathval, 1, pathsystem).OnPlay(() => diamond.transform.DOScale(new Vector3(0.86f, 0.94f, 1f), 1.2f)).OnStepComplete(() => StartCoroutine(ScoreUpdater()));
        diamond.transform.DOPath(pathval, 1, pathsystem).OnPlay(() => diamond.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 1.2f)).OnStepComplete(() => countSource.PlayOneShot(countClip, 1));
        //diamond.transform.DOPath(pathval, 1, pathsystem).OnComplete(() => gemBGanim.SetActive(true));
        diamond2.transform.DOPath(pathval, 1.2f, pathsystem).OnPlay(() => diamond2.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 1.4f)).OnStepComplete(() => countSource.Stop());
        diamond3.transform.DOPath(pathval, 1.4f, pathsystem).OnPlay(() => diamond3.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 1.6f));
        diamond4.transform.DOPath(pathval, 1.6f, pathsystem).OnPlay(() => diamond4.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 1.8f));
        diamond5.transform.DOPath(pathval, 1.7f, pathsystem).OnPlay(() => diamond5.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 2));
        diamond6.transform.DOPath(pathval, 2, pathsystem).OnPlay(() => diamond6.transform.DOScale(new Vector3(0.86f, 0.94f, 1), 2.2f)).OnStepComplete(() => SceneManager.LoadScene("chestScene"));



        nextButton.interactable = false;
        againButton.interactable = false;
        chestButton.interactable = false;

    }

    private IEnumerator ScoreUpdater()
    {
        while (true)
        {
            if(dScore<totalGemCek)
            {
                dScore++;
                totalGemText.text = dScore.ToString();
            }

            yield return new WaitForSeconds(0.001f);
        }
    }
}
