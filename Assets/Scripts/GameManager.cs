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
    [SerializeField] GameObject spawnManager;
    [SerializeField] Animator playerAnimator;
    [SerializeField] ParticleSystem dirtSplatter;
    public static bool gameOver = true;
    private static float score;
    private AudioSource audioSource;
    private int timeRemaining = 60;
    private bool timedGame;
    private bool timerDone;
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

        if(timedGame)
        {
            if(timeRemaining > 0)
            {
                Debug.Log("working");
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
        
        timeRemaining -= 1;
        if(timeRemaining <= 0)
        {
            timerDone = true;
            
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
            InvokeRepeating("TimeCountdown", 1 ,1);
        }
        gameOver = false;

        spawnManager.SetActive(true);

        playerAnimator.SetFloat("Speed_f", 1.0f);
        playerAnimator.SetBool("BeginGame_b", true);
        dirtSplatter.Play();
    }

    private void EndGame()
    {
        
        if(gameOver || timerDone)
        {
            gameOver = true;
            playerAnimator.SetBool("BeginGame_b", false);
            playerAnimator.SetFloat("Speed_f", 0f);
            audioSource.Stop();
            CancelInvoke();
        }
        
    }

    public void SetTimed(bool timed)
    {
        timed = timedGame;
    }

    public static void ChangeScore(int change)
    {
        score += change;
    }
}

