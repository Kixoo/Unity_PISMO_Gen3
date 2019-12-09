using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Koristimo kada radimo nešto sa scenama

public class Restart : MonoBehaviour
{
    public void ResetirajIgru()
    {
        SceneManager.LoadScene(0);
    }
}
