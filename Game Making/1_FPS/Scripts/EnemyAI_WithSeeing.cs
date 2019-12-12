using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_WithSeeing : MonoBehaviour
{
    //Obavezno imajte sphere collider koji ima veci radius i trigger aktivan jer on uocava igraca
    GameObject Player;
    public float speed;
    public float Damage;
    bool uočenIgrač = false;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if(uočenIgrač == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            uočenIgrač = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            //var health = other.gameObject.GetComponent<Health>();
            //health.health_Current -= Damage;
            Destroy(this.gameObject);
        }
    }
}
