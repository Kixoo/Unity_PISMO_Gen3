using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; //potrebno za povezinje i komunikaciju sa internetom

public class Highscore : MonoBehaviour
{
    //WEB: http://dreamlo.com/lb/g5cjm68v-UGJZ6VB6bW8jg4BANPL58aEGt0ZOkS_XKcQ
    //podatke za doljnje stringove upisujemo sa strancije dreamlo.com
    //const služi kako se ta varijabla nebi više mjenjala nigdje
    const string privateCode = "g5cjm68v-UGJZ6VB6bW8jg4BANPL58aEGt0ZOkS_XKcQ";
    const string publicCode = "5e4bd69cfe232612b8416d1c";
    // *NAPOMENA* Ne ožete koristiti http linkove u aplikacijama andorida ako je 
    // API Level Androida minimum ili maximum 9.0 ili više
    const string webURL = "http://dreamlo.com/lb/";

    [Header("Player input")]
    [SerializeField]
    InputField playerName; //input field koji user korsti
    public string userNick; //pohranjivanje user nicka

    highscore[] highscoresList;
    public DisplayHighscore displayHighscore;



    private void Awake()
    {
        //Povlači iz player prefsa ime igrača
        userNick = PlayerPrefs.GetString("PlayerUsername");
        displayHighscore = GetComponent<DisplayHighscore>();
    }

    private void Start()
    {
        //Ako user već nije napisao ime
        if(userNick == string.Empty)
        {
            userNick = "Player" + Random.Range(0, 1000000000).ToString();
        }
    }

    //Igrač je upisao ime i želi sa novim imenom uploadati svoj score
    public void ChangeDataByMe()
    {
        userNick = playerName.text; // učitali smo ime iz play input fielda
        PlayerPrefs.SetString("PlayerUsername", userNick); //Spremili u playerprefs novog igrača
        int maxScore = PlayerPrefs.GetInt("Highscore"); //Dodjeli highscore
        AddNewHighscore(userNick, maxScore);
    }

    public void AddNewHighscore(string username, int score)
    {
        StartCoroutine(UploadNewHighscore(username, score)); //Započni corutinu uploadanja scora
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        //Koja konekcija (na koji link)
        UnityWebRequest www = new UnityWebRequest(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
        yield return www.SendWebRequest(); //Čekanje i slanje zahtjeva)

        //Ako nema errora
        if(string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload successful!");
            DownloadHighscores(); //Pozovi metodu za download scorea 
        }
        //Erorr je tu
        else
        {
            Debug.Log("Error uploading: " + www.error);
        }
    }

    //Javna metoda jer se poziva iz druge skripte
    public void DownloadHighscores()
    {
        StartCoroutine(DownloadHighscoreFromDatebase()); //Započni corutinu
    }

    //Preuzimanje scorea
    IEnumerator DownloadHighscoreFromDatebase()
    {
        UnityWebRequest www = new UnityWebRequest(webURL + publicCode + "/pipe/");
        //DownloadHandlerBuffer nam služi za preuzimanje podataka u bitovima u Unity
        // te potom pakirnaje njih u jednu cijelinu u našoj memoriji
        // Dok se preuzima je u RAM kad se skine ide na disk
        DownloadHandlerBuffer dh = new DownloadHandlerBuffer();

        www.downloadHandler = dh;

        yield return www.SendWebRequest();

        if(string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Download Successful!");
            Debug.Log(www.downloadHandler.text);
            FormatHighscore(www.downloadHandler.text); //Formatiranje texta
            displayHighscore.OnHighscoreDownload(highscoresList); //Pozovi display highscore i posloži tekst
        }

        else
        {
            Debug.Log("Error downloading: " + www.error);
        }
    }

    //Metoda koja nam formatira score i slaže tekst
    void FormatHighscore(string textStream)
    {
        //Slaži povučeni podataka u svaki novi red
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        //Stvori array dužine redaka
        highscoresList = new highscore[entries.Length];

        for(int i = 0; i < entries.Length; i++)
        {
            //Razdvojiti podatke svakog reda sa znakom "|" (može se vidjeti u debugu)
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            //Učitaj prvi razdvojeni podatak - username
            string username = entryInfo[0];
            //Učitaj drugi razdvojeni podatak - score
            int score = int.Parse(entryInfo[1]);
            //Puni array sa podatcima 
            highscoresList[i] = new highscore(username, score);
        }
        
    }

    //Slično kao klasa, ali pohranjuje sve vrijednosti liste ili više podataka u 
    // jedan blok memorije, a može mu se pristupiti iz više izvora i načina
    public struct highscore
    {
        public string username;
        public int score;

        public highscore(string username, int score)
        {
            this.username = username;
            this.score = score;
        }
    }
}
