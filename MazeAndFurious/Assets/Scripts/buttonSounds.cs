using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonSounds : MonoBehaviour
{
    private AudioSource openMenuSound;
    private AudioSource kazanmaSound;
    private AudioSource saymaSound;
    private AudioSource gecisSound;

    public AudioClip openMenuClip;



    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            openMenuSound = GameObject.Find("menuAcilma").GetComponent<AudioSource>();
        }

        else if (SceneManager.GetActiveScene().name == "New Scene")
        {
            openMenuSound = GameObject.Find("menuAcilma").GetComponent<AudioSource>();
            kazanmaSound = GameObject.Find("kazanma").GetComponent<AudioSource>();
            saymaSound = GameObject.Find("sayma").GetComponent<AudioSource>();
        }

        else if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            openMenuSound = GameObject.Find("menuAcilma").GetComponent<AudioSource>();
            kazanmaSound = GameObject.Find("kazanma").GetComponent<AudioSource>();
            saymaSound = GameObject.Find("sayma").GetComponent<AudioSource>();
        }

        else if(SceneManager.GetActiveScene().name == "characterSelect")
        {
            openMenuSound = GameObject.Find("menuAcilma").GetComponent<AudioSource>();
            gecisSound = GameObject.Find("gecis").GetComponent<AudioSource>();
        }

    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (PlayerPrefs.GetInt("sound") == 1)
                openMenuSound.mute = true;
            else
                openMenuSound.mute = false;
        }

        else if (SceneManager.GetActiveScene().name == "characterSelect")
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                openMenuSound.mute = true;
                gecisSound.mute = true;
            }
            else
            {
                openMenuSound.mute = false;
                gecisSound.mute = false;
            }
        }

        else if (SceneManager.GetActiveScene().name == "New Scene")
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                openMenuSound.mute = true;
                saymaSound.mute = true;
                kazanmaSound.mute = true;
                
            }
            else
            {
                openMenuSound.mute = false;
                saymaSound.mute = false;
                kazanmaSound.mute = false;
            }
        }

        else if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                openMenuSound.mute = true;
                saymaSound.mute = true;
                kazanmaSound.mute = true;

            }
            else
            {
                openMenuSound.mute = false;
                saymaSound.mute = false;
                kazanmaSound.mute = false;
            }
        }
    }

    
    public void CloseSound()
    {
        openMenuSound.PlayOneShot(openMenuClip, 1);
    }

}
