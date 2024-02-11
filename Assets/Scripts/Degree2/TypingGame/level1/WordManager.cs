using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    private bool hasActiveWord;
    private Word activateWord;
    public WordSpwaner wordSpwaner;
    public GameObject _gameOver;
    public static WordManager instance;
    public GameObject openSecurity;
    public GameObject word;
    public int count = 0;
    public int countDraw = 0;
    public GameObject nextLevel;

    private void Start()
    {

    }
    private void Update()
    {
        if (countDraw == 5)
        {
            nextLevel.SetActive(true);
        }
    }
    public void AddWord()
    {
        // WordDisplay wordDisplay = wordSpwaner.SpawnWord();
        if (count < 5)
        {
            string wordStr = FindAnyObjectByType<WordGenerator>().GetRandomWord();
            Word word = new Word(wordStr, wordSpwaner.SpawnWord());
            words.Add(word);

        }
        else
        {
            word.SetActive(false);

            StartCoroutine(DelayedActivation(1f));
        }

    }
    private IEnumerator DelayedActivation(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Assuming "openSecurity" is a GameObject reference
        openSecurity.SetActive(true);
    }
    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {
            // check if letter was net 
            // remove it from the word
            if (activateWord.GetNextLetter() == letter)
            {
                activateWord.TypeLetter();
            }
        }
        else
        {
            foreach (Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activateWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }

        if (hasActiveWord && activateWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activateWord);
        }
    }
    public void GameOver(bool isWin)
    {
        float currentTime = FindAnyObjectByType<TPCountTime>().currentTime;
        Debug.Log("currentTime: " + currentTime);
        FindAnyObjectByType<TPCountTime>().isGameOver = true;
        _gameOver.SetActive(true);
        int star = 0;
        if (isWin)
        {
            if (currentTime < 180)
            {
                star = 3;
            }
            else if (currentTime < 240) star = 2;
            else if (star < 300)
            {
                star = 1;
            }
            FindAnyObjectByType<GameOver>().gameOver(star);
        }
        else
        {
            FindAnyObjectByType<GameOver>().gameOver(0);

        }

        // Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // SceneManager.LoadScene(WordConstants.DATA.HOME_TYPING);
    }

}
