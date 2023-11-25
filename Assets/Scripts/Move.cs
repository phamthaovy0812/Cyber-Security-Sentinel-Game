using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float tocdo;
    public float moveSpeed = 5f;
    private float trai_phai;
    private bool isfacingRight = true;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // trai_phai = Input.GetAxis("Horizontal");
        // rb.velocity = new Vector3(trai_phai * tocdo, rb.velocity.y);
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.sqrMagnitude);
        flip();

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
    void flip()
    {

        if ((isfacingRight && Input.GetAxis("Horizontal") < 0) || (!isfacingRight && Input.GetAxis("Horizontal") > 0))
        {
            isfacingRight = !isfacingRight;
            Vector3 kichthuoc = transform.localScale;
            kichthuoc.x = kichthuoc.x * -1;
            transform.localScale = kichthuoc;
        }
    }
}
