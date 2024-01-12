
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STEnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;
    [SerializeField]

    // private float _AddAmount;


    // public void OnCollision2D(Collision2D collision)
    // {
    //     if (collision.gameObject.GetComponent<STPlayerMovement>())
    //     {
    //         var healthController = collision.gameObject.GetComponent<STHealthController>();

    //         healthController.TakeDamage(_damageAmount);
    //     }
    // }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var healthController = other.gameObject.GetComponent<STHealthController>();
            healthController.TakeDamage(_damageAmount);
        }

    }
}