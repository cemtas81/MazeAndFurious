using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

public class highScore : MonoBehaviour
{

    public string path;
    public string pathIOS;
    public string pathAndroid;

    public int levelIndex;
    public int fark;

    Scene scene;

    public static int toplam = 0;
    public int realToplam = 0;

    public Text highScoreText_end;
    public Text highScoreText_pause;

    private string _path;
    private string jsonString;

    // Skor dosyasindan obje yarat
    Dictionary<int, int> scoresObject = new Dictionary<int, int>();

    public void Start()
    {
        scene = SceneManager.GetActiveScene();
        levelIndex = PlayerPrefs.GetInt("lastLevel");
        Debug.Log(levelIndex);

        //Pc için path
        path = Application.dataPath + "/StreamingAssets/levelScores.text";

        //IOS için path
        //path = Application.dataPath + "/Raw/levelScores.json";

        //Android için path
        pathAndroid = "jar:file://" + Application.dataPath + "!/assets/levelScores.json";

        


        // Skor dosyasini oku
        string fileContents = File.ReadAllText(path);

        // Skor dosyasindan obje yarat
        Dictionary<int, int> scoresObject = new Dictionary<int, int>();

        toplam = 0;
        realToplam = 0;
        /*if (levelIndex == 1 && swipteInput.levelEnd == 1)
        {
            if(highScoreText_end != null)
                highScoreText_end.text = swipteInput.scoreConverter.ToString();
            Debug.Log("score convverter :" + swipteInput.scoreConverter + "toplam : " + toplam);
            toplam = 0;
            Debug.Log(toplam);
        }
        else if(levelIndex != 1 && swipteInput.levelEnd == 1)
        {
            if(highScoreText_end != null)
                highScoreText_end.text = (toplam+swipteInput.scoreConverter).ToString();
            Debug.Log("score convverter :" + swipteInput.scoreConverter + "toplam : " + toplam);
            swipteInput.levelEnd = 0;
            toplam = 0;
        }
        else if(swipteInput.levelEnd == 2)
        {
            if (highScoreText_pause != null)
                highScoreText_pause.text = (toplam+swipteInput.scoreConverter).ToString();
            swipteInput.levelEnd = 0;
            toplam = 0;
        }*/


        //pathIOS = Application.persistentDataPath + "/var/mobile/Containers/Data/Application/<guid>/Documents";
        //pathAndroid = Application.persistentDataPath + "/storage/emulated/0/Android/data/<packagename>/files";

        // string scoreAndLevels = JsonUtility.ToJson(levelScore);
        //File.WriteAllText(path, scoreAndLevels);

        _path = Application.streamingAssetsPath + "/levelScores.text";
        UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(_path);
        www.SendWebRequest();
        while (!www.isDone) { }

        jsonString = www.downloadHandler.text;




        Deneme();

    }

    public void Deneme()
    {

        // Skor dosyasini oku
        string fileContents = File.ReadAllText(path);

        try
        {
            var temp = JsonConvert.DeserializeObject<Dictionary<int, int>>(fileContents);
            if (temp != null)
            {
                scoresObject = temp;
            }
        }
        catch
        {
            Debug.Log("Path'teki dosya uygun formatta degil");
        }

        foreach (var kvp in scoresObject)
            toplam += kvp.Value;
        if (highScoreText_end != null)
            highScoreText_pause.text = toplam.ToString();
        //realToplam = toplam + swipteInput.scoreConverter;


        if (scoresObject.ContainsKey(levelIndex+1))
        {
            var enYuksekDeger = scoresObject[levelIndex+1];
            var suAnkiDeger = swipteInput.scoreConverter;
            if (suAnkiDeger > enYuksekDeger)
            {
                //Debug.Log($"Yeni en yuksek deger, yasasin!" {suAnkiDeger});

                fark = (suAnkiDeger - enYuksekDeger);
                realToplam = toplam + fark;
                if (highScoreText_end != null)
                    highScoreText_end.text = realToplam.ToString();
                swipteInput.levelEnd = 0;

            }
            else
            {
                realToplam = toplam;
                if (highScoreText_end != null)
                    highScoreText_end.text = realToplam.ToString();
            }

        }
        else
        {
            realToplam = toplam + swipteInput.scoreConverter;
            if (highScoreText_end != null)
                highScoreText_end.text = realToplam.ToString();
        }

        /*if (levelIndex == 1 && swipteInput.levelEnd == 1)
        {
            if (highScoreText_end != null)
                highScoreText_end.text = swipteInput.scoreConverter.ToString();
            swipteInput.levelEnd = 0;
        }
        else if (levelIndex != 1 && swipteInput.levelEnd == 1)
        {
            if (highScoreText_end != null)
                highScoreText_end.text = realToplam.ToString();

            /*if (highscoreTRY != null)
                highscoreTRY.text = realToplam.ToString();
            swipteInput.levelEnd = 0;

        }*/

    }

}
