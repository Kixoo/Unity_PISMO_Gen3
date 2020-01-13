using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int Player1Score = 0;
    int Player2Score = 0;
    public Text Player1ScoreText;
    public Text Player2ScoreText;

    private void Start()
    {
        Player1ScoreText.text = Player1Score.ToString();
        Player2ScoreText.text = Player2Score.ToString();
    }

    public void Player1Scores()
    {
        Player1Score++;
        Player1ScoreText.text = Player1Score.ToString();
    }

    public void Player2Scores()
    {
        Player2Score++;
        Player2ScoreText.text = Player2Score.ToString();
    }

}
