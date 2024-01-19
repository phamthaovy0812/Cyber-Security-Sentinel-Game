using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STProjectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    [SerializeField]
    private float _damageAmount;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Die();
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // var healthController = other.gameObject.GetComponent<STHealthController>();
            Die();
            // healthController.TakeDamage(_damageAmount);
            Destroy(gameObject);
        }

    }
    private void Die()
    {
        // deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("isDead");
    }

    // private void OnCollisionStay2D(Collision2D collision)
    // {
    //     if (collision.gameObject.GetComponent<PlayerMovement>())
    //     {
    //         var healthController = collision.gameObject.GetComponent<STHealthController>();

    //         healthController.TakeDamage(_damageAmount);
    //     }
    // }
}
