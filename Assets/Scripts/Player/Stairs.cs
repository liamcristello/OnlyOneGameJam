using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public bool onStairs;

    void OnTriggerEnter2D (Collider2D other) 
    {
        // If the Collider2D belongs to the player
        if (other.gameObject.CompareTag("Player")) {
            onStairs = true;
        }
    }

    // Called when something exits this object's box-collider trigger.
    void OnTriggerExit2D (Collider2D other) 
    {
        // If the Collider2D belongs to the player
        if (other.gameObject.CompareTag("Player")) {
            onStairs = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (onStairs) 
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) 
            {
                FadeOut.CallFade(true);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.D)) 
            {
                FadeOut.CallFade(false);
            }
        }
    }
}
