using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOrb : MonoBehaviour
{
    public float speed = 20f;

    public void Launch(int direction)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed * direction, 0);
        Destroy(gameObject, 5f); // This will destroy the orb after 5 seconds
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Immediately destroy the orb upon collision with anything
        Destroy(gameObject);
    }

}
