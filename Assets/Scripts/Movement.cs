using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to manage player movement.
public class Movement : MonoBehaviour
{
    // float to represent the upper bound of the player's speed.
    public float maxWalkSpeed;
    // Vector3 to represent how fast the player is currently moving.
    Vector3 playerVelocity;
    // Rigidbody2D to determine physics input on player.
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        // Start playerVelocity at 0.
        playerVelocity = Vector3.zero;
        // Locate the player's rigidbody2D component for the rb2d variable.
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Take in x-direction input and affect the player's x-direction speed through rb2d.
        playerVelocity.x = Input.GetAxis("Horizontal") * maxWalkSpeed; 
        rb2d.velocity = playerVelocity;
    }
}
