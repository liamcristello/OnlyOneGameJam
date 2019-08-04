﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to manage objects' interactable trigger areas.
public abstract class ObjectManager : MonoBehaviour
{
    public string[] words;
    public static bool inZone;

    public DisplayText text;

   void OnTriggerEnter2D (Collider2D other) 
   {
       // If the Collider2D belongs to the player
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log ("Player has entered interactable zone.");
            inZone = true;
        }
    }

    void OnTriggerStay2D (Collider2D other)
    {
        if (inZone && Input.GetKeyDown(KeyCode.E)) {
            //Send to dialogue controller
            inZone = false; //keeps from restarting dialogue on each button press
            DisplayText();
        }
    }

    // Called when something exits this object's box-collider trigger.
    void OnTriggerExit2D (Collider2D other) 
    {
        // If the Collider2D belongs to the player
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log ("Player has exited interactable zone.");
            inZone = false;
        }
    }

    public abstract void DisplayText();
}
