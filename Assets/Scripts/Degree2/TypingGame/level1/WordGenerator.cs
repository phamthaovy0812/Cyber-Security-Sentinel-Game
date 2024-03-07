using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WordGenerator : MonoBehaviour
{
    [SerializeField] private static WordGenerator instance;                             //instance variable
    public static WordGenerator Instance { get => instance; }
    //firewall, network, policy, risk, phishing
    public string[] wordList;
    public void Awake()
    {
        Debug.Log("current instance: " + LevelSystemManager.Instance.CurrentLevel);
        wordList = WordData.Instance.WordListData()[LevelSystemManager.Instance.CurrentLevel].listWords;
        // SetWordList();
        if (instance == null)                                               //if instance is null
        {
            instance = this;                                                //set this as instance
            // DontDestroyOnLoad(gameObject);                                  //make it DontDestroyOnLoad
        }
        else
        {
            Destroy(gameObject);                                            //else destroy it
        }
    }
    public void SetWordList()
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
    // void OnDestroy()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }
}
