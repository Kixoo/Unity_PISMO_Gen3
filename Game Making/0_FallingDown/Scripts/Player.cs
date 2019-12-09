using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;

    public int score = 0;
    public int health = 3;

    public Text scoreText;
    public Text healthText;

    public GameObject endGame;

    void Start()
    {
        scoreText.text = score.ToString();
        healthText.text = health.ToString();
        endGame.SetActive(false);
    }

    void Update()
    {
        //Kretanje igrača u lijevo
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(speed, 0, 0);
        }

        //Kretanje igrača u desno
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //pokupio dobar predmet
        if(other.gameObject.tag == "good")
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = score.ToString();
        }

        //pokupio loši predmet
        else if(other.gameObject.tag == "bad")
        {
            Destroy(other.gameObject);
            health--; //oduzimam helth
            healthText.text = health.ToString(); // drugi nacin: health + "";
            if(health == 0)
            {
                endGame.SetActive(true);
            }
        }
    }
}
