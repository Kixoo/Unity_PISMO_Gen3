using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_3_Mono : MonoBehaviour
{
    public Color color1;
    void Awake()
    {
        Debug.Log("Ovo je Awake!");
    }
    void Start()
    {
        Debug.Log("Pokusao sam kopirat ovo");
    }
    void Update()
    {
        Debug.Log("<color=color1>Ovo je Update!</color>");
    }
}
