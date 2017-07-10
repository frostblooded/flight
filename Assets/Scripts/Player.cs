using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public int JUMP_FORCE = 10;
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Make bird jump up if any key is pressed
        if (Input.anyKey)
        {
            Vector3 movementVector = new Vector3(0, JUMP_FORCE, 0);
            rb2D.AddForce(movementVector);
        }
    }
}
