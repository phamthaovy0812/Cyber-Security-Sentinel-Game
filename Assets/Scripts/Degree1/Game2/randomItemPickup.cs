using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class randomItemPickup : MonoBehaviour
{
    public float destructionTime = 1f;
    [Range(0f, 1f)]
    public float itemSpawnChance = 0.2f;
    public GameObject[] spawnableItems;

    private void OnDestroy()
    {
        if (spawnableItems.Length > 0)
        {
            int randomIndex = Random.Range(0, spawnableItems.Length);
            Vector2 positionItem = transform.position;
            positionItem.y += 0.5f;
            GameObject item = Instantiate(spawnableItems[randomIndex], positionItem, Quaternion.identity);

        }

    }
    private void Start()
    {
        Destroy(gameObject, destructionTime);

    }
    IEnumerator destroy(GameObject item)
    {
        yield return new WaitForSeconds(2f);
        Destroy(item);
    }

    // IEnumerator DelayDestroyItem()
    // {

    //     yield return new WaitForSeconds(1.5f);
    //     int randomIndex = Random.Range(0, spawnableItems.Length);
    //     Vector2 positionItem = transform.position;
    //     positionItem.y += 0.5f;
    //     var thisObject = Instantiate(spawnableItems[randomIndex], positionItem, Quaternion.identity);
    //     // yield return new WaitForSeconds(1f);
    //     // Destroy(thisObject);
    //     // Destroy(gameObject);
    // }

}
