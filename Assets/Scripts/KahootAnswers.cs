using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KahootAnswers : MonoBehaviour
{
    public bool isCorrect = false;

    public KahootManager kahootManager;

    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("Correct Answer");
            kahootManager.correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
        }
    }

}
