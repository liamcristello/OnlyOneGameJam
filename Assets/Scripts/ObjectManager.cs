using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
     {
         
     }
 
    // Update is called once per frame
    void Update()
     {
         
     }

    void OnTriggerEnter2D (Collider2D other) {
         if (other.gameObject.CompareTag("Player")) {
             Debug.Log ("Player has entered interactable zone.");
         }
     }
     void OnTriggerStay2D (Collider2D other) {
         if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)) {
             Debug.Log ("Player has interacted with " + this.name + ".");
         }
     }
     void OnTriggerExit2D (Collider2D other) {
         if (other.gameObject.CompareTag("Player")) {
             Debug.Log ("Player has exited interactable zone.");
         }
     }
}
