#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenuAttribute]
public class QuizQuestion : ScriptableObject
{
    [SerializeField]
    private string question;

    [SerializeField]
    private string[] answers;

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
    { get
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