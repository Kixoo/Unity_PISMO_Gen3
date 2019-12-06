using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_2 : MonoBehaviour
{
    // SKRIPTA KOJA OBJEKT KRECE PO X OSI UZ POMOĆ SILE (add force)
    public float brzina;
    Rigidbody rb;

    void Start()
    {
        //Nismo rb stavili public, ali dodjelujemo preko skripte da uzme komponentu Rigidbody sa objekta na kojemu je skripta
        rb = GetComponent<Rigidbody>();
    }

    //Kada radimo sa silom koristimo Fixedupdate, a ne obicni Update
    void FixedUpdate()
    {
        rb.AddForce(transform.right * brzina);
    }
}
