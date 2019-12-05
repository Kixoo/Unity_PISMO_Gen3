using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_2 : MonoBehaviour
{
    public int x; //prvi broj
    public int y; //Drugi broj
    public int rezultat; //Rezultat

    void Update() // Metoda u kojoj se množi i ispusuje u konzolu
    {
        rezultat = x * y; //Dobivanje umnožka
        Debug.Log("Rezultat je: " + rezultat); //Ispis rezultata u konzolu
    }
}
