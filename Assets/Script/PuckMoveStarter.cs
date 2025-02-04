using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckMoveStarter : MonoBehaviour
{
    public Rigidbody2D puckRb; // Reference to Rigidbody2D

    void Start()
    {
        puckRb = GetComponent<Rigidbody2D>();
        puckRb.velocity = Vector2.zero; // Ensure the puck starts stationary
    }

    private void FixedUpdate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Only apply friction if moving
        if (rb.velocity.magnitude > 0.1f)
        {
            rb.velocity *= 0.995f; // Adjust for a more realistic ice slide (0.998 for even less friction)
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mallet"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            // Get impact force based on the mallet's velocity
            Vector2 force = collision.relativeVelocity * 1.2f;

            // Apply force to the puck
            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
