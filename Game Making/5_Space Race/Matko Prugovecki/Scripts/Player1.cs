using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    public GameObject player1;
    public Text scoreText;

    public Vector3 pos;
    
    public float counter = 0;
    public float playerSpeed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player1.transform.position += new Vector3(0f, playerSpeed, 0f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            player1.transform.position -= new Vector3(0f, playerSpeed, 0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obsticle")
        {
            transform.position = pos;
        }

        if (collision.gameObject.tag == "Win")
        {
            counter++;
            scoreText.text = counter.ToString();
            transform.position = pos;
        }
    }
}
