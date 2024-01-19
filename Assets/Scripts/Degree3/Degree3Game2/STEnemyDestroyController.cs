
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STEnemyDestroyController : MonoBehaviour
{
    public void DestroyEnemy(float delay)
    {
        Destroy(gameObject, delay);
    }
}
