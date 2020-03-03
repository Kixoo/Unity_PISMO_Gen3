﻿#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

//Scriptable object
[CreateAssetMenuAttribute]
public class QuizQuestion : ScriptableObject
{
    //String pitanja
    [SerializeField]
    private string question;

    //Array odgovora do 4 komada
    [SerializeField]
    private string[] answers;

    //Brojčano koji je točan od 0 do 3
    [SerializeField]
    private int correctAnswer;

    public string Question
    {
        get
        {
            return question;
        }
    }
    public string[] Answers
    {
        get
        {
            return answers;
        }
    }
    public int CorrectAnswer
    {
        get
        {
            return correctAnswer;
        }
    }

    public bool Asked
    {
        get;
        internal set;
    }

    private void OnValidate()
    {
        if (correctAnswer > answers.Length)
        {
            correctAnswer = 0;
        }

        RenameScriptableObjectToMatchQuestionAndAnswer();
    }

    private void RenameScriptableObjectToMatchQuestionAndAnswer()
    {
        string desiredName = string.Format("{0} [{1}]",
            question.Replace("?", ""),
            answers[correctAnswer]);
#if UNITY_EDITOR
        string assetPath = AssetDatabase.GetAssetPath(this.GetInstanceID());
#endif
        string shouldEndWith = "/" + desiredName + ".asset";
#if UNITY_EDITOR
        if (assetPath.EndsWith(shouldEndWith) == false)
        {
            Debug.Log("Want to rename to " + desiredName);
            AssetDatabase.RenameAsset(assetPath, desiredName);
            AssetDatabase.SaveAssets();
        }
#endif
    }
}