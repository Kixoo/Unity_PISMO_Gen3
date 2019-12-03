using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Script : MonoBehaviour
{
    public AudioSource audioS;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)) //Kada pritisnemo tipku S na tipkovnici
        {
            audioS.Play(); //Pokrećemo audio (početak)
        }
        if (Input.GetKeyDown(KeyCode.P)) //Kada pritisnemo tipku P na tipkovnici
        {
            audioS.Pause(); //Pauziramo audio
        }
        if (Input.GetKeyDown(KeyCode.U)) //Kada pritisnemo tipku U na tipkovnici
        {
            audioS.UnPause(); //Pokrećemo od kud smo stali audio
        }
        if (Input.GetKeyDown(KeyCode.M)) //Kada pritisnemo tipku M na tipkovnici
        {
            if(audioS.mute == true)
            {
                audioS.mute = false; //Gasimo audio zvuk, ali se "traka" vrti i dalje
            }
            else
            {
                audioS.mute = true; //Palimo audio zvuk, ali se "traka" vrti i dalje
            }
        }
        if (Input.GetKeyDown(KeyCode.T)) //Kada pritisnemo tipku T na tipkovnici
        {
            audioS.Stop(); //Zaustavljamo i resetiramo audio
        }
    }
}
