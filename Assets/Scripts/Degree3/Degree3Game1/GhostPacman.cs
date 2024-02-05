using Unity.VisualScripting;
using UnityEngine;

[DefaultExecutionOrder(-10)]
[RequireComponent(typeof(MoveEnemy))]
public class GhostPacman : MonoBehaviour
{
    public MoveEnemy movement { get; private set; }
    // public GhostPacmanScatter scatter { get; private set; }
    // public GhostPacmanChase chase { get; private set; }
    public GhostPacmanFrightened frightened { get; private set; }
    // public GhostPacmanBehavior initialBehavior;
    public Transform target;
    public int points = 200;
    Rigidbody2D rb;

    private void Awake()
    {
        movement = GetComponent<MoveEnemy>();
        // home = GetComponent<GhostPacmanHome>();
        // scatter = GetComponent<GhostPacmanScatter>();
        // chase = GetComponent<GhostPacmanChase>();
        frightened = GetComponent<GhostPacmanFrightened>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        ResetState();
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        movement.ResetState();

        frightened.Enable();
        // chase.Disable();
        // scatter.Enable();

        // if (home != initialBehavior)
        // {
        //     home.Disable();
        // }
        // initialBehavior.Enable();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Debug.Log("Pacman collision");
        }
    }

}
