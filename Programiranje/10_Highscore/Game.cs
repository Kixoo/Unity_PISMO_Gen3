using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int score;
    int maxScore;
    public Text scoreText;
    public Text highscoreText;

    private void Start()
    {
        maxScore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = maxScore.ToString();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        if(score > maxScore)
        {
            maxScore = score;
            PlayerPrefs.SetInt("Highscore", maxScore);
            highscoreText.text = maxScore.ToString();
        }
    }
}
