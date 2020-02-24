using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //Text za pitanje
    [SerializeField]
    Text questionText;
    //Array za buttone odgovore
    [SerializeField]
    Button[] answerButtons;

    //Object za točno
    [SerializeField]
    GameObject correctAnswerPopup;
    //Object za krivo
    [SerializeField]
    GameObject wrongAnswerPopup;

    //Vrijeme
    [SerializeField]
    float timer;
    [SerializeField]
    Text timerText;

    [SerializeField]
    Manager manager;

    //Životi
    [SerializeField]
    GameObject[] hearts;
    int wrongAnswers = 0;

    [SerializeField]
    GameObject loseGamePopup;
    [SerializeField]
    GameObject gamePanel;

    //Prilagodi UI za pitanje
    public void SetupUIForQuestion(QuizQuestion question)
    {
        //Stavi rezultate u neaktivno
        correctAnswerPopup.SetActive(false);
        wrongAnswerPopup.SetActive(false);
        //for (int i = 0; i < hearts.Length; i++)
        //{
        //    hearts[i].SetActive(true);
        //}
        //Dodjeli pitanje da igrač vidi
        questionText.text = question.Question;

        //Posloži ponuđene odgovore
        for (int i = 0; i < question.Answers.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = question.Answers[i];
            answerButtons[i].gameObject.SetActive(true);
        }

        for (int i = question.Answers.Length; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(false);
        }
        //Započni odbrojavanje vremena
        StartTimer();
        Debug.Log("Start timer");

    }

    //Timer
    public void StartTimer()
    {
        //Zaustavi invoke
        CancelInvoke();
        timer = 1;
        timerText.text = timer.ToString();
        //Pokreni ponavljanje i brojanje vremena za 1 sekudnu svaku sekundu
        InvokeRepeating("TimerLogic", 1f, 1f);
        Debug.Log("Start repeating");
    }

    //Prikaz povećavanja vremena po pitanju
    void TimerLogic()
    {
        timer += 1;
        timerText.text = timer.ToString();
        Debug.Log("Timer grow");
    }

    //Provjera odgovora
    public void HandleSubmittedAnswer(bool isCorrect)
    {
        //Provjera vrijednosti
        ToggleAnswerButtons(false);
        //Ako je točno
        if (isCorrect)
        {
            ShowCorrectAnswerPopup();
        }
        //Ako je krivo
        else
        {
            ShowWrongAnswerPopup();
        }
    }

    private void ToggleAnswerButtons(bool value)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(value);
        }
    }

    //Pokaži točan rezultat
    private void ShowCorrectAnswerPopup()
    {
        //Prikaz objekta
        correctAnswerPopup.SetActive(true);
        //Zaustavljanje invokea
        CancelInvoke();
        //Računanje scorea
        manager.score += (int)(1000f / timer);
        //Resetiranje vremena
        timer = 1;
        timerText.text = timer.ToString();
        //Prikaz scorea
        manager.ScoreText.text = "Score: " + manager.score.ToString();
        //Ako je highscore provjera
        if(manager.score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", manager.score);
        }
    }

    private void ShowWrongAnswerPopup()
    {
        //Prikaz objekta
        wrongAnswerPopup.SetActive(true);
        //Zaustavljanje invokea
        CancelInvoke();
        //Resetiranje vremena
        timer = 1;
        timerText.text = timer.ToString();
        manager.ScoreText.text = "Score: " + manager.score.ToString();
        //Dodavanje količine krivih odgovora
        wrongAnswers++;
        Debug.Log(wrongAnswers);
        //Ako su tri kriva odgovora resetiraj igru
        if(wrongAnswers >= 3)
        {
            loseGamePopup.SetActive(true);
            Highscore highscore = FindObjectOfType<Highscore>();
            highscore.DownloadHighscores();
            gamePanel.SetActive(false);
        }
        //Smanji na UI količinu objekata srca
        hearts[wrongAnswers - 1].SetActive(false);
    }
}