using System.Collections;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        ExtraBomb,
        BlastRadius,
        SpeedIncrease,
        IncreaseTime,
    }

    public ItemType type;

    public void OnItemPickup()
    {
        switch (type)
        {
            case ItemType.ExtraBomb:
                FindAnyObjectByType<BombController>().AddBomb();

                break;

            case ItemType.BlastRadius:
                FindAnyObjectByType<BombController>().AddRadius();
                break;

            case ItemType.SpeedIncrease:
                FindAnyObjectByType<MovementController>().AddSpeed();
                break;
            case ItemType.IncreaseTime:
                Debug.Log("Speed increase");
                FindObjectOfType<BBCountDownGamePlay>().AddTimer(10);
                break;
        }

        // Destroy(gameObject);
        StartCoroutine(detroy());
    }
    void Start()
    {
        OnItemPickup();
    }
    IEnumerator detroy()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         OnItemPickup(other.gameObject);
    //     }
    // }

}
