// using System.Collections;
// using System.Collections.Generic;
// using Pathfinding;
// using UnityEngine;

// public class EnemyAi : MonoBehaviour
// {
//     public Transform target;
//     public float moveSpeed = 2f;
//     public float nextWayPointDistance = 2f;
//     public float repeatTimeUpdatePath = 0.5f;
//     // public SpriteRenderer characterSR;
//     // public Animator animator;
//     public int minDamage;
//     public int maxDamage;

//     Path path;
//     Seeker seeker;
//     Rigidbody2D rb;

//     // Health PlayerHealth;

//     Coroutine moveCoroutine;
//     public GameObject gameOver;

//     // Part 10
//     public float freezeDurationTime;
//     float freezeDuration;
//     private void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.gameObject.tag == "Player")
//         {
//             Debug.Log("collision");
//             Time.timeScale = 0;
//             GameOver.Instance.gameOver(Food.Instance.score);
//         }
//     }



// }
