using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public float tocdo;
    public float moveSpeed = 5f;
    private float trai_phai;
    private bool isfacingRight = true;

    private Rigidbody2D rb;
    private Animator animator;
    private UnityEngine.Vector2 moveInput;

    public InputActionReference moveActionToUse;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector2 moveDirection = moveActionToUse.action.ReadValue<UnityEngine.Vector2>();
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        // trai_phai = Input.GetAxis("Horizontal");
        // rb.velocity = new Vector3(trai_phai * tocdo, rb.velocity.y);
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.sqrMagnitude);
        flip();
        animator.SetFloat("move", Mathf.Abs(Input.GetAxis("Horizontal")));

    }
    public void OnMove(InputAction.CallbackContext ctx)
    {
        rb.velocity = ctx.ReadValue<UnityEngine.Vector2>() * moveSpeed;
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
            UnityEngine.Vector3 kichthuoc = transform.localScale;
            kichthuoc.x = kichthuoc.x * -1;
            transform.localScale = kichthuoc;
        }
    }
}
