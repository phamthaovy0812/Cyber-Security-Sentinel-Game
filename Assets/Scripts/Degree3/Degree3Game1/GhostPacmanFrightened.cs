using UnityEngine;

public class GhostPacmanFrightened : GhostPacmanBehavior
{
    // public SpriteRenderer body;
    // public SpriteRenderer eyes;
    // public SpriteRenderer blue;
    // public SpriteRenderer white;
    // private MovementPacman movement;

    private bool eaten;

    public override void Enable(float duration)
    {
        base.Enable(duration);

        Invoke(nameof(Flash), duration / 2f);
    }

    public override void Disable()
    {
        base.Disable();
    }

    private void Eaten()
    {
        eaten = true;

        // ghostPacman.home.Enable(duration);

        // body.enabled = false;
        // eyes.enabled = true;
        // blue.enabled = false;
        // white.enabled = false;
    }

    private void Flash()
    {
        // if (!eaten)
        // {
        //     blue.enabled = false;
        //     white.enabled = true;
        //     white.GetComponent<AnimatedSprite>().Restart();
        // }
    }

    private void OnEnable()
    {
        // blue.GetComponent<AnimatedSprite>().Restart();
        ghostPacman.movement.speedMultiplier = 0.5f;
        eaten = false;
    }

    private void OnDisable()
    {
        ghostPacman.movement.speedMultiplier = 1f;
        eaten = false;
    }
    // private void Awake()
    // {
    //     movement = GetComponent<MovementPacman>();
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        NodePacman node = other.GetComponent<NodePacman>();

        if (node != null && enabled)
        {
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;
            float angle = Mathf.Atan2(ghostPacman.movement.direction.y, ghostPacman.movement.direction.x);
            transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
            // Find the available direction that moves farthest from pacman
            foreach (Vector2 availableDirection in node.availableDirections)
            {
                // If the distance in this direction is greater than the current
                // max distance then this direction becomes the new farthest
                Vector3 newPosition = transform.position + new Vector3(availableDirection.x, availableDirection.y);


                float distance = (ghostPacman.target.position - newPosition).sqrMagnitude;

                if (distance > maxDistance)
                {
                    direction = availableDirection;
                    maxDistance = distance;
                }

            }



            ghostPacman.movement.SetDirection(direction);

            // Rotate pacman to face the movement direction

        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
    //     {
    //         if (enabled)
    //         {
    //             Eaten();
    //         }
    //     }
    // }

}
