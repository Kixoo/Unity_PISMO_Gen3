using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//SKRIPTA SE NALAZI NA BUTTONU NA UI-u

public class Space : MonoBehaviour
{
    public Text btnText; //Text koji se nalazi na buttonu
    Button btn; //Gumb/button na sceni, odnosno polje/space

    GameManager gameManager; //Pozvali smo klasu game maneger u našu skriptu "Space"

    void Start() //Dodjeljujemo vrijednosti
    {
        gameManager = FindObjectOfType<GameManager>(); //nadi game manger skriptu na sceni
        btn = GetComponent<Button>(); //Uzeli smo komponentu gumba
    }

    //Metoda se poziva kada kliknemo gumb, dakle treba biti dodjeljena na gumb te stavljena pod njegov "OnClick()"
    public void PostaviSimbol()
    {
        btnText.text = gameManager.GetSide(); //pozivamo metodu GetSide da nam kaže koji je aktivan X ili O
        btn.interactable = false; //Onemogućili smo daljnje iterakcije s gumbom
        gameManager.moves++; //Dodaj potez
        gameManager.EndGame(); //Provjera jel kraj igre
    }
}
