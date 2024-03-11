using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STEnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float _minimumSpawnTime = 10f;



    private float _timeUntilSpawn;
    public Transform enemyCanvas;
    public int countChildrenEnemy = 0;

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0)
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity, enemyCanvas);
            SetTimeUntilSpawn();
            countChildrenEnemy = enemyCanvas.transform.childCount;
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = _minimumSpawnTime;
    }
    public void setTime()
    {
        _minimumSpawnTime -= 1f;
    }


}
