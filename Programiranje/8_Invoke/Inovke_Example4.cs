using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inovke_Example4 : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("SpawnObject", 1f, 2f);
    }

    void SpawnObject()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 0, 0);
    }
}
