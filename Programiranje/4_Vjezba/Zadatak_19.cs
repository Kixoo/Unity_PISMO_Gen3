using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_19 : MonoBehaviour
{
    int counter = 15;
    public string ime;
    public string prezime;

    void Start()
    {
        while(counter > 0)
        {
            Debug.Log("Ja sam " + ime + " " + prezime);
            counter--;
        }
    }
}
