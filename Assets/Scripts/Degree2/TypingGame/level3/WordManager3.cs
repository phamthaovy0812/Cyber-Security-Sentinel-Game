using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordManager3 : MonoBehaviour
{
    public List<Word3> words;
    private bool hasActiveWord;
    private Word3 activateWord;
    public WordSpwaner3 wordSpwaner;
    public GameObject _gameOver;
    public static WordManager3 instance;
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
            Word3 word = new Word3(WordGenerator3.GetRandomWord(), wordSpwaner.SpawnWord());
            Debug.Log("COunt" + count);
            words.Add(word);
        }
        else
        {
            word.SetActive(false);
            StartCoroutine(DelayedActivation(5f));
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
        Debug.Log("1");
        if (hasActiveWord)
        {
            Debug.Log("2");

            // check if letter was net 
            // remove it from the word
            if (activateWord.GetNextLetter() == letter)
            {
                activateWord.TypeLetter();
            }
        }
        else
        {
            Debug.Log("3");

            foreach (Word3 word in words)
            {
                Debug.Log("5");

                if (word.GetNextLetter() == letter)
                {
                    Debug.Log("6");

                    activateWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }

        if (hasActiveWord && activateWord.WordTyped())
        {
            Debug.Log("4");

            hasActiveWord = false;
            words.Remove(activateWord);
        }
    }
    public void GameOver()
    {
        _gameOver.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // SceneManager.LoadScene(WordConstants.DATA.HOME_TYPING);
    }
}
