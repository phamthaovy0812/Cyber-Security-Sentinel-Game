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

    private void Start()
    {
   
    }
    public void AddWord()
    {
        // WordDisplay wordDisplay = wordSpwaner.SpawnWord();
        Word word = new Word(WordGenerator.GetRandomWord(),wordSpwaner.SpawnWord());
        Debug.Log(word.word);
        words.Add(word);
    }
    public void TypeLetter (char letter){
        if ( hasActiveWord){
            // check if letter was net 
            // remove it from the word
            if(activateWord.GetNextLetter()==letter){
                activateWord.TypeLetter();
            }
        }
        else {
            foreach(Word word in words){
                if (word.GetNextLetter()== letter){
                    activateWord=word;
                    hasActiveWord=true;
                    word.TypeLetter();
                    break;
                }
            }
        }

        if(hasActiveWord && activateWord.WordTyped()){
            hasActiveWord = false;
            words.Remove(activateWord);
        }
    }
    public void GameOver(){
        _gameOver.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // SceneManager.LoadScene(WordConstants.DATA.HOME_TYPING);
    }
}
