using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public static bool inZone;
    private DialogueTrigger dialogue;
    public GameObject e;
  
    void OnTriggerEnter2D (Collider2D other) 
   {
       // If the Collider2D belongs to the player
        if (other.gameObject.CompareTag("Object") || other.gameObject.CompareTag("StoryObject")) {
            inZone = true;
            e.SetActive(true);
            Debug.Log("hello");
        }
    }

    void OnTriggerStay2D (Collider2D other)
    {
        if (inZone && Input.GetKey(KeyCode.E)) 
        {
            //Send to dialogue controller
            inZone = false; //keeps from restarting dialogue on each button press
            dialogue = other.gameObject.GetComponent<DialogueTrigger>();
            dialogue.TriggerDialogue();
        }

        if (other.gameObject.CompareTag("StoryObject") && inZone) 
        {
          Debug.Log("here");
          FadeOut.CallFade(sceneChange: true);
        }
    }

    // Called when something exits this object's box-collider trigger.
    void OnTriggerExit2D (Collider2D other) 
    {
        // If the Collider2D belongs to the player
        if (other.gameObject.CompareTag("Object") || other.gameObject.CompareTag("StoryObject")) {
            inZone = false;
            e.SetActive(false);
        }
    }
}