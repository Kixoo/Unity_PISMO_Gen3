using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damir_Pendak_FPCharacterController: MonoBehaviour
{
    //Add Rigidbody component, use gravity, X and Z freeze position constraints!

    public float walkSpeed = 0.2f;
    public float runSpeed = 0.6f;
    bool crouchOn;
    public float jumpHeight = 50f;

    void Update()
    {
        //WALK
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, walkSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-walkSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -walkSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(walkSpeed, 0, 0);
        }

        //RUN
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += new Vector3(0, 0, runSpeed);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += new Vector3(-runSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += new Vector3(0, 0, -runSpeed);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += new Vector3(runSpeed, 0, 0);
        }

        //CROUCH
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouchOn = !crouchOn;
        }

        if (!crouchOn)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
        }

        //JUMP 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //transform.position(Vector3.up * jumpHeight * Time.deltaTime); //ne radi -> 'Transform.position' cannot be used like a method ?
            transform.Translate(Vector3.up * jumpHeight * Time.deltaTime);
        }
    }
}
