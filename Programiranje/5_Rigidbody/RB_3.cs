using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_3 : MonoBehaviour
{
    // SKRIPTA ZA ZAKLJUČAVANJE ROTACIJE PO Z OSI, TE KRETANJA PO Y OSI
    public Rigidbody rb;

    void Start()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
    }
}
