using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private bool buttonPressed;

    public float JumpForce = 10;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Whenever the player collides with something,
        // destroy the player if the collision object
        // is a tree
        if (collision.gameObject.CompareTag("Tree"))
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        // Save if a key has been pressed, so that the FixedUpdate method
        // can react accordingly
        //
        // Note: The input can't be handled in the FixedUpdate method,
        // because it is not always called every frame and the input
        // action may be missed
        if (Input.anyKeyDown)
        {
            buttonPressed = true;
        }
    }
    
    void FixedUpdate()
    {
        // Make bird jump up if any key is pressed
        if (buttonPressed)
        {
            rb2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            buttonPressed = false;
        }
    }
}
