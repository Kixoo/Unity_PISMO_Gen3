using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_24 : MonoBehaviour
{
    public Light svijetlo;

    public bool lightOn;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ToggleLight();
        }
    }

    void ToggleLight()
    {
        // !bool => suprotna vrijednost, ako je bilo true sada je false, ako je false sada je true
        lightOn = !lightOn;
        svijetlo.enabled = lightOn;
    }
}
