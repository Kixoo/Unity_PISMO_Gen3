using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    Rigidbody myRB;
    public Transform MyRespawnPoint;

    private void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        if (this.gameObject.name == "Player1")
        {
            if (Input.GetKey(KeyCode.W))
            {
                myRB.AddForce(Vector3.up * MoveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                myRB.AddForce(Vector3.down * MoveSpeed * Time.deltaTime);

            }
        }else if(this.gameObject.name == "Player2")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                myRB.AddForce(Vector3.up * MoveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                myRB.AddForce(Vector3.down * MoveSpeed * Time.deltaTime);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Object")
        {
            transform.position = MyRespawnPoint.position;
            Destroy(other.gameObject);
        }
    }
}
