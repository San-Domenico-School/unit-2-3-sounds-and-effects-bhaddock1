using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*************************************************************************
 * initializes sound effects and controls the player jump action
 * 
 * Bryce Haddock
 * October 31,2023     Version 1.0
 * **********************************************************************/

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce, gravityModifier;
    [SerializeField] private ParticleSystem dirtParticle, explosionParticle;
    [SerializeField] private AudioClip jumpSound, crashSound;

    private Animator playerAnimation;
    private AudioSource playerAudio;
    private Rigidbody playerRB;
    private bool isOnGround;

    public bool gameOver { get; private set; }

    // initializes player rigidbody, sets ground to true and sets gravity
    private void Start()
    {

        playerRB = GetComponent<Rigidbody>();
        isOnGround = true;
        Physics.gravity *= gravityModifier;
    }
    // on collision with ground sets ground equal to true
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            isOnGround = true;
        }
        
    }
    // if grounded and jump input is pressed the character will be launched vertically equal to jump force
    private void OnJump(InputValue input)
    {
        if(isOnGround == true)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
