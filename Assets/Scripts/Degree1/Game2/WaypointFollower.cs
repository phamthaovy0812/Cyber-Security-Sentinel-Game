using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WaypointFollower : MonoBehaviour
{
    // [SerializeField] private GameObject[] waypoints;
    // private int currentWaypointIndex = 0;

    // [SerializeField] private float speed = 2f;
    // public float destructionTime = 1f;
    public MovementPacman movement { get; private set; }
    private Rigidbody2D rb;
    public Transform target;
    public int points = 200;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<MovementPacman>();
    }
    // private void Update()
    // {
    //     if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
    //     {
    //         currentWaypointIndex++;
    //         if (currentWaypointIndex >= waypoints.Length)
    //         {
    //             currentWaypointIndex = 0;
    //         }
    //     }
    //     transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    // }
    private void Start()
    {
        ResetState();
    }
    public void ResetState()
    {
        gameObject.SetActive(true);
        movement.ResetState();

        // frightened.Disable();
        // chase.Disable();
        // scatter.Enable();

        // if (home != initialBehavior)
        // {
        //     home.Disable();
        // }

        // if (initialBehavior != null)
        // {
        //     initialBehavior.Enable();
        // }
    }
    public void SetPosition(Vector3 position)
    {
        // Keep the z-position the same since it determines draw depth
        position.z = transform.position.z;
        transform.position = position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            Debug.Log("Explosion");
            Destroy(gameObject);
        }

    }
}