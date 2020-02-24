using System.Linq;
using UnityEngine;

public class QuestionCollection : MonoBehaviour
{
    //Sva pitanja 
    private QuizQuestion[] allQuestions;

    private void Awake()
    {
        LoadAllQuestions();
    }

    //Učitavanje iz foldera Resources/Questions
    private void LoadAllQuestions()
    {
        allQuestions = Resources.LoadAll<QuizQuestion>("Questions");
    }

    //Ne postavljeno pitanje
    public QuizQuestion GetUnaskedQuestion()
    {
        //Resetiranje pitanja metoda
        ResetQuestionsIfAllHaveBeenAsked();

        //Učitavanje pitanja koje se postavlja(Scriptable object)
        var question = allQuestions.Where(t => t.Asked == false).OrderBy(t => UnityEngine.Random.Range(0, int.MaxValue)) /*Random pitanje*/.FirstOrDefault();

        //Daj pitanju vrijednost da je pitano
        question.Asked = true;
        return question;
    }

    private void ResetQuestionsIfAllHaveBeenAsked()
    {
        //Provjera ima li svako pitanje true vrijednost, odnosno da je postavljeno
        if (allQuestions.Any(t => t.Asked == false) == false)
        {
            //Metoda resetiraj pitanje
            ResetQuestions();
        }
    }

    private void ResetQuestions()
    {
        //ZA svako pitanje u svim pitanjima stavi da su false i da nisu bila postavljena
        foreach (var question in allQuestions)
        {
            question.Asked = false;
        }
    }
}