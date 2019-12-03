using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSource_Zadatak3 : MonoBehaviour
{
    AudioSource audioS; //Kako dodjeliti ako nije public?
    int frameCounter = 0;

    void Start()
    {
        audioS = GetComponent<AudioSource>(); //DODJELJIVANJE KOMPONENTE SA ISTOG OBJEKTA NA KOJEM JE I SKRIPTA
    }

    void Update()
    {
        if(frameCounter == 5) // kada prođe pet frameova pauziraj, zvuk mora biti Play On Awake na audio sourceu
        {
            audioS.Pause();
        }
        else if(frameCounter == 10) // kada dođe na 10 frameova unpauziraj i resetiraj broj frameova
        {
            audioS.UnPause();
            frameCounter = 0;
        }
        frameCounter++;
    }
}
