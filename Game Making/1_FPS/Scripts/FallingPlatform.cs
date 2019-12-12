using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float timeForFall;
    Rigidbody rb;
    bool staosam = false;
    public Material aktivan;
    public float movingSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.isKinematic = true;
    }

    void Update()
    {
        transform.position += new Vector3(movingSpeed, 0, 0);
        if(staosam == true)
        {
            timeForFall -= Time.deltaTime;
            if(timeForFall <= 0)
            {
                rb.isKinematic = false;
                rb.useGravity = true;
                staosam = false;
            }
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            staosam = true;
            this.gameObject.GetComponent<MeshRenderer>().material = aktivan;
        }
        if(coll.gameObject.tag == "Static_Platform")
        {
            Debug.Log("da");
            movingSpeed *= -1;
            Debug.Log(movingSpeed);
        }
    }
}
