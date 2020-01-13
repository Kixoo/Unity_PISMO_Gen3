using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject deadMenu;
    public GameObject pauseMenu;
    public GameObject scoreMenu;
    AudioSource asource;

    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();

        }
    }

    private void TogglePause()
    {
        paused = !paused;

        if (paused)
        {
            ShowPauseMenu();
        }
        else
        {
            HidePauseMenu();
        }

    }

    private void HidePauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    private void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
        scoreMenu.SetActive(true);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
