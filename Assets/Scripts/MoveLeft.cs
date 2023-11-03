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
        GameObject.Find("player").GetComponent<PlayerController>();

        
        
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        
        
    }
}
