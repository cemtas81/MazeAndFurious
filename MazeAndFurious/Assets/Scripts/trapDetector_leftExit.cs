﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

public class trapDetector_leftExit : MonoBehaviour
{
    public GameObject changePos;
    public GameObject changeChar;

    private void Start()
    {
        changeChar.transform.position = changePos.transform.position;   
    }
}
