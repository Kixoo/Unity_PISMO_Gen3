using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nina_Karacic_FPSController : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    

    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector3.forward);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(Vector3.back);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
