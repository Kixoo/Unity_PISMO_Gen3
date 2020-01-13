using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timerScale = 30f;
    public float timer = 0f;
    public GameObject divider;
    public float dividerY;

    public GameObject winScreen;
    public TextMeshProUGUI wintext;

    [SerializeField]
    PlayerController[] players;

    private void Start()
    {
        Time.timeScale = 1f;
        dividerY = divider.transform.localScale.y;
    }

    private void Update()
    {
        dividerY -= Time.deltaTime / 20;

        divider.transform.localScale = new Vector3(0.3f, dividerY, 0f);

        if (divider.transform.localScale.y <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        Time.timeScale = 0f;

        if (players[0].score > players[1].score)
        {
            wintext.text = "PLAYER1\nWINS";
        }
        else if (players[0].score < players[1].score)
        {
            wintext.text = "PLAYER2\nWINS";
        }
        else
        {
            wintext.text = "DRAW";
        }

        winScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
