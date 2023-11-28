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
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void DisplayUI()
    {

    }
    private void TimeCountdown()
    {

    }

    public void StartGame()
    {

    }


}

