using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_21_PrviNacin : MonoBehaviour
{
    int random_broj_1;
    int random_broj_2;
    int zbroj;

    void Awake()
    {
        random_broj_1 = Random.Range(0, 34);
        random_broj_2 = Random.Range(0, 34);
    }

    void Start()
    {
        zbroj = random_broj_1 + random_broj_2;
    }
}
