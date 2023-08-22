using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI answerText;
    [SerializeField] Button button;
    public void SetAnswerText(string text)
    {
        if (answerText != null)
        {
            answerText.text = text;
        }
    }
    public Button GetButton()
    {
        return button;
    }
}
