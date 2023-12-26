using UnityEngine;

public class GhostPacmanScatter : GhostPacmanBehavior
{
    private void OnDisable()
    {
        ghostPacman.chase.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        NodePacman node = other.GetComponent<NodePacman>();

        // Do nothing while the ghostPacman is frightened
        if (node != null && enabled && !ghostPacman.frightened.enabled)
        {
            // Pick a random available direction
            int index = Random.Range(0, node.availableDirections.Count);

            // Prefer not to go back the same direction so increment the index to
            // the next available direction
            if (node.availableDirections.Count > 1 && node.availableDirections[index] == -ghostPacman.movement.direction)
            {
                index++;

                // Wrap the index back around if overflowed
                if (index >= node.availableDirections.Count)
                {
                    index = 0;
                }
            }

            ghostPacman.movement.SetDirection(node.availableDirections[index]);
        }
    }

}
