using UnityEngine;

[DefaultExecutionOrder(-10)]
[RequireComponent(typeof(MovementPacman))]
public class GhostPacman : MonoBehaviour
{
    public MovementPacman movement { get; private set; }
    public GhostPacmanHome home { get; private set; }
    public GhostPacmanScatter scatter { get; private set; }
    public GhostPacmanChase chase { get; private set; }
    public GhostPacmanFrightened frightened { get; private set; }
    public GhostPacmanBehavior initialBehavior;
    public Transform target;
    public int points = 200;

    private void Awake()
    {
        movement = GetComponent<MovementPacman>();
        home = GetComponent<GhostPacmanHome>();
        scatter = GetComponent<GhostPacmanScatter>();
        chase = GetComponent<GhostPacmanChase>();
        frightened = GetComponent<GhostPacmanFrightened>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        movement.ResetState();

        frightened.Disable();
        chase.Disable();
        scatter.Enable();

        if (home != initialBehavior)
        {
            home.Disable();
        }

        if (initialBehavior != null)
        {
            initialBehavior.Enable();
        }
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
            if (frightened.enabled)
            {
                GameManagerDegree3game1.Instance.GhostEaten(this);
            }
            else
            {
                GameManagerDegree3game1.Instance.PacmanEaten();
            }
        }
    }

}
