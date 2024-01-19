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

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0)
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
            Debug.Log("minSpawnTime: " + _minimumSpawnTime);
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
