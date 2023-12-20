using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonSounder : MonoBehaviour
{
    public AudioClip sound;

    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
        
        button.onClick.AddListener(() => ButtonSound());

        
    }

    public void ButtonSound()
    {
        source.PlayOneShot(sound,0.75f);
       
    }
    
}
