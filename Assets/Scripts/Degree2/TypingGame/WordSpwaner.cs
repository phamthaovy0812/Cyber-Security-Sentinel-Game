using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpwaner : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;

    private float range1 =8f;
    private float range2 = 7f;
    // [SerializeField] private float _maxTime = 1f;
    // [SerializeField] private float _widthRange = 2f;
    // [SerializeField] private GameObject _word;
    // private float _timer;

    // private void Update()
    // {
    //     if (_timer > _maxTime)
    //     {
    //         SpawnWord();
    //         _timer = 0;
    //     }
    //     _timer += Time.deltaTime;
    // }
    // public WordDisplay SpawnWord()
    // {
    //     Vector3 spawnPos = transform.position + new Vector3(Random.Range(-_widthRange, _widthRange), 0);
    //     GameObject wordObj = Instantiate(_word, spawnPos, Quaternion.identity);
    //     WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
    //     return wordDisplay;
    //     // Destroy(pipe, 10f);
    // }

    public WordDisplay SpawnWord()
    {
        Vector3 randomPosition = new Vector3 ( Random.Range(-range1, range1), range2);

        GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
        // GameObject wordObj = Instantiate(wordPrefab, wordCanvas);

        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
        return wordDisplay;

    }
}
