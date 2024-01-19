using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word2 
{
    public string word;
    private int typeIndex;
    WordDisplay2 display;
    public Word2 (string _word, WordDisplay2 _display){
        word= _word;
        typeIndex=0;

        display = _display;
        display.SetWord(word);
    }
    public char GetNextLetter (){
        return word[typeIndex];

    }
    public void TypeLetter(){
        typeIndex++;
        display.RemoveLetter();  
    }
    public bool WordTyped(){
        bool wordTyped = (typeIndex >=word.Length);
        if (wordTyped){
            display.RemoveWord();
        }
        return wordTyped;
    }
    
}
