using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Buttons : MonoBehaviour
{
    //Restart
    public void Resetiraj()
    {
        SceneManager.LoadScene(0);
    }

    //QUIT
    public void UgasiIgru()
    {
        Application.Quit();
    }

    //Website
    public void OpenWeb()
    {
        Application.OpenURL("http://inkubator-pismo.eu/en/");
    }

    //Mail
    public void OpenMail()
    {
        Application.OpenURL("mailto:lisaann@gmail.com");
    }

    //Telefon
    public void OpenTele()
    {
        Application.OpenURL("tel://014833888");
    }
}
