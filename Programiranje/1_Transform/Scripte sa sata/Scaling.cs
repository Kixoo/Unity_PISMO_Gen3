using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{
    //Ove varijable služe za uređivanje veličine
    public float xScale;
    public float yScale;
    public float zScale;

    //Ove varijable služe za uređivanje rotacije
    public float xRotate;
    public float yRotate;
    public float zRotate;

    void Update()
    {
        //Transform ce nam sada utjecati na onaj objekt na kojem se nalazi skripta
        transform.localScale += new Vector3(xScale, yScale, zScale);

        //Rotacija objekta!
        /* Vector3.Up - Rotacija po Y osi u smjeru kazaljke na satu
         * Vector3.Right - Rotacija po X osi u smjeru kazaljke na satu
         * Vector3.Foward - Rotacija po Z osi u smjeru kazaljke na satu
         * Suprotno
         * Vector3.Down - Rotacija po Y osi u suprtnom smjeru kazaljke na satu
         * Vector3.Left - Rotacija po X osi u suprtnom smjeru kazaljke na satu
         * Vector3.Back - Rotacija po Z osi u suprtnom smjeru kazaljke na satu
         */

        transform.Rotate(Vector3.up * yRotate);
        transform.Rotate(Vector3.right * xRotate);
        transform.Rotate(Vector3.forward * zRotate);
    }
}
