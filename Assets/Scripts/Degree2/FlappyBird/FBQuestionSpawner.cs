using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBQuestionSpawner : MonoBehaviour
{
    // [SerializeField] private float _maxTime = 10f;
    // [SerializeField] private float _heightRange = 5f;
    //  [SerializeField] private GameObject _coin;
    // private float _timer;
    // private void Start()
    // {
    //     SpawnCoin();
    // }
    // private void Update()
    // {
    //     if(_timer > _maxTime)
    //     {
    //         SpawnCoin();
    //         _timer=0;
    //     }
    //     _timer+=Time.deltaTime;
    // }
    // private void SpawnCoin()
    // {
    //     Vector3 spawnPos = transform.position + new Vector3(3, Random.Range(-_heightRange, _heightRange));
    //     GameObject coin = Instantiate(_coin, spawnPos, Quaternion.identity);
    // }
    [SerializeField] private float _maxTime = 10f;
    [SerializeField] private float _heightRange = 2f;
    [SerializeField] private GameObject _coinPrefab; // Use a separate prefab for the coin
    private float _timer;

    private void Start()
    {
        SpawnCoin();
    }

    private void Update()
    {
        if (_timer > _maxTime)
        {
            SpawnCoin();
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }

    private void SpawnCoin()
    {
        // Randomize the coin's y-position within the specified height range
        float randomY = Random.Range(-_heightRange, _heightRange);

        Vector3 spawnPos = transform.position + new Vector3(0, randomY, 0);

        // Instantiate the coin prefab at the random position
        GameObject coin = Instantiate(_coinPrefab, spawnPos, Quaternion.identity);

        // Ensure the coin has a Rigidbody2D component and add force for movement
        Rigidbody2D coinRb = coin.GetComponent<Rigidbody2D>();
        if (coinRb != null)
        {
            // Add some force to make the coin move (you may adjust the force as needed)
            coinRb.AddForce(Vector2.left * 200f);
        }
    }
}
