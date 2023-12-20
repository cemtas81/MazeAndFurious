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

public class jsonSaver : MonoBehaviour
{
    //public LevelScoreSave levelScore = new LevelScoreSave(1, 190);

    public string path;
    public string path2;
    public string pathIOS;
    public string pathAndroid;
    public string pathAndroid2;

    public int levelIndex;
    //public Text toplamScoreText;

    Scene scene;

    public static int toplam = 0;
    int deneme;

    private string _path;
    private String jsonString;
    public void Start()
    {

        scene = SceneManager.GetActiveScene();
        levelIndex = PlayerPrefs.GetInt("lastLevel");
        Debug.Log(levelIndex);

        path = Application.dataPath + "/StreamingAssets/levelScores.text";

        //IOS için okuma
        //path = Application.dataPath + "/Raw/levelScores.text";

        //IOS için path yazma
        path2 = Application.persistentDataPath + "/Raw/levelScores.text";

        //Android için path
        //pathAndroid = "apk:file://" + Application.dataPath + "!/assets/" + "levelScores.json";

        //pathAndroid2 = "apk:file://" + Application.persistentDataPath + "!/assets/" + "levelScores.json";

        //pathIOS =Application.persistentDataPath + "/Raw/levelScores.json";


        //pathIOS = Application.persistentDataPath + "/var/mobile/Containers/Data/Application/<guid>/Documents";
        //pathAndroid = Application.persistentDataPath + "/storage/emulated/0/Android/data/<packagename>/files";

        // string scoreAndLevels = JsonUtility.ToJson(levelScore);
        //File.WriteAllText(path, scoreAndLevels);

        _path = Application.streamingAssetsPath + "/levelScores.text";
        UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(_path);
        www.SendWebRequest();
        while (!www.isDone) { }

        jsonString = www.downloadHandler.text;

        

    }


    public void clickAndSave()
    {
        // Skor dosyasini oku
        string fileContents = File.ReadAllText(path);

        // Skor dosyasindan obje yarat
        Dictionary<int, int> scoresObject = new Dictionary<int, int>();

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

        // Yeni leveli yaz, veya ekle
        if (scoresObject.ContainsKey(levelIndex+1))
        {
            var enYuksekDeger = scoresObject[levelIndex+1];
            var suAnkiDeger = swipteInput.scoreConverter;
            if (suAnkiDeger > enYuksekDeger)
            {
                //Debug.Log($"Yeni en yuksek deger, yasasin!" {suAnkiDeger});


                scoresObject[levelIndex+1] = swipteInput.scoreConverter;
            }

        }
        else
        {
            scoresObject.Add(levelIndex+1, swipteInput.scoreConverter);
        }

        // Yeni dosyaya yazilacak string
        var newFileContents = JsonConvert.SerializeObject(scoresObject);

        // Yeni dosyayi yaz
        File.WriteAllText(path, newFileContents);

        //UnityEngine.Networking.UnityWebRequest www2 = UnityEngine.Networking.UnityWebRequest.Post(_path, newFileContents);

        /*foreach (var kvp in scoresObject)
            Debug.Log(kvp.Key);

        Debug.Log(toplam);*/

    }

    public class LevelScoreSave
    {
        public int level;
        public int score;

        public LevelScoreSave(int level, int score)
        {
            this.level = level;
            this.score = score;
        }
    }
}