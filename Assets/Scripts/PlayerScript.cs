using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float maxWalkSpeed;
    Vector3 playerVelocity;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        playerVelocity = Vector3.zero;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerVelocity.x = Input.GetAxis("Horizontal") * maxWalkSpeed; 
    
        rb2d.velocity = playerVelocity;
    }
}
