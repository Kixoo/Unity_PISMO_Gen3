using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float Speed;

    private void Update()
    {
        transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);

        
    }
}
