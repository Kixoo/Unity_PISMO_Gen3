using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    GameObject Player;
    public float speed;
    public float Damage;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            var health = other.gameObject.GetComponent<Health>();
            health.health_Current -= Damage;
            Destroy(this.gameObject);
        }
    }
}
