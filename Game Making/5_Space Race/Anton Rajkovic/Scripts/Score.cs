using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Transform Player1StartingPosition;
    public Transform Player2StartingPosition;
    private GameManager GM;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(other.gameObject.name == "Player1")
            {
                //Increase player one score
                GM.Player1Scores();
                other.gameObject.transform.position = Player1StartingPosition.position;
            }else if(other.gameObject.name == "Player2")
            {
                //Increase player two score
                GM.Player2Scores();
                other.gameObject.transform.position = Player2StartingPosition.position;
            }
        }
    }
}
