using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
// public int count=0;
public class WordDisplay : MonoBehaviour
{
    public TMP_Text text;
    private string check;
    // public GameObject openSecurity;
        [SerializeField] private AudioClip wish, clearWord;

    public float fallSpeed = 1f;

    public void Start()
    {
        gameObject.SetActive(true);

    }

    public void SetWord(string word)
    {
        text.text = word;
        check = word;
    }

    public void RemoveLetter()
    {
     
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }
    public void RemoveWord()
    {
 
        WordScore.instance.UpdateScore();
        SoundPlay.Instance.PlaySound(clearWord);
        CheckAndActivateWord();
        gameObject.SetActive(false);
    }


    private void Update()
    {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
    }


    private void CheckAndActivateWord()
    {
        int count = FindAnyObjectByType<WordManager>().count;
        if (count == 5)
        {
            FindAnyObjectByType<WordManager>().openSecurity.SetActive(true);
            FindAnyObjectByType<WordManager>().word.SetActive(false);

        }
        //firewall, network, policy, risk, phishing
        if (WordData.Instance.isFindWordInArray(check, WordData.Instance.WordListData()[LevelSystemManager.Instance.CurrentLevel].wishedList))
        {
            SoundPlay.Instance.PlaySound(wish);
            FindAnyObjectByType<WordManager>().count += 1;
            FindAnyObjectByType<wishedListPrefab>().wishedList.Add(check);

        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("va cham ne");
            FindObjectOfType<WordManager>().GameOver(false);
        }
    }

}
