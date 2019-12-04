using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Collector : MonoBehaviour
{
    // Broj koliko smo pokupili predmeta
    public int skupljenih_Objekata;
    public AudioSource zvuk;

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject); //Uništimo objekt koji pokupimo
        skupljenih_Objekata++; //Povećaju nam se bodovi za 1
        zvuk.Play(); //Efekt da smo pokupili
    }
}
