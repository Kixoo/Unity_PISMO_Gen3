using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscore : MonoBehaviour
{
    public Text[] highscoresText; //prikazivanje u svakom tesktu jedan rezultat
    public Text myHighscore; //Prikaz mog rezultata
    Highscore highscoreManager;

    //Ako je druga scena za prikaz scorea
    private void Start()
    {
        for(int i = 0; i < highscoresText.Length; i++)
        {
            highscoresText[i].text = i + 1 + ". Loading...";
        }
        highscoreManager = GetComponent<Highscore>();

        StartCoroutine(RefreshHighscore());
    }

    //Ako je na istoj sceni
    public void OnButtonClickToUpdate()
    {
        for (int i = 0; i < highscoresText.Length; i++)
        {
            highscoresText[i].text = i + 1 + ". Loading...";
        }
        highscoreManager = GetComponent<Highscore>();

        StartCoroutine(RefreshHighscore());
    }

    //Dodjeli preuzete podatke u svaki text
    public void OnHighscoreDownload(Highscore.highscore[] highscoresList)
    {
        //Dogodit će se error pri punjenju ako imate više textova nego scoreova u bazi
        for (int i = 0; i < highscoresText.Length; i++)
        {
            //Stvori redni broj
            highscoresText[i].text = i + 1 + ". ";
            if (highscoresList.Length > 1)
            {
                //Dodaj tekst "username" + "-" razmaka + score + tekst bodova može pisati šta želite ali i nemora (npr. m, km, coins, itd)
                highscoresText[i].text += highscoresList[i].username + " - " + highscoresList[i].score + " bodova";
            }
        }

        //Vaš score zasebno iako ne mora biti, ali i može u top listi
        myHighscore.text = highscoreManager.userNick + " - " + PlayerPrefs.GetInt("Highscore") + " bodvoa";
    } 

    //ovaj ienumertor refresha naš highscore listu svakih 30 sekundi
    IEnumerator RefreshHighscore()
    {
        while(true)
        {
            highscoreManager.DownloadHighscores();
            yield return new WaitForSeconds(30);
        }
    }
}
