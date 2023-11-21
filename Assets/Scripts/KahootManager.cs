using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KahootManager : MonoBehaviour
{
    public List<KahootQA> QnA;
    public GameObject[] options;
    public int currentQuestion; 

    public UnityEngine.UI.Text QuestionTxt;

    private void Start()
    {
        generateQuestion();
        
    }

    public void correct()
    {
        generateQuestion();
         QnA.RemoveAL(currentQuestion);
    }
    
    void setAnswers()
    {
        for (int i=0; i < options.Length; i++)
        {
            options[i].GetComponent<KahootAnswers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<KahootAnswers>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);

        QuestionTxt.text = QnA[currentQuestion].Question;
        setAnswers();

        
    }
}
