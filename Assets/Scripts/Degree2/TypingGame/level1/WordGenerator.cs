using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class WordGenerator : MonoBehaviour
{
    //firewall, network, policy, risk, phishing
    public string[] wordList;
    public void Start()
    {
        wordList = WordData.Instance.WordListData()[LevelSystemManager.Instance.CurrentLevel].listWords;
    }
    public string GetRandomWord()
    {

        if (wordList == null || wordList.Length == 0)
        {
            return null;
        }
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];
        // after random, remove this word in list
        wordList = wordList.Where((val, idx) => idx != randomIndex).ToArray();
        return randomWord;
    }
}
