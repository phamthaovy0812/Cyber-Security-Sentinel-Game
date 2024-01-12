using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STCollectable : MonoBehaviour
{
    private STICollectableBehaviour _collectableBehaviour;

    private void Awake()
    {
        _collectableBehaviour = GetComponent<STICollectableBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<STPlayerMovement>();

        if (player != null)
        {
            _collectableBehaviour.OnCollected(player.gameObject);
            Destroy(gameObject);
        }
    }
}