using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float damage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag != "Gun" || coll.gameObject.tag != "Bullet" || coll.gameObject.tag != "Player" ||coll.gameObject.tag != "MainCamera")
        {
            var reducehealth = coll.GetComponent<Health>();
            //Skini health za damage
            Destroy(this.gameObject);
        }
    }
}
