using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 2f;
    public float nextWayPointDistance = 2f;
    public float repeatTimeUpdatePath = 0.5f;
    // public SpriteRenderer characterSR;
    // public Animator animator;
    public int minDamage;
    public int maxDamage;

    Path path;
    Seeker seeker;
    Rigidbody2D rb;

    // Health PlayerHealth;

    Coroutine moveCoroutine;
    public GameObject gameOver;

    // Part 10
    public float freezeDurationTime;
    float freezeDuration;
    private void Start()
    {
        // seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        // freezeDuration = 0;
        // target = FindObjectOfType<Player>().transform;

        // InvokeRepeating("CalculatePath", 0f, repeatTimeUpdatePath);
    }

    // void CalculatePath()
    // {
    //     if (seeker.IsDone())
    //         seeker.StartPath(rb.position, target.position, OnPathCompleted);
    // }

    // void OnPathCompleted(Path p)
    // {
    //     if (!p.error)
    //     {
    //         path = p;
    //         MoveToTarget();
    //     }
    // }

    // void MoveToTarget()
    // {
    //     if (moveCoroutine != null) StopCoroutine(moveCoroutine);
    //     moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    // }

    // public void FreezeEnemy()
    // {
    //     freezeDuration = freezeDurationTime;
    // }

    // IEnumerator MoveToTargetCoroutine()
    // {
    //     int currentWP = 0;

    //     while (currentWP < path.vectorPath.Count)
    //     {
    //         while (freezeDuration > 0)
    //         {
    //             freezeDuration -= Time.deltaTime;
    //             yield return null;
    //         }

    //         Vector2 direction = ((Vector2)path.vectorPath[currentWP] - rb.position).normalized;
    //         Vector2 force = direction * moveSpeed * Time.deltaTime;
    //         transform.position += (Vector3)force;

    //         float distance = Vector2.Distance(rb.position, path.vectorPath[currentWP]);
    //         if (distance < nextWayPointDistance)
    //             currentWP++;

    //         // if (force.x != 0)
    //         //     if (force.x < 0)
    //         //         characterSR.transform.localScale = new Vector3(-1, 1, 0);
    //         //     else
    //         //         characterSR.transform.localScale = new Vector3(1, 1, 0);

    //         yield return null;
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("collision");
            Time.timeScale = 0;
            gameOver.SetActive(true);

        }
    }

    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Player"))
    //     {
    //         CancelInvoke("DamagePlayer");
    //         PlayerHealth = null;
    //     }
    //     if (collision.CompareTag("FireRange"))
    //     {
    //         FindObjectOfType<WeaponManager>().RemoveEnemyToFireRange(this.transform);
    //     }
    // }

    // void DamagePlayer()
    // {
    //     int damage = Random.Range(minDamage, maxDamage);
    //     PlayerHealth.TakeDam(damage);
    //     //
    //     PlayerHealth.GetComponent<Player>().TakeDamageEffect(damage);
    // }

}
