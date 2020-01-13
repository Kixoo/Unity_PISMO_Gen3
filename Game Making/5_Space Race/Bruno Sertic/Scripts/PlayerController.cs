using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public float speed;

    public Transform spawnPoint;

    public bool moveWithWS;

    // Update is called once per frame
    void Update()
    {
        if (moveWithWS)
        {
            Move();
        }
        else
        {
            MoveWithArrows();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            IncreaseScore();
            RespawnPlayer();
        }
        else if (collision.gameObject.tag == "Asteroid")
        {
            RespawnPlayer();
        }
    }

    

    public void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // go up
            transform.position += new Vector3(0f, 1f * speed, 0f) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0f, -1f * speed, 0f) * Time.deltaTime;
        }
    }

    public void MoveWithArrows()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // go up
            transform.position += new Vector3(0f, 1f * speed, 0f) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0f, -1f * speed, 0f) * Time.deltaTime;
        }
    }

    private void RespawnPlayer()
    {
        transform.position = spawnPoint.position;
    }

    private void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
