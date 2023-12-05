using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/***************************************************
 * 
 * 
 * 
 * 
 * ************************************************/

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreboardText;
    [SerializeField] TextMeshProUGUI timeRemainingText;
    [SerializeField] GameObject toggleGroup;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject kahootPanel;
    [SerializeField] GameObject spawnManager;
    [SerializeField] GameObject runnerGame;
    [SerializeField] Animator playerAnimator;
    [SerializeField] ParticleSystem dirtSplatter;
    public static bool gameOver = true;
    public static bool miniGame = false;
    private static float score;
    private AudioSource audioSource;
    private int timeRemaining = 60;
    private int miniGameCooldown = 15;
    private bool timedGame;
    private UIController uiControllerScript;
    private QuizController quizControllerScript;
    
    

    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        DisplayUI();

        EndGame();
    }

    private void DisplayUI()
    {
        scoreboardText.text = "Score:" + Mathf.RoundToInt(score).ToString();

        if(timedGame && !gameOver)
        {
            if(timeRemaining > 0)
            {
                
                timeRemainingText.text = timeRemaining.ToString();
            }
           else
           {
               timeRemainingText.text = "Game\nOver";
           }
        }
        
    }

    private void TimeCountdown()
    {
        miniGameCooldown--;
        timeRemaining--;
        if(miniGameCooldown <= 0)
        {
           StartMiniGame();
            CancelInvoke("TimeCountdown");
        }

        if(timeRemaining <= 0)
        {
            CancelInvoke("TimeCountdown");
            
        }

    }

    public void StartGame()
    {
        audioSource.Play();

        toggleGroup.SetActive(false);
        startButton.SetActive(false);
        if(timedGame)
        {
            timeRemainingText.gameObject.SetActive(true);
            InvokeRepeating("TimeCountdown", 1,1);
        }
        gameOver = false;

        spawnManager.SetActive(true);

        playerAnimator.SetFloat("Speed_f", 1.0f);
        playerAnimator.SetBool("BeginGame_b", true);
        dirtSplatter.Play();
    }

    private void EndGame()
    {
        
        if(gameOver || timeRemaining == 0)
        {
            gameOver = true;
            playerAnimator.SetBool("BeginGame_b", false);
            playerAnimator.SetFloat("Speed_f", 0f);
            audioSource.Stop();
            CancelInvoke();
            timeRemainingText.text = "Game\nOver";
        }
        
    }

    public void SetTimed(bool timed)
    {
        timedGame = timed;
    }

    public static void ChangeScore(int change)
    {
        score += change;
    }

    private void StartMiniGame()
    {
        kahootPanel.SetActive(true);
        runnerGame.SetActive(false); 
        CancelInvoke();
        miniGame = true;
        
        if(UIController.right)
        {
            runnerGame.SetActive(true);
            kahootPanel.SetActive(false);
            ChangeScore(5);
            InvokeRepeating("TimeCountdown", 1,1);
            miniGame = false;
        }
    }
}

