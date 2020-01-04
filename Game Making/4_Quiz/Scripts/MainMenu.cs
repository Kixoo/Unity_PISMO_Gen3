using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioSource audio;
    public Slider slider;

    public void Start()
    {
        slider.value = audio.volume;
    }

    public void SetVolume()
    {
        audio.volume = slider.value;
    }

    public void Quit()
    {
        Debug.Log("Izlaz iz aplikacije");
        Application.Quit();
    }

    public void HighScoreLoad()
    {
        //Priprema za učitavanje highscorea

    }
}
