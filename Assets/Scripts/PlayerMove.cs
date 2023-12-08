using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        // Input.GetAxisRaw("Horizontal") returns -1, 0, or 1 based on left, no input, or right
        float moveX = Input.GetAxisRaw("Horizontal");
        
        // Input.GetAxisRaw("Vertical") returns -1, 0, or 1 based on down, no input, or up
        float moveY = Input.GetAxisRaw("Vertical");

        // Normalize the vector so that diagonal movement isn't faster
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        // Use the Rigidbody2D's velocity to move the player
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
