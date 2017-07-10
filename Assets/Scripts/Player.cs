using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float JUMP_FORCE = 10;
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collide");

        if(collision.gameObject.CompareTag("Tree"))
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Make bird jump up if any key is pressed
        if (Input.anyKey)
        {
            rb2D.AddForce(Vector2.up * JUMP_FORCE, ForceMode2D.Impulse);
        }
    }
}
