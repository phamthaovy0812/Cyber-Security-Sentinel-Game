using UnityEngine;
using UnityEngine.Tilemaps;

public class Answer : MonoBehaviour
{
    public float destructionTime = 1f;
    [Range(0f, 1f)]
    public float itemSpawnChance = 0.2f;
    public GameObject[] spawnableItems;


    private void Start()
    {



    }


    private void OnDestroy()
    {
        if (spawnableItems.Length > 0)
        {
            int randomIndex = Random.Range(0, spawnableItems.Length);
            Instantiate(spawnableItems[randomIndex], transform.position, Quaternion.identity);

        }

    }

}
