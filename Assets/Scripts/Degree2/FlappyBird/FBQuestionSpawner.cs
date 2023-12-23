using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBQuestionSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 10f;
    [SerializeField] private float _heightRange = 5f;
     [SerializeField] private GameObject _coin;
    private float _timer;
    private void Start()
    {
        SpawnCoin();
    }
    private void Update()
    {
        if(_timer > _maxTime)
        {
            SpawnCoin();
            _timer=0;
        }
        _timer+=Time.deltaTime;
    }
    private void SpawnCoin()
    {
        Vector3 spawnPos = transform.position + new Vector3(3, Random.Range(-_heightRange, _heightRange));
        GameObject coin = Instantiate(_coin, spawnPos, Quaternion.identity);
    }
}
