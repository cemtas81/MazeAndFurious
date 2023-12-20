using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.IO;
using Newtonsoft.Json;
using System;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class map_creator : MonoBehaviour
{
    public GameObject kup_go;

    static public int oneCounter;

    public GameObject wallPrefab;

    private GameObject wall_go;

    public GameObject floor_prefab;

    private GameObject floor_Go;

    public GameObject kazikTuzak_prefab;

    private GameObject kazikTuzak_Go;

    public GameObject agac_Prefab;

    private GameObject agac_Go;

    public GameObject agac2_Prefab;

    private GameObject agac2_Go;

    public GameObject cicek_Prefab;

    private GameObject cicek_Go;

    public GameObject tas_Prefab;
    private GameObject tas_Go;

    public GameObject cimen_Prefab;
    private GameObject cimen_Go;

    public GameObject anahtar_Prefab;
    private GameObject anahtar_Go;

    static public int lastCounter;
    public int trapCounter;

    private string path;
    private string path2;

    public static HashSet<Tuple<int, int>> floorCoordinates;

    public static GameObject[] floor = new GameObject[625];

    public int[] agac = new int[625];
    List<int> agacList = new List<int>(new int[625]);
    public int[] deneme;

    public int lastLevel;

    private int[] a;
    private int[] b;


    public int near;
    public int far;

    public Vector3 cameraAngle;

    public Camera cmr;

    public int yerlertir;

    private int[] randomList = new int[25];
    private int[] randomList2 = new int[25];
    private int[] randomList3 = new int[25];
    private int[] randomList4 = new int[25];
    private int[] randomList5 = new int[25];

    int saydir = 12;
    int saydir2 = 3;
    int saydir3 = 0;
    int saydir4 = 24;

    public Transform dummy;
    private int totalKey;
    private int openKeyMap;

    public GameObject[] duvarPrefab = new GameObject[10];
    public GameObject[] zeminPrefab = new GameObject[10];

    private int zemin = 0;
    private int duvar = 0;

    
    private void Awake()
    {
        for (int b = 0; b < 25; b++)
            randomList[b] = Random.Range(0, 24);

        for (int c = 0;  c < 25; c++)
            randomList2[c] = Random.Range(0, 24);

        for (int d = 0; d < 25; d++)
            randomList3[d] = Random.Range(0, 24);

        for (int c = 0; c < 25; c++)
            randomList4[c] = Random.Range(0, 24);

        for (int d = 0; d < 25; d++)
            randomList5[d] = Random.Range(0, 24);

    }
    public void deneme123()
    {
        duvar = PlayerPrefs.GetInt("duvar");
        zemin = PlayerPrefs.GetInt("zemin");
        zemin += 1;
        duvar += 1;
        PlayerPrefs.SetInt("zemin", zemin);
        PlayerPrefs.SetInt("duvar", duvar);
        if (PlayerPrefs.GetInt("duvar") == 10 || PlayerPrefs.GetInt("zemin") == 10)
        {
            PlayerPrefs.SetInt("zemin", 0);
            PlayerPrefs.SetInt("duvar", 0);
        }
    }
    public void Start()
    {
        GameObject.Find("MapCreator (1)").GetComponent<map_creator>().wallPrefab = duvarPrefab[PlayerPrefs.GetInt("duvar")];
        GameObject.Find("MapCreator (1)").GetComponent<map_creator>().floor_prefab = zeminPrefab[PlayerPrefs.GetInt("zemin")];

       
        DOTween.Init();

        floorCoordinates = new HashSet<Tuple<int, int>>();
        

        Application.targetFrameRate = 300;
        kup_go.SetActive(true);

        totalKey = PlayerPrefs.GetInt("totalKey");
        lastLevel = PlayerPrefs.GetInt("lastLevel");

        if (PlayerPrefs.GetInt("ekstra") == 1)
            openKeyMap = ((lastLevel + 1) / 5) + 600;
        if (PlayerPrefs.GetInt("ekstra") == 2)
            openKeyMap = ((lastLevel + 1) / 5) + 1200;
        if (PlayerPrefs.GetInt("ekstra") == 3)
            openKeyMap = ((lastLevel + 1) / 5) + 1800;
        if (PlayerPrefs.GetInt("ekstra") == 4)
            openKeyMap = ((lastLevel + 1) / 5) + 2400;
        if (PlayerPrefs.GetInt("ekstra") == 5)
            openKeyMap = ((lastLevel + 1) / 5) + 3000;
        if (PlayerPrefs.GetInt("ekstra") == 6)
            openKeyMap = ((lastLevel + 1) / 5) + 3600;
        else
            openKeyMap = (lastLevel + 1) / 5;

        if (lastLevel > 4000 && PlayerPrefs.GetInt("ekstra") == 0)
        {
            PlayerPrefs.SetInt("lastLevel", 1000);
            PlayerPrefs.SetInt("ekstra", 1);
        }
        else if (lastLevel > 4000 && PlayerPrefs.GetInt("ekstra") == 2)
        {
            PlayerPrefs.SetInt("lastLevel", 1000);
        }
        else if (lastLevel > 4000 && PlayerPrefs.GetInt("ekstra") == 3)
        {
            PlayerPrefs.SetInt("lastLevel", 1000);
        }
        else if (lastLevel > 4000 && PlayerPrefs.GetInt("ekstra") == 4)
        {
            PlayerPrefs.SetInt("lastLevel", 1000);
        }
        else if (lastLevel > 4000 && PlayerPrefs.GetInt("ekstra") == 5)
        {
            PlayerPrefs.SetInt("lastLevel", 1000);
        }
        else if (lastLevel > 4000 && PlayerPrefs.GetInt("ekstra") == 6)
        {
            PlayerPrefs.SetInt("lastLevel", 1000);
        }



#if UNITY_EDITOR
        if (SceneManager.GetActiveScene().name == "New Scene")
        {
            string json = File.ReadAllText(Application.dataPath + "/StreamingAssets/" + PlayerPrefs.GetInt("lastLevel") + ".text");
            a = Newtonsoft.Json.JsonConvert.DeserializeObject<int[]>(json);
        }
        else if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            string json = File.ReadAllText(Application.dataPath + "/StreamingAssets/" + "tutorial" + ".text");
            a = Newtonsoft.Json.JsonConvert.DeserializeObject<int[]>(json);
        }

        if ((lastLevel + 1) % 5 == 0 && openKeyMap != totalKey)
        {
            string json2 = File.ReadAllText(Application.dataPath + "/StreamingAssets/" + PlayerPrefs.GetInt("lastLevel") + "detail" + ".text");
            b = Newtonsoft.Json.JsonConvert.DeserializeObject<int[]>(json2);
        }
#elif UNITY_ANDROID
        if (SceneManager.GetActiveScene().name == "New Scene" || SceneManager.GetActiveScene().name == "1" || SceneManager.GetActiveScene().name == "2" || SceneManager.GetActiveScene().name == "3")
        {
            var _path = Application.streamingAssetsPath + "/"+ lastLevel + ".text";
            UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(_path);
            www.SendWebRequest();
            while (!www.isDone) { }

            String jsonString = www.downloadHandler.text;
            a = Newtonsoft.Json.JsonConvert.DeserializeObject<int[]>(jsonString);
        }

        else if(SceneManager.GetActiveScene().name == "Tutorial")
        {
            var _path = Application.streamingAssetsPath + "/"+ "tutorial" + ".text";
            UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(_path);
            www.SendWebRequest();
            while (!www.isDone) { }

            String jsonString = www.downloadHandler.text;
            a = Newtonsoft.Json.JsonConvert.DeserializeObject<int[]>(jsonString);
        }

        if ((lastLevel + 1) % 5 == 0 && openKeyMap != PlayerPrefs.GetInt("totalKey"))
        {var _path2 = Application.streamingAssetsPath + "/"+ lastLevel + "detail" + ".text";
        UnityEngine.Networking.UnityWebRequest www2 = UnityEngine.Networking.UnityWebRequest.Get(_path2);
        www2.SendWebRequest();
        while (!www2.isDone) { }

        String jsonString2 = www2.downloadHandler.text;
        b = Newtonsoft.Json.JsonConvert.DeserializeObject<int[]>(jsonString2);
        }

#elif UNITY_IOS
        if (SceneManager.GetActiveScene().name == "New Scene")
        {
            path = File.ReadAllText(Application.dataPath + "/Raw/" + lastLevel + ".text");
            a = Newtonsoft.Json.JsonConvert.DeserializeObject<int[]>(path);
        }

        else if(SceneManager.GetActiveScene().name == "Tutorial")
        {
            path = File.ReadAllText(Application.dataPath + "/Raw/" + "tutorial" + ".text");
            a = Newtonsoft.Json.JsonConvert.DeserializeObject<int[]>(path);
        }

        if ((lastLevel + 1) % 5 == 0 && openKeyMap != totalKey)
        {
            path2 = File.ReadAllText(Application.dataPath + "/Raw/" + lastLevel + "detail" + ".text");
            b = JsonConvert.DeserializeObject<int[]>(path2);
        }
#endif

        //text dosyasından alınan sayıları haritalamda kullanır.
        //-1 karakterin yerleşeceği yeri
        //0 duvarı
        //1 zemini
        //2 tuzakları
        //8 ve 9 haritanın aralığını belirler.

        for (int i = 0; i < 25; i++)
        {
            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                //GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall_go.transform.position = new Vector3(i, 0.5f, 0);
            }
        }


        for (int i = 25; i < 50; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 25, 0.5f, 1);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 25, 0, 1);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 25, 0.5f, 1);
            }

            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 25, 0, 1);
                floor[i] = floor_Go;
            }

            else if(a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 25, 0.5f, 1);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 25, 0, 1);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 25, 0, 1);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

        }

        for (int i = 50; i < 75; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 50, 0.5f, 2);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 50, 0, 2);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 50, 0.5f, 2);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 50, 0, 2);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 50, 0.5f, 2);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 50, 0, 2);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 50, 0, 2);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }

        for (int i = 75; i < 100; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 75, 0.5f, 3);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 75, 0, 3);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }
            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 75, 0.5f, 3);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 75, 0, 3);
                floor[i] = floor_Go;
                oneCounter++;
            }

            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 75, 0.5f, 3);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 75, 0, 3);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 75, 0, 3);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }

        for (int i = 100; i < 125; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 100, 0.5f, 4);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 100, 0, 4);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 100, 0.5f, 4);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 100, 0, 4);
                floor[i] = floor_Go;
                oneCounter++;
            }

            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 100, 0.5f, 4);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 100, 0, 4);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 100, 0, 4);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }
        for (int i = 125; i < 150; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 125, 0.5f, 5);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 125, 0, 5);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 125, 0.5f, 5);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 125, 0, 5);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 125, 0.5f, 5);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 125, 0, 5);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 125, 0, 5);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }
        for (int i = 150; i < 175; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 150, 0.5f, 6);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 150, 0, 6);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 150, 0.5f, 6);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 150, 0, 6);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 150, 0.5f, 6);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 150, 0, 6);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 150, 0, 6);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }
        for (int i = 175; i < 200; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 175, 0.5f, 7);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 175, 0, 7);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 175, 0.5f, 7);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 175, 0, 7);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 175, 0.5f, 7);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 175, 0, 7);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 175, 0, 7);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }
        for (int i = 200; i < 225; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 200, 0.5f, 8);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 200, 0, 8);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 200, 0.5f, 8);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 200, 0, 8);
                floor[i] = floor_Go;
                oneCounter++;

            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 200, 0.5f, 8);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 200, 0, 8);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i -200, 0, 8);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }
        for (int i = 225; i < 250; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 225, 0.5f, 9);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 225, 0, 9);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 225, 0.5f, 9);
                
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 225, 0, 9);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 225, 0.5f, 9);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 225, 0, 9);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 225, 0, 9);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }
        for (int i = 250; i < 275; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 250, 0.5f, 10);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 250, 0, 10);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 250, 0.5f, 10);
                
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 250, 0, 10);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 250, 0, 10);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 250, 0, 10);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 250, 0, 10);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }
        for (int i = 275; i < 300; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 275, 0.5f, 11);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 275, 0, 11);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 275, 0.5f, 11);
               
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 275, 0, 11);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 275, 0.5f, 11);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 275, 0, 11);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 275, 0, 11);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }
        for (int i = 300; i < 325; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 300, 0.5f, 12);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 300, 0, 12);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 300, 0.5f, 12);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 300, 0, 12);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 300, 0.5f, 12);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 300, 0, 12);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 300, 0, 12);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }
        for (int i = 325; i < 350; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 325, 0.5f, 13);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 325, 0, 13);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 325, 0.5f, 13);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 325, 0, 13);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 325, 0.5f, 13);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 325, 0, 13);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 325, 0, 13);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }
        for (int i = 350; i < 375; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 350, 0.5f, 14);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 350, 0, 14);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 350, 0.5f, 14);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 350, 0, 14);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 350, 0.5f, 14);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 350, 0, 14);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 350, 0, 14);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }
        for (int i = 375; i < 400; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 375, 0.5f, 15);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 375, 0, 15);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 375, 0.5f, 15);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 375, 0, 15);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 375, 0.5f, 15);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 375, 0, 15);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 375, 0, 15);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }
        for (int i = 400; i < 425; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 400, 0.5f, 16);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 400, 0, 16);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 400, 0.5f, 16);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 400, 0, 16);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 400, 0.5f, 16);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 400, 0, 16);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 400, 0, 16);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }
        for (int i = 425; i < 450; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 425, 0.5f, 17);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 425, 0, 17);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 425, 0.5f, 17);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 425, 0, 17);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 425, 0.5f, 17);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 425, 0, 17);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 425, 0, 17);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }
        for (int i = 450; i < 475; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 450, 0.5f, 18);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 450, 0, 18);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 450, 0.5f, 18);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 450, 0, 18);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 450, 0.5f, 18);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 450, 0, 18);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 450, 0, 18);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }
        for (int i = 475; i < 500; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 475, 0.5f, 19);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 475, 0, 19);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 475, 0.5f, 19);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 475, 0, 19);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 475, 0.5f, 19);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 475, 0, 19);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 475, 0, 19);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }

        for (int i = 500; i < 525; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 500, 0.5f, 20);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 500, 0, 20);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 500, 0.5f, 20);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 500, 0, 20);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 500, 0.5f, 20);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 500, 0, 20);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 500, 0, 20);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }

        for (int i = 525; i < 550; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 525, 0.5f, 21);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 525, 0, 21);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 525, 0.5f, 21);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 525, 0, 21);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 525, 0.5f, 21);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 525, 0, 21);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 525, 0.5f, 21);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }
        for (int i = 550; i < 575; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 550, 0.5f, 22);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 550, 0, 22);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 550, 0.5f, 22);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 550, 0, 22);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 550, 0.5f, 22);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 550, 0, 22);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 550, 0, 22);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }

        for (int i = 575; i < 600; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 575, 0.5f, 23);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 575, 0, 23);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 575, 0.5f, 23);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 575, 0, 23);
                floor[i] = floor_Go;
                oneCounter++;
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 575, 0.5f, 23);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 575, 0, 23);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 575, 0, 23);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }

        for (int i = 600; i < 625; i++)
        {
            if (a[i] == -1)
            {
                kup_go.transform.position = new Vector3(i - 600, 0.5f, 24);
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 600, 0, 24);
                floor_Go.GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0);
                floor[i] = floor_Go;
            }

            if (a[i] == 0)
            {
                wall_go = Instantiate(wallPrefab, transform);
                wall_go.transform.position = new Vector3(i - 600, 0.5f, 24);
            }
            else if (a[i] == 1)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 600, 0, 24);
                floor[i] = floor_Go;
                oneCounter++;

                
            }
            else if (a[i] == 2)
            {
                kazikTuzak_Go = Instantiate(kazikTuzak_prefab, transform);
                kazikTuzak_Go.transform.position = new Vector3(i - 600, 0.5f, 24);
                trapCounter++;
            }

            else if (a[i] == 8)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 600, 0, 24);
                near = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }

            else if (a[i] == 9)
            {
                floor_Go = Instantiate(floor_prefab, transform);
                floor_Go.transform.position = new Vector3(i - 600, 0, 24);
                far = Mathf.RoundToInt(floor_Go.transform.position.x);
                floor[i] = floor_Go;
            }
        }


        ////////////////////////////                   \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ////////////////////////////PLANT TEXT POSITION\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ////////////////////////////                    \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        if ((lastLevel + 1) % 5 == 0 && openKeyMap != PlayerPrefs.GetInt("totalKey"))
        {
            for (int i = 0; i < 25; i++)
            {

                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i, 3.91f, 0);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i, 3.7f, 0);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i, 1.5f, 0);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i, 0.75f, 0);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i, 1, 0);
                }
                else
                    continue;

            }


            for (int i = 25; i < 50; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 25, 3.91f, 1);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 25, 3.7f, 1);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 25, 1.5f, 1);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 25, 0.75f, 1);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 25, 1, 1);
                }

            }

            for (int i = 50; i < 75; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 50, 3.91f, 2);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 50, 3.7f, 2);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 50, 1.5f, 2);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 50, 0.75f, 2);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 50, 1, 2);
                }
            }

            for (int i = 75; i < 100; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 75, 3.91f, 3);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 75, 3.7f, 3);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 75, 1.5f, 3);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 75, 0.75f, 3);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 75, 1, 3);
                }
            }

            for (int i = 100; i < 125; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 100, 3.91f, 4);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 100, 3.7f, 4);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 100, 1.5f, 4);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 100, 0.75f, 4);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 100, 1, 4);
                }
            }
            for (int i = 125; i < 150; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 125, 3.91f, 5);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 125, 3.7f, 5);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 125, 1.5f, 5);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 125, 0.75f, 5);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 125, 1, 5);
                }
            }
            for (int i = 150; i < 175; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 150, 3.91f, 6);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 150, 3.7f, 6);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 150, 1.5f, 6);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 150, 0.75f, 6);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 150, 1, 6);
                }
            }
            for (int i = 175; i < 200; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 175, 3.91f, 7);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 175, 3.7f, 7);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 175, 1.5f, 7);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 175, 0.75f, 7);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 175, 1, 7);
                }
            }
            for (int i = 200; i < 225; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 200, 3.91f, 8);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 200, 3.7f, 8);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 200, 1.5f, 8);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 200, 0.75f, 8);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 200, 1, 8);
                }
            }
            for (int i = 225; i < 250; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 225, 3.91f, 9);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 225, 3.7f, 9);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 225, 1.5f, 9);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 225, 0.75f, 9);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 225, 1, 9);
                }
            }
            for (int i = 250; i < 275; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 250, 3.91f, 10);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 250, 3.7f, 10);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 250, 1.5f, 10);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 250, 0.75f, 10);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 250, 1, 10);
                }
            }
            for (int i = 275; i < 300; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 275, 3.91f, 11);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 275, 3.7f, 11);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 275, 1.5f, 11);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 275, 0.75f, 11);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 275, 1, 11);
                }
            }
            for (int i = 300; i < 325; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 300, 3.91f, 12);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 300, 3.7f, 12);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 300, 1.5f, 12);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 300, 0.75f, 12);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 300, 1, 12);
                }
            }
            for (int i = 325; i < 350; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 325, 3.91f, 13);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 325, 3.7f, 13);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 325, 1.5f, 13);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 325, 0.75f, 13);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 325, 1, 13);
                }
            }
            for (int i = 350; i < 375; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 350, 3.91f, 14);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 350, 3.7f, 14);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 350, 1.5f, 14);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 350, 0.75f, 14);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 350, 1, 14);
                }
            }
            for (int i = 375; i < 400; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 375, 3.91f, 15);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 375, 3.7f, 15);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 375, 1.5f, 15);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 375, 0.75f, 15);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 375, 1, 15);
                }
            }
            for (int i = 400; i < 425; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 400, 3.91f, 16);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 400, 3.7f, 16);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 400, 1.5f, 16);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 400, 0.75f, 16);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 400, 1, 16);
                }
            }
            for (int i = 425; i < 450; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 425, 3.91f, 17);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 425, 3.7f, 17);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 425, 1.5f, 17);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 425, 0.75f, 17);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 425, 1, 17);
                }
            }
            for (int i = 450; i < 475; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 450, 3.91f, 18);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 450, 3.7f, 18);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 450, 1.5f, 18);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 450, 0.75f, 18);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 450, 1, 18);
                }
            }
            for (int i = 475; i < 500; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 475, 3.91f, 19);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 475, 3.7f, 19);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 475, 1.5f, 19);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 475, 0.75f, 19);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 475, 1, 19);
                }
            }

            for (int i = 500; i < 525; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 500, 3.91f, 20);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 500, 3.7f, 20);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 500, 1.5f, 20);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 500, 0.75f, 20);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 500, 1, 20);
                }
            }

            for (int i = 525; i < 550; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 525, 3.91f, 21);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 525, 3.7f, 21);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 525, 1.5f, 21);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 525, 0.75f, 21);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 525, 1, 21);
                }
            }
            for (int i = 550; i < 575; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 550, 3.91f, 22);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 550, 3.7f, 22);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 550, 1.5f, 22);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 550, 0.75f, 22);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 550, 1, 22);
                }
            }

            for (int i = 575; i < 600; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 575, 3.91f, 23);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 575, 3.7f, 23);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 575, 1.5f, 23);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 575, 0.75f, 23);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 575, 1, 23);
                }
            }

            for (int i = 600; i < 625; i++)
            {
                if (b[i] == 1)
                {
                    agac_Go = Instantiate(agac_Prefab, transform);
                    agac_Go.transform.position = new Vector3(i - 600, 3.91f, 24);
                }

                else if (b[i] == 2)
                {
                    agac2_Go = Instantiate(agac2_Prefab, transform);
                    agac2_Go.transform.position = new Vector3(i - 600, 3.7f, 24);
                }

                else if (b[i] == 3)
                {
                    cimen_Go = Instantiate(cimen_Prefab, transform);
                    cimen_Go.transform.position = new Vector3(i - 600, 1.5f, 24);
                }

                else if (b[i] == 4)
                {
                    tas_Go = Instantiate(tas_Prefab, transform);
                    tas_Go.transform.position = new Vector3(i - 600, 0.75f, 24);
                }

                else if (b[i] == 5)
                {
                    anahtar_Go = Instantiate(anahtar_Prefab, transform);
                    anahtar_Go.transform.position = new Vector3(i - 600, 1, 24);
                }
            }
        }
        

        //8 ve 9 un farkını alır.
        lastCounter = trapCounter;
        print(lastCounter);
        int distance = (far - near) + 1;
        Debug.Log("distance : " + distance);



        /* for (int x = 25; x <= 624; x++)
         {
             if (a[x] == 1 && a[x + 25] == 0 && a[x-25] == 0)
             {
                 int say = 3;
                 agac_Go = Instantiate(agac_Prefab, transform);
                 agac_Go.transform.position = new Vector3(Mathf.RoundToInt((x + 25) / 25), 3.91f, Mathf.RoundToInt(((x + 25) / 25))+1);
                 say--;
                 if (say <= 0)
                     break;
                // agac_Go = Instantiate(agac_Prefab, transform);
                // agac_Go.transform.position = new Vector3(randomList[saydir4], 3.91f, Mathf.RoundToInt((x - 25) / 25));
                 //agac[Mathf.RoundToInt((saydir * 2) * 25 + randomList[saydir])] = 1;

                 agac2_Go = Instantiate(agac2_Prefab, transform);
                 agac2_Go.transform.position = new Vector3(randomList2[saydir4], 3.51f, x / 25);

                 tas_Go = Instantiate(tas_Prefab, transform);
                 tas_Go.transform.position = new Vector3(randomList4[saydir4], 0.75f, x / 25);

                 cimen_Go = Instantiate(cimen_Prefab, transform);
                 cimen_Go.transform.position = new Vector3(randomList5[saydir4], 1.5f, x / 25);


                 saydir4--;

                 saydir--;

                 saydir2--;

                 if (saydir <= 0)
                     break;
             }
         }*/


        foreach (int j in agac)
            Debug.Log(j);

        /*if (distance <= 7)
            cmr.GetComponent<Transform>().position = new Vector3(12, 67, -33);
        else if(distance >=8 && distance <= 10)
            cmr.GetComponent<Transform>().position = new Vector3(11.6f, 80, -42);
        else if (distance >= 11 && distance <= 13)
            cmr.GetComponent<Transform>().position = new Vector3(12.3f, 100, -54);
        else if (distance >= 14 && distance <= 15)
            cmr.GetComponent<Transform>().position = new Vector3(12.3f, 120, -66);
        else if (distance >= 16 && distance <= 18)
            cmr.GetComponent<Transform>().position = new Vector3(12, 140, -78);
        else if (distance >= 19 && distance <= 20)
            cmr.GetComponent<Transform>().position = new Vector3(12, 160, -90);
        else if (distance >= 21 && distance <= 22)
            cmr.GetComponent<Transform>().position = new Vector3(12, 180, -102);*/

        /*if (distance <= 7)
            cmr.GetComponent<Camera>().orthographicSize = 11;
        else if (distance >= 8 && distance <= 10)
            cmr.GetComponent<Camera>().orthographicSize = 15;
        else if (distance >= 11 && distance <= 13)
            cmr.GetComponent<Camera>().orthographicSize = 17;
        else if (distance >= 14 && distance <= 15)
            cmr.GetComponent<Camera>().orthographicSize = 18;
        else if (distance >= 16 && distance <= 18)
            cmr.GetComponent<Camera>().orthographicSize = 22;
        else if (distance >= 19 && distance <= 20)
            cmr.GetComponent<Camera>().orthographicSize = 25;
        else if (distance >= 21 && distance <= 22)
            cmr.GetComponent<Camera>().orthographicSize = 27;*/


        //kamera açısı için ayarlamalar.
        int farDist = 24 - far;
        int fark = near - farDist;
        Debug.Log("fark : " + fark);
        if(fark >0)
        {
            cmr.GetComponent<Transform>().DOLocalMoveX((12+((fark)*0.5f)), 0);
        }
        else if(fark <0)
        {
            cmr.GetComponent<Transform>().DOLocalMoveX((12 - (-1 * (fark) * 0.5f)), 0);
        }
        else
            cmr.GetComponent<Transform>().DOLocalMoveX(12, 0);

        int screenWidth = (Screen.width * 2);
        int screenHeight = Screen.height;
        float screensize = Mathf.Round(screenWidth / screenHeight);
        Debug.Log("width:" + screenWidth + "," + "height:" + screenHeight + "," + "size" + screensize);
        if (screenWidth >= screenHeight)
        {
            cmr.GetComponent<Camera>().orthographicSize = Mathf.RoundToInt(screensize + distance + 2);
        }
        else if(screenWidth < screenHeight)
            cmr.GetComponent<Camera>().orthographicSize = Mathf.RoundToInt(screensize + distance + 4);
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {

            string flower_path = "Assets/StreamingAssets/" + PlayerPrefs.GetInt("lastLevel") + "detail" + ".text";
            if(!File.Exists(flower_path))
                File.Create(flower_path);

            RaycastHit hit;
            File.AppendAllText(flower_path, "[");

            for (int j=0;j<25;j++)
            {
                for (int i = 0; i < 25; i++)
                {
                    if (Physics.Raycast(dummy.position, dummy.forward, out hit, 10))
                    {
                        dummy.transform.position = new Vector3(i, 8, j);
                        Debug.DrawRay(dummy.position, dummy.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);


                        if (hit.collider.name == "agac2(Clone)")
                            File.AppendAllText(flower_path, "0" + ",");
                        else if (hit.collider.name == "agac(Clone)")
                            File.AppendAllText(flower_path, "0" + ",");
                        else if (hit.collider.name == "cimen_bitki_002(Clone)")
                            File.AppendAllText(flower_path, "0" + ",");
                        else if (hit.collider.name == "kayalar_002(Clone)")
                            File.AppendAllText(flower_path, "0" + ",");
                        else if (hit.collider.name == "cimliDuvar 1(Clone)")
                            File.AppendAllText(flower_path, "0" + ",");
                        else if (hit.collider.name == "ZZZemin(Clone)")
                            File.AppendAllText(flower_path, "0" + ",");
                        else if (hit.collider.name == "karakter_anim (1)")
                            File.AppendAllText(flower_path, "0" + ",");
                        else if (hit.collider.name == "GameObject (2)")
                            File.AppendAllText(flower_path, "5" + ",");
                        
                    }
                }
            }
            File.AppendAllText(flower_path, "0]");
        }

    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

}

