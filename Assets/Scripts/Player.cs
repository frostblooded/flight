using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private bool shouldJump = false;

    public int score = 9;
    public int jumps = 0;
    public GameController gameController;
    public UIHandler uiHandler;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Whenever the player collides with something,
        // destroy the player if the collision object
        // is a tree
        if (collision.gameObject.CompareTag("Tree")
            || collision.gameObject.CompareTag("Boundary"))
        {
            AudioManager.instance.PlayDeathSound();
            gameController.EndGame(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Whenever the player collides with the trigger between
        // the tree's components, increase the score
        if(collision.gameObject.CompareTag("TreeTrigger"))
        {
            score++;
            uiHandler.DisplayGameScore(score);
            gameController.OnScoreGained(score);
        }
    }
    
    public static bool PlayerShouldJump()
    {
        // For debugging purposes. Use the id for mouse (-1)
        // if there is no touch, so that it can be tested on a PC
        int touchingId = Input.touchCount > 0 ? Input.GetTouch(0).fingerId : -1;

        // Don't jump if it is clicked over a UI object
        return Input.GetMouseButtonDown(0)
            && !EventSystem.current.IsPointerOverGameObject(touchingId);
    }

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Save if a key has been pressed, so that the FixedUpdate method
        // can react accordingly

        if (PlayerShouldJump())
        {
            shouldJump = true;
        }
    }
    
    void FixedUpdate()
    {
        // Make bird jump up if any key is pressed
        if (shouldJump)
        {
            // Set the upward velocity, so that the player always
            // jumps up with the same speed, no matter his previous
            // position. If we were to use the AddForce method, it would only
            // slow the falling speed if the player was falling.
            // When it is done with setting the velocity directly, 
            // it gets the same upward velocity every time.
            rb2D.velocity = Vector2.up * Constants.PlayerJumpForce;
            AudioManager.instance.PlayJumpSound();
            shouldJump = false;
            jumps++;
        }
    }
}
