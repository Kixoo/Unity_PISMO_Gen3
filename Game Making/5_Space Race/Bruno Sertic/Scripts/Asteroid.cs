using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float direction = 1;
    public float speed = 55f;

    void Update()
    {
        transform.position += new Vector3(direction, 0f, 0f) * Time.deltaTime;

        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
