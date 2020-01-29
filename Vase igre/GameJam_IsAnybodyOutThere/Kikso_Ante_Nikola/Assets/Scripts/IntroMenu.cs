using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(2);
    }

    //public void QuitGame()
    //{
    //    Application.Quit();
    //}
}
