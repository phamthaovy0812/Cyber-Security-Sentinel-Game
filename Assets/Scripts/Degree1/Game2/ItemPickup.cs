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

    private void OnItemPickup(GameObject player)
    {
        switch (type)
        {
            case ItemType.ExtraBomb:
                player.GetComponent<BombController>().AddBomb();

                break;

            case ItemType.BlastRadius:
                player.GetComponent<BombController>().AddRadius();
                break;

            case ItemType.SpeedIncrease:
                player.GetComponent<MovementController>().AddSpeed();
                break;
            case ItemType.IncreaseTime:
                Debug.Log("Speed increase");
                FindObjectOfType<BBCountDownGamePlay>().AddTimer(10);
                break;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnItemPickup(other.gameObject);
        }
    }

}
