using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public GameObject deadScreen;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHor = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHor, 0.0f, 0f);

        rb.AddForce(movement * 6);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0f, 5.6f, 0f), ForceMode.Impulse);
        }

        transform.position += new Vector3(0f, 0f, 10f) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dead")
        {
            ShowDeadScreen();
        }
    }

    private void ShowDeadScreen()
    {
        deadScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
