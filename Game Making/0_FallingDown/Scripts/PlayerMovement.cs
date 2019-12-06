using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public int health = 3;
    int startHealth;
    public int bodovi = 0;

    public Text health_text;
    public Text bodovi_text;

    void Start()
    {
        health_text.text = health + "/" + health;
        bodovi_text.text = bodovi + " points!";
        startHealth = health;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed, 0, 0);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0);
        }

        if(health == 0)
        {
            Debug.Log("IZGUBIO SI GLUPANE!");
            Application.Quit();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bad")
        {
            health--;
            health_text.text = health + "/" + startHealth;
        }
        else if(other.gameObject.tag == "good")
        {
            bodovi++;
            bodovi_text.text = bodovi + " points!";
        }

        Destroy(other.gameObject);
    }
}
