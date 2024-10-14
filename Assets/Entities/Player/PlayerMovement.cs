using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;        // Horizontal movement speed
    public Rigidbody2D rb;              // Rigidbody2D component

    private Vector2 movement;           // Store player movement input

    void Update()
    {
        // Get the horizontal input
        movement.x = Input.GetAxisRaw("Horizontal");
        Debug.Log(Input.GetAxisRaw("Horizontal"));
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Set(movement.x, (float)movement.y/2);
//        Debug.Log(Tilemap.GetTile(rb));



        movement.Normalize();

        // Flip the character sprite based on movement direction
        //        if (movement.x < 0)
        //        {
        //            transform.localScale = new Vector3(-1, 1, 1); // Face left
        //        }
        //        else if (movement.x > 0)
        //        {
        //            transform.localScale = new Vector3(1, 1, 1); // Face right
        //        }
    }
    void FixedUpdate()
    {
        // Apply horizontal movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}

