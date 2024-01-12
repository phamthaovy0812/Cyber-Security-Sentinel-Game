using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class STHeathCollectableBehavior : MonoBehaviour, STICollectableBehaviour
{
    [SerializeField] private float _healthAmount;
    public void OnCollected(GameObject player)
    {
        player.GetComponent<STHealthController>().AddHealth(_healthAmount);
    }
}
