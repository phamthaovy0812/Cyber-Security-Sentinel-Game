using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharactorController : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    private Vector2 movement;
    private Rigidbody2D rb;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnMvement(InputValue value){
        movement = value.Get<Vector2>();
    }
    private void FixedUpdate(){
       // rb.velocity =  movement* speed;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
