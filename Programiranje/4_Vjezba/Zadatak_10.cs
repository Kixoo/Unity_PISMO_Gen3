using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_10 : MonoBehaviour
{
    public float speed; //brzina kretanja
    public bool jelUšo; //provjera jel bio udar

    void Update()
    {
        if(jelUšo == false) //Ako nije bilo dodira
        {
            //Kreće se forward
            transform.position += new Vector3(0, 0, speed);
        }
        else //Ako je bilo dodira
        {
            //Kreće se backward (Vector3.back)
            transform.position -= new Vector3(0, 0, speed);
        }
    }

    //Kada dođu jedan do drugoga
    void OnTriggerEnter(Collider other)
    {
        jelUšo = true; //Mjenja se vrijednost provjere
    }
}
