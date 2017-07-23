using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private bool buttonPressed = false;

    private const string HighscorePrefsName = "highscore";

    public float JumpForce = 15;
    public int score = 0;
    public GameController gameController;

    /// <summary>
    /// Updates the highscore of the player if necessary
    /// </summary>
    /// <returns>The high score after it has been updated</returns>
    private int UpdateHighscore()
    {
        int currentHighscore = PlayerPrefs.GetInt(Player.HighscorePrefsName, 0);

        if(score > currentHighscore)
        {
            PlayerPrefs.SetInt(Player.HighscorePrefsName, score);
            PlayerPrefs.Save();
            return score;
        }

        return currentHighscore;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Whenever the player collides with something,
        // destroy the player if the collision object
        // is a tree
        if (collision.gameObject.CompareTag("Tree"))
        {
            int highscore = UpdateHighscore();
            gameController.displayedText.text = @"Your score is: " + score +
                "\nYour highscore is: " + highscore +
                "\nPress to restart.";
            gameController.gameHasEnded = true;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Sometimes the score updates at the same time (or after)
        // the game ends, so this if prevents it
        if (gameController.gameHasEnded)
            return;

        // Whenever the player collides with the trigger between
        // the tree's components, increase the score
        if(collision.gameObject.CompareTag("TreeTrigger"))
        {
            score++;
            gameController.displayedText.text = score.ToString();
        }
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
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
            // Set the upward velocity, so that the player always
            // jumps up with the same speed, no matter his previous
            // position. If we were to use the AddForce method, it would only
            // slow the falling speed if the player was falling.
            // When it is done with setting the velocity directly, 
            // it gets the same upward velocity every time.
            rb2D.velocity = Vector2.up * JumpForce;
            buttonPressed = false;
        }
    }
}
