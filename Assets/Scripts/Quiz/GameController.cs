using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int countRight = 0;
    // Start is called before the first frame update
    [SerializeField] private AudioSource wrongSoundEffect;
    [SerializeField] private AudioSource rightSoundEffect;
    void Start()
    {
        CreateQuestion();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateQuestion()
    {
        QuestionSO qs = QuestionManagement.instance.GetRandomQuestion();
        if (qs != null)
        {

            Quiz.instance.SetQuestionText(qs.GetQuestion());
            string[] wrongAnswer = new string[] { qs.GetAnswer(1), qs.GetAnswer(2), qs.GetAnswer(3) };

            Quiz.instance.ShufferAnswers();
            var temp = Quiz.instance.answerButtons;
            if (temp != null && temp.Length > 0)
            {
                wrongAnswer = ShuffleArray(wrongAnswer);
                int wrongAnswerCount = 0;
                for (int i = 0; i < temp.Length; i++)
                {
                    int answerId = i;
                    if (string.Compare(temp[i].tag, "RightAnswer") == 0)
                    {
                        temp[i].SetAnswerText(qs.GetAnswer(0));
                    }
                    else
                    {
                        temp[i].SetAnswerText(wrongAnswer[wrongAnswerCount]);
                        wrongAnswerCount++;
                    }
                    temp[answerId].GetButton().onClick.RemoveAllListeners();
                    temp[answerId].GetButton().onClick.AddListener(() => CheckRightAnswerEvent(temp[answerId]));
                }
            }
        }
    }
    private string[] ShuffleArray(string[] array)
    {
        System.Random rng = new System.Random();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            string value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
        return array;
    }

    [System.Obsolete]
    void CheckRightAnswerEvent(AnswerButton button)
    {
        if (button.CompareTag("RightAnswer"))
        {
            rightSoundEffect.Play();
            EnemyHealthManager.instance.TakeDamage();
            if (EnemyHealthManager.instance.currentHealth == 0)
            {
                rightSoundEffect.Play();
                if (SceneManager.UnloadScene(SceneManager.GetSceneAt(1)))
                {
                };

            }
            CreateQuestion();
        }
        else
        {
            wrongSoundEffect.Play();
            HealthManager.instance.TakeDamage();

            if(HealthManager.instance.currentHealth == 0)
            {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            }
        }
    }
}
