using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntonRajkovic_CharacterController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float JumpHeight;
    float horizontal;
    float vertical;
    Rigidbody myRB;

    private void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //DZ Jump
        if (Input.GetButtonDown("Jump"))
        {
            myRB.AddForce(Vector3.up * JumpHeight);
        }
        horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(horizontal, 0, vertical);
    }
}
