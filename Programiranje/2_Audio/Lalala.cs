/*
a. na klik "space" povećati kocku po Z i Y osi za veličinu X osi 

b. na klik "space" pokrenuti zvuk u pozadini 

c. Z i Y imaju maksimalnu veličinu 20 

d. ako jedan od Z ili Y osi dođe do 20, zaključava se povećavanje na space 

e. Neka u svaki void bude napisan debug 

f. Neka postoji "OnTriggerEnter" sa nekim drugim objektom nakon cega ce se destroyati 

g. na klik slova „z“ pauzirati zvuk 

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lalala : MonoBehaviour
{
    //a.
    float xScale;
    public AudioSource zvuk;

    void Start()
    {
        //a.
        xScale = transform.localScale.x; //Saznali smo koliko je na samome startu veličina x
        //e.
        Debug.Log("Start!");
    }

    void Update()
    {
        //e.
        Debug.Log("Update!");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //b.
            zvuk.Play();
            //c. & d.
            if(transform.localScale.y <= 20 || transform.localScale.z <= 20)
            {
                //a.
                transform.localScale += new Vector3(0, xScale, xScale);
            }
            if(transform.localScale.y + xScale >= 20)
            {
                transform.localScale = new Vector3(0, 20, 0);
            }
            if(transform.localScale.z + xScale >= 20)
            {
                transform.localScale = new Vector3(0, 0, 20);
            }
        }

        //g.
        if(Input.GetKeyDown(KeyCode.Z))
        {
            zvuk.Pause();
        }
    }

    //f.
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        //e.
        Debug.Log("Trigger!");
    }

}
