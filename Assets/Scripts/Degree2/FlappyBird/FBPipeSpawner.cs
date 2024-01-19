using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBPipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 5f;
    [SerializeField] private float _heightRange = 2f;
    [SerializeField] private GameObject _pipe;

    private float _timer;
    private void Start()
    {
        SpawnPipe();
    }
    private void Update()
    {
        if(_timer > _maxTime)
        {
            SpawnPipe();
            _timer=0;
        }
        _timer+=Time.deltaTime;
    }
    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);

        // Destroy(pipe, 10f);
    }

}
