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
            Debug.Log ("Player has entered interactable zone.");
            onStairs = true;
        }
    }

    // Called when something exits this object's box-collider trigger.
    void OnTriggerExit2D (Collider2D other) 
    {
        // If the Collider2D belongs to the player
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log ("Player has exited interactable zone.");
            onStairs = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (onStairs) 
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) 
            {
                FadeOut.CallFade(true);
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.D)) 
            {
                FadeOut.CallFade(false);
            }
        }
    }
}
