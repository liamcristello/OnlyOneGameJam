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

    public GameObject[] floorLocations;
    public static GameObject[] copy;

    public static Vector2 playerLocation;

    private static bool switchFloor;


    private static int floor = 0; // 0 = bedroom, 1 = first, 2 = second, 3 = third

    // Start is called before the first frame update
    void Start()
    {
        // Start playerVelocity at 0.
        playerVelocity = Vector3.zero;
        copy = floorLocations;
        // Locate the player's rigidbody2D component for the rb2d variable.
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        playerLocation = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Take in x-direction input and affect the player's x-direction speed through rb2d.
        playerVelocity.x = Input.GetAxis("Horizontal") * maxWalkSpeed; 
        rb2d.velocity = playerVelocity;
        
        if (switchFloor) 
        {
            this.transform.position = playerLocation;
            switchFloor = false;
        }
    }

    public static void ChangeFloors(bool moveUp) // true for yes
    {
        switchFloor = true;
        
        if (moveUp && floor < 3)
            floor ++;
        if (!moveUp && floor > 0) 
            floor --;
        
        switch (floor) 
        {
            case 0:
                //move to bedroom
                playerLocation = copy[0].transform.position;
                break;
            case 1:
                //move to first floor
                playerLocation = copy[1].transform.position;
                break;
            case 2:
                //move to second floor
                playerLocation = copy[2].transform.position;
                break;
            case 3:
                //move to third floor
                playerLocation = copy[3].transform.position;
                break;
            default:
                Debug.Log("how");
                break;
        }
    }
}
