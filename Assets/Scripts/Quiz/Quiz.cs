using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
public class Quiz : MonoBehaviour
{
    public static Quiz instance;
    [SerializeField] TextMeshProUGUI questionText;


    public AnswerButton[] answerButtons;
    int correctAnswerIndex = 0;

    
    private void Awake()
    {
        MakeSingleTon();
    }
    public void SetQuestionText(string text)
    {
        if (questionText)
        {
            questionText.text = text;
        }
    }
    public void ShufferAnswers()
    {
        if (answerButtons != null && answerButtons.Length > 0)
        {
            for (int i = 0;i < answerButtons.Length;i++)
            {
                if (answerButtons[i])
                {
                    answerButtons[i].tag = "Untagged";
                }
            }
            int randIdx = Random.Range(0, answerButtons.Length);
            if (answerButtons[randIdx])
            {
                answerButtons[randIdx].tag = "RightAnswer";
            }
        }
    }
    public void OnAnswerSelected(int index)
    {

    }
    public void MakeSingleTon()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
