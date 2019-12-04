using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Ovo pišemo kada hoćemo korisiti UI mogućnosti u kodu

public class Coin_Collector : MonoBehaviour
{
    // Broj koliko smo pokupili predmeta
    public int skupljeni_Coinsi;
    public int skupljeni_Artifakti;

    public Text textCoins;
    public Text textArtifakti;

    public AudioSource zvuk;

    int brojCoinsaNaSceni;

    void Start()
    {
        brojCoinsaNaSceni = GameObject.FindGameObjectsWithTag("Collectable").Length;
        textCoins.text = skupljeni_Coinsi + "/" + brojCoinsaNaSceni;
    }

    void OnTriggerEnter(Collider other)
    {
        //Ako objekt ima tag "Collectable" onda tek se izvršava ostatak
        if(other.gameObject.tag == "Collectable")
        {
            Destroy(other.gameObject); //Uništimo objekt koji pokupimo
            skupljeni_Coinsi++; //Povećaju nam se bodovi za 1
            textCoins.text = skupljeni_Coinsi + "/" + brojCoinsaNaSceni;
            zvuk.Play(); //Efekt da smo pokupili
        }
        else if(other.gameObject.tag == "Artifact")
        {
            Destroy(other.gameObject);
            skupljeni_Artifakti++;
            zvuk.Play();
        }
    }
}
