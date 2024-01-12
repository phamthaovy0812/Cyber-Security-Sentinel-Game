using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoEnemyShooter : MonoBehaviour
{

    [SerializeField] private float stoppingDistance;

    private Transform player;

    private Rigidbody2D _rigidbody;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

    }


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        // else if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        // {
        //     transform.position = this.transform.position;

        // }
        // else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        // {
        //     transform.position = Vector2.MoveTowards(transform.position, player.position, -_speed * Time.deltaTime);
        // }

    }

}
