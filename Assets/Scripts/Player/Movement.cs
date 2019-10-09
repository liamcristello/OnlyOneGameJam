using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

   public Animator anim;

    private static bool switchFloor;

    private bool facingRight = false;


    private static int floor = 0; // 0 = bedroom, 1 = first, 2 = second, 3 = third

    // Start is called before the first frame update
    void Start()
    {
        // Start playerVelocity at 0.
        playerVelocity = Vector3.zero;
        copy = floorLocations;
        // Locate the player's rigidbody2D component for the rb2d variable.
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        playerLocation = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Take in x-direction input and affect the player's x-direction speed through rb2d.
        playerVelocity.x = Input.GetAxis("Horizontal") * maxWalkSpeed; 
        rb2d.velocity = playerVelocity;

        Debug.Log("Current Scene: " + SceneManager.GetActiveScene().buildIndex);

        if (playerVelocity.x > 1 || playerVelocity.x < -1 ) {
            anim.SetBool("isWalking", true);
        } 
        else 
        {
            anim.SetBool("isWalking", false);
        }
        
        if (switchFloor) 
        {
            this.transform.position = playerLocation;
            switchFloor = false;
        }
           if (playerVelocity.x > 0 && !facingRight || playerVelocity.x < 0 && facingRight)
        {
            Flip();
        }
    }

    //flips the player's sprite
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public static void ChangeFloors(bool moveUp) // true for yes
    {
        switchFloor = true;
        Debug.Log("Moved from: " + playerLocation);
        Debug.Log("Moved from: " + floor);
        
        if (moveUp && floor < 3)
            floor ++;
        if (!moveUp && floor > 0) 
            floor --;
        
        if (floor == 0 && moveUp)
            playerLocation = copy[1].transform.position;
        else if (floor == 1 && moveUp)
            playerLocation = copy[2].transform.position;
        else if (floor == 2 && moveUp)
            playerLocation = copy[3].transform.position;
        else if (floor == 3 && !moveUp)
            playerLocation = copy[2].transform.position;

        Debug.Log("Moved to: " + playerLocation);
        Debug.Log("Moved to: " + floor);
    }
}
