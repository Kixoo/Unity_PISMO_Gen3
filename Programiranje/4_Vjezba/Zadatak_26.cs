using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_26 : MonoBehaviour
{
    public AudioSource zvuk;

    void Update()
    {
        /*
         * GetMouseButton(0) - lijevi klik miša
         * GetMouseButton(1) - desni klik miša
         * GetMouseButton(2) - srednji(scroll) klik miša
         */

        if(Input.GetMouseButtonDown(0))
        {
            zvuk.Play();
        }
    }
}
