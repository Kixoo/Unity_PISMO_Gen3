using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_3_Trans : MonoBehaviour
{
    public float xScale;
    public float yScale;
    public float zScale;
    public float xRotate;
    public float yRotate;
    public float zRotate;

    void Update()
    {
        transform.Rotate(Vector3.right * xRotate);
        transform.Rotate(Vector3.up * yRotate);
        transform.Rotate(Vector3.forward * zRotate);

        if (transform.localScale.x < 10 && transform.localScale.y < 10 && transform.localScale.z < 10)
        {
            transform.localScale += new Vector3(xScale, yScale, zScale);
        }
        else if(transform.localScale.x > 10 || transform.localScale.y > 10 || transform.localScale.z < 10)
        {
            transform.localScale -= new Vector3(xScale, yScale, zScale);
        }
    }
}
