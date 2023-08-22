using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestionManagement : MonoBehaviour
{
    public static QuestionManagement instance;
    [SerializeField] QuestionSO[] questionSOArr;
    List<QuestionSO> questionSOList;
    QuestionSO question;
    public QuestionSO Question { get => question; set => question = value; }

    private void Awake()
    {
        questionSOList = questionSOArr.ToList();
        MakeSingleTon();
    }
    public QuestionSO GetRandomQuestion()
    {
        if (questionSOList.Count > 0 && questionSOList != null)
        {
            int randIdx = Random.Range(0, questionSOList.Count);
            question = questionSOList[randIdx];
            questionSOList.RemoveAt(randIdx);
        }
        return question;
    }
    public void MakeSingleTon()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
