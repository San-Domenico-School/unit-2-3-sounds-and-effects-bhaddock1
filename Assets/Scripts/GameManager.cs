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

    }
    private void TimeCountdown()
    {
        timeRemaining -= 1;
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
        gameOver = true;
        player.animator.BeginGame_b 
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

