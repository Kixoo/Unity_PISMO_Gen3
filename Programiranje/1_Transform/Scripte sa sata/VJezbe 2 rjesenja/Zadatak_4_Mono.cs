using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_4_Mono : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
