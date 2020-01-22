using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceResolution : MonoBehaviour
{
    private void Start()
    {
        //Skripta radi samo za build
        //postavili smo rezoluciju na 1280x720 koja je fullscreen
        Screen.SetResolution(1280, 720, true);  
    }
}
