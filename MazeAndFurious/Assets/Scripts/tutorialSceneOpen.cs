using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialSceneOpen : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("tutorial") == 0)
            SceneManager.LoadScene("Tutorial");
    }
}
