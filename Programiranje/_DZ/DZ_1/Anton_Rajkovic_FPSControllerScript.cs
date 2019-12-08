using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSControllerScript : MonoBehaviour
{
    [Header("Walking and Running Speed:")]
    public float walkSpeed; //Brzina hodanja
    public float runSpeed; //Brzina trčanja
    float actualSpeed; //Stvarna brzina
    [Header("Jumping:")]
    public float jumpHeight; //Koliko daleko može igrač skočiti
    public Transform GroundCheck; // Objekt koji provjera dali smo na podu
    public float groundCheckRadius = 0.5f; //Radius provjeravanja dali smo na podu
    public LayerMask groundLayer; //Layer za pod(malo prenapredno)
    [Header("Crouching:")]
    public float crounchHeight; //Koliko se spusti igrač kada čućne
    

    bool isSprinting;//Provjera dali trčimo
    bool isCrounching;//Provjerava dali čućimo
    bool isGrounded;//Provjera dali je igrač sada na podu ili skače

    void Update()
    {
        CheckIfSprinting(); 
        CheckIfCrounching();
        CheckIfGrounded();
        Move();
    }

    //Funkcija za izvod kretanja
    private void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, actualSpeed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -actualSpeed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-actualSpeed * Time.deltaTime, 0,0);
        }else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(actualSpeed * Time.deltaTime, 0, 0);
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.Translate(Vector3.up * jumpHeight * Time.deltaTime); //radi isto kao i transform.position
            }
        }
    }

    //Funkcija za izvod i provjeru dali igrač trči
    void CheckIfSprinting()
    {
        if (!isCrounching)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isSprinting = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isSprinting = false;
            }
        }
        
        if(isSprinting)
        {
            actualSpeed = runSpeed;
        }
        else
        {
            actualSpeed = walkSpeed;
        }

    }

    //Funkcija za izvod i provjeru dali igrač čući
    void CheckIfCrounching()
    {
        if (!isSprinting)
        {
            if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.LeftControl))
            {
                isCrounching = true;
            }
            else if (Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.LeftControl))
            {
                isCrounching = false;
            }
        }

        if (isCrounching)
        {
            transform.localScale = new Vector3(1, crounchHeight, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    //Funkcija za provjeru dali smo na podu ili ne
    void CheckIfGrounded()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundCheckRadius, groundLayer);
    }
}
