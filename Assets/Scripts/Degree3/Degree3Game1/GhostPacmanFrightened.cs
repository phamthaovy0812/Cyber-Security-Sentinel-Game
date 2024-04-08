using UnityEngine;

public class GhostPacmanFrightened : GhostPacmanBehavior
{


    public override void Enable(float duration)
    {
        base.Enable(duration);

    }

    public override void Disable()
    {
        base.Disable();
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

    }

    private void OnDisable()
    {
        ghostPacman.movement.speedMultiplier = 1f;

    }

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


}
