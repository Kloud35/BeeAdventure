using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Quiz Question", fileName = "Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField]
    string question = "";

    [SerializeField]
    string[] anwers = new string[4];
    int indexCorrectAnswer = 0;
    public string GetQuestion()
    {
        return question;
    }
    public string GetAnswer(int index)
    {
        return anwers[index];
    }
}
