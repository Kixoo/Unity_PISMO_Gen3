using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_1 : MonoBehaviour
{
    // SKRIPTA KOJA NA KLIK SPACE UKLJUČI ILI ISKLJUČI GRAVITACIJU NA OBJEKTU

    public Rigidbody rb; //univerzalni naziv varijable Rigidbodya je rb
    bool changeGravity = true;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GravityHelloBye();
        }
    }

    void GravityHelloBye()
    {
        changeGravity = !changeGravity;
        rb.useGravity = changeGravity;
    }
}
