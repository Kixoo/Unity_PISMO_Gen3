using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coi_rotate : MonoBehaviour
{
    public float rotateSpeed = 1.5f;

    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
    }
}
