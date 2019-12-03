using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_1_Trans : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime);
        transform.Rotate(Vector3.right * Time.deltaTime);
    }
}
