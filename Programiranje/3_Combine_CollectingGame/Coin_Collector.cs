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
    int brojArtifekataNaSceni;

    void Start()
    {
        //Traženje objekata na sceni sa tagom "Collectable" i zapisivanje koliko ih ima brojčano (Lenght)
        brojCoinsaNaSceni = GameObject.FindGameObjectsWithTag("Collectable").Length;
        //Pisanje texta na UI => 0/3
        textCoins.text = skupljeni_Coinsi + "/" + brojCoinsaNaSceni;
        brojCoinsaNaSceni = GameObject.FindGameObjectsWithTag("Artifact").Length;
        textArtifakti.text = skupljeni_Artifakti + "/" + brojArtifekataNaSceni;
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
            textCoins.text = skupljeni_Artifakti + "/" + brojArtifekataNaSceni;
            zvuk.Play();
        }
    }

    void Update()
    {
        //Što da se dogodi kada pokupimo sve coinse i artifekte
        if(skupljeni_Coinsi == brojCoinsaNaSceni && skupljeni_Artifakti == brojArtifekataNaSceni)
        {
            //Application.Quit ne radi u Unity nego tek u buildanom proizvodu
            Application.Quit(); //exe. file se ugasi
        }
    }
}
