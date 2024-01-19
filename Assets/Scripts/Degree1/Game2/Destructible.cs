using UnityEngine;
using UnityEngine.Tilemaps;

public class Destructible : MonoBehaviour
{
    public float destructionTime = 1f;
    [Range(0f, 1f)]
    public float itemSpawnChance = 0.2f;
    public GameObject[] spawnableItems;
    public LayerMask explosionLayerMask;
    private Tilemap tilemap;



    private void Start()
    {
        Destroy(gameObject, destructionTime);

    }

    private void OnDestroy()
    {
        if (spawnableItems.Length > 0)
        {
            int randomIndex = Random.Range(0, spawnableItems.Length);
            // Debug.Log("positions x: " + transform.position.x + " positions y: " + transform.position.y);
            // Vector3 posItemAnswer = GameObject.FindGameObjectWithTag("Wall").transform.position;
            // Debug.Log("positions x: " + posItemAnswer.x + " positions y: " + posItemAnswer.y);
            if (!CompareTilePosition(transform.position))
            {
                Instantiate(spawnableItems[randomIndex], transform.position, Quaternion.identity);

            }
            else
            {
                Debug.Log("not successfully");
            }


        }

    }

    bool CompareTilePosition(Vector3 worldPosition)
    {
        tilemap = GameObject.FindGameObjectWithTag("Wall").GetComponent<Tilemap>();
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        TileBase tile = tilemap.GetTile(cellPosition);

        if (tile != null)
        {
            Debug.Log("There is a tile at position: " + cellPosition);
            return true;
        }
        else
        {
            Debug.Log("There is no tile at position: " + cellPosition);
            return false;

        }
    }

}
