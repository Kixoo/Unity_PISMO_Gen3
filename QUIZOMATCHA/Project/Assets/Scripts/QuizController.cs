using System.Collections;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    private QuestionCollection questionCollection;
    private QuizQuestion currentQuestion;
    private UIController uiController;

    //Pauza između pitanja
    [SerializeField]
    private float delayBetweenQuestions = 2f;

    private void Awake()
    {
        //Dodjeli objekt
        questionCollection = FindObjectOfType<QuestionCollection>();
        //Dodjeli objekt
        uiController = FindObjectOfType<UIController>();
    }

    private void Start()
    {
        //Pokaži pitanje
        PresentQuestion();
    }

    private void PresentQuestion()
    {
        //Povlači ne postavljeno pitanje iz skripte Question Collection i dodjeljuje ga scriptable objectu
        currentQuestion = questionCollection.GetUnaskedQuestion();
        //Posloži UI za pitanje
        uiController.SetupUIForQuestion(currentQuestion);
    }

    //Pruži odgovor (klik miša na ponuđno)
    public void SubmitAnswer(int answerNumber)
    {
        //Ako je krivo učitaj answerNumber ako je točno učitaj currentQuestion.CorrctAnswer
        bool isCorrect = answerNumber == currentQuestion.CorrectAnswer;
        //Šalji u skriptu uiController u metodu Submited answer bool isCorrect
        uiController.HandleSubmittedAnswer(isCorrect);

        //Pokreni courtionu učitavnja sljedećeg pitanja
        StartCoroutine(ShowNextQuestionAfterDelay());
    }

    //Učitavanje sljedećeg pitanja
    private IEnumerator ShowNextQuestionAfterDelay()
    {
        yield return new WaitForSeconds(delayBetweenQuestions);
        PresentQuestion();
    }
}