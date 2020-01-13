using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;



    public void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, target.position.y + 3, target.position.z - 5);
    }
}
