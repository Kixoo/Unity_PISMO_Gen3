using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject areYouSure;

    [Header("Audio Stuff")]
    public AudioSource[] audio;
    public Slider slider;

    [Header("ScoreManager")]
    public int score;
    public Text ScoreText;

    private void Start()
    {
        areYouSure.SetActive(false); //Postavi areyou sure object u false
        slider.value = PlayerPrefs.GetFloat("PlayerVolume"); //Povuci iz player prefsa vrijednost
        for(int i = 0; i < audio.Length; i++)
        {
            audio[i].volume = slider.value; //dodjeli zvuku vrijednost iz player prefsa
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CheckExit();
        }
    }

    //Ako stisnes gumb za exit aktviraj game object za upit
    public void CheckExit()
    {
        areYouSure.SetActive(true);
    }

    //Izađi iz app
    public void QuitApp()
    {
        Application.Quit();
    }

    //Postavi vrijednost zvuka (Na slideru pod sekcijom "On Change Value")
    public void SetVolume()
    {
        for (int i = 0; i < audio.Length; i++)
        {
            audio[i].volume = slider.value; //dodjeli zvuku vrijednost iz player prefsa
            PlayerPrefs.SetFloat("PlayerVolume", audio[i].volume);
        }
    }

    public void HighScoreLoad()
    {
        //Priprema za učitavanje highscorea
    }
}
