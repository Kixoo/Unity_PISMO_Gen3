using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowUpdate : MonoBehaviour
{
    [Header("Interval slowUpdate-a")]
    public float slowUpdateInterval = 0.33f; //period izvršavanja SlowedUpdatea

    float i;

    void Start()
    {
        InvokeRepeating("SlowedUpdate", slowUpdateInterval, slowUpdateInterval);
    }

    void SlowedUpdate()
    {
        i += Time.deltaTime;
        Debug.Log(i);
    }
}
