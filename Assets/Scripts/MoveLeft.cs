using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 25;
    private float leftBound = -15;
    private PlayerController playerControllerScript;
    
   

    // Update is called once per frame
    private void Update()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        if(!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else
        {
            speed = 0.0f;
        }

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
        
    }
}
