using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpwaner4 : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;

    private float range1 =6f;
    private float range2 = 7f;

    public WordDisplay4 SpawnWord()
    {
        Vector3 randomPosition = new Vector3 ( Random.Range(-4, range1), range2);

        GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
        // GameObject wordObj = Instantiate(wordPrefab, wordCanvas);

        WordDisplay4 wordDisplay = wordObj.GetComponent<WordDisplay4>();
        return wordDisplay;

    }
}
