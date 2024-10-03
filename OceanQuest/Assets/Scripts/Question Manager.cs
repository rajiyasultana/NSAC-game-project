using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public Text questionText;
    public Text scoreText;
    public Text FinalScore;
    public Button[] replyButtons;
    public QuizData quizData;
    public GameObject Right;
    public GameObject Wrong;
    public GameObject GameFinished;

    private int currentQuestion = 0;
    private static int score = 0;
    void Start()
    {
        SetQuestion(currentQuestion);
        Right.gameObject.SetActive(false); 
        Wrong.gameObject.SetActive(false);
        GameFinished.gameObject.SetActive(false);
    }

    void SetQuestion(int questionIndex)
    {
        questionText.text = quizData.questions[questionIndex].questionText;

        foreach (Button r in replyButtons)
        {
            r.onClick.RemoveAllListeners();
        }

        for(int i = 0; i < replyButtons.Length; i++)
        {
            replyButtons[i].GetComponentInChildren<Text>().text = quizData.questions[questionIndex].replies[i];
            int replyIndex = i;
            replyButtons[i].onClick.AddListener(() =>
            {
                CheckReply(replyIndex);
            });
        }
    }

    void CheckReply(int replyIndex)
    {
        if(replyIndex == quizData.questions[currentQuestion].correctReplyIndex)
        {
            score++;
            scoreText.text = "" + score;

            Right.gameObject.SetActive(true);

            foreach (Button r in replyButtons)
            {
                r.interactable = false;
            }

            StartCoroutine(Next());
        }
        else
        {
            Wrong.gameObject.SetActive(true);

            foreach(Button r in replyButtons)
            {
                r.interactable = false;
            }

            StartCoroutine(Next());
        }
    }

    IEnumerator Next()
    {
        yield return new WaitForSeconds(2);

        currentQuestion++;

        if(currentQuestion < quizData.questions.Length)
        {
            Reset();
        }

        else
        {
            GameFinished.SetActive(true);

            float scorePercentage = (float)score / quizData.questions.Length * 100;

            FinalScore.text = "You Scored " + scorePercentage.ToString("F0") + "%";

            if(scorePercentage < 50)
            {
                FinalScore.text += "\nGame Over!";
            }
            else if (scorePercentage < 60)
            {
                FinalScore.text += "\nKeep Trying";
            }
            else if (scorePercentage < 70)
            {
                FinalScore.text += "\nGood Job";
            }
            else if (scorePercentage < 80)
            {
                FinalScore.text += "\nWell Done!";
            }
            else
            {
                FinalScore.text += "\nYou are a genius!";
            }

        }
    }

    public void Reset()
    {
        Right.SetActive(false);
        Wrong.SetActive(false);

        foreach (Button r in replyButtons)
        {
            r.interactable = true;
        }

        SetQuestion(currentQuestion);
    }

    
}
