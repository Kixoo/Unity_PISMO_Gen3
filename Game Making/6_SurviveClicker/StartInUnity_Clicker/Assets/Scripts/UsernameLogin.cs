using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UsernameLogin : MonoBehaviour
{
    public Text usernameText;
    public Text errorPopup;

    //Button za kliknuti na game
    public void LoginGame()
    {
        if (usernameText.text == null)
        {
            errorPopup.text = "You need to write your username dickhead!";
        }
        else if (usernameText.text == " ")
        {
            errorPopup.text = "You think you can fool me fool?!";
        }
        else if (usernameText.text.Length < 3)
        {
            errorPopup.text = "You need to have at least 3 characters in your username!";
        }
        else
        {
            PlayerPrefs.SetString("username", usernameText.text);
            SceneManager.LoadScene(1);
        }
    }
}
