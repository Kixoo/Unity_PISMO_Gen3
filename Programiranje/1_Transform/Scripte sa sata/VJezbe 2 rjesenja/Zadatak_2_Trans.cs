using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_2_Trans : MonoBehaviour
{
    float x = 0.1f;
    float y = 3f;

    void Start()
    {
        transform.localScale += new Vector3(0, y, 0);
    }

    void Update()
    {
        transform.localScale += new Vector3(x, 0, 0);
    }
    
}
