using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_8 : MonoBehaviour
{
    float xStartScale;

    void Start()
    {
        xStartScale = transform.localScale.x;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.localScale += new Vector3(0, xStartScale, 0);
        }
    }
}
