using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach_Player : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = this.gameObject.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
