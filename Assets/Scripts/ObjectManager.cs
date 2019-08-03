using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to manage objects' interactable trigger areas.
public class ObjectManager : MonoBehaviour
{
    // Reference to GameObject for purposes of displaying dialogue/text
    public DisplayText displayText;

    // bool to track if player is in collider trigger to start dialogue/text
    public static bool inZone;

    // Start is called before the first frame update
    void Start()
     {
         inZone = false;
     }
 
    // Update is called once per frame
    void Update()
     {
         
     }

    // Called when something enters this object's box-collider trigger.
    void OnTriggerEnter2D (Collider2D other) {
        // If the Collider2D belongs to the player
         if (other.gameObject.CompareTag("Player")) {
             Debug.Log ("Player has entered interactable zone.");
             inZone = true;
         }
     }
     
     // Called when something remains in this object's box-collider trigger.
    //  void OnTriggerStay2D (Collider2D other) {
    //      // If the Collider2D belongs to the player
    //      if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)) {
    //          Debug.Log ("Player has interacted with " + this.name + ".");
    //      }
    //  }

     // Called when something exits this object's box-collider trigger.
     void OnTriggerExit2D (Collider2D other) {
         // If the Collider2D belongs to the player
         if (other.gameObject.CompareTag("Player")) {
             Debug.Log ("Player has exited interactable zone.");
             inZone = false;
         }
     }
}
