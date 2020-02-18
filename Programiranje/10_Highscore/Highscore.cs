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



    private void Awake()
    {
        //Povlači iz player prefsa ime igrača
        userNick = PlayerPrefs.GetString("PlayerUsername"); 
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
        int maxScore = PlayerPrefs.GetInt("Highscore");
    }

    public void AddNewHighscore(string username, int score)
    {
        
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        UnityWebRequest www = new UnityWebRequest(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
        yield return www.SendWebRequest();

        if(string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload successful!");
        }
        else
        {
            Debug.Log("Error uploading: " + www.error);
        }
    }
}
