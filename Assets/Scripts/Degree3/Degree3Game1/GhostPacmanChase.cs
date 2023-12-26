using UnityEngine;

public class GhostPacmanChase : GhostPacmanBehavior
{
    private void OnDisable()
    {
        ghostPacman.scatter.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        NodePacman node = other.GetComponent<NodePacman>();

        // Do nothing while the ghostPacman is frightened
        if (node != null && enabled && !ghostPacman.frightened.enabled)
        {
            Vector2 direction = Vector2.zero;
            float minDistance = float.MaxValue;

            // Find the available direction that moves closet to pacman
            foreach (Vector2 availableDirection in node.availableDirections)
            {
                // If the distance in this direction is less than the current
                // min distance then this direction becomes the new closest
                Vector3 newPosition = transform.position + new Vector3(availableDirection.x, availableDirection.y);
                float distance = (ghostPacman.target.position - newPosition).sqrMagnitude;

                if (distance < minDistance)
                {
                    direction = availableDirection;
                    minDistance = distance;
                }
            }

            ghostPacman.movement.SetDirection(direction);
        }
    }

}
