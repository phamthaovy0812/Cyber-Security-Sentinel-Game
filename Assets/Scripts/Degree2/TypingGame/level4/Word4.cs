using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word4 
{
    public string word;
    private int typeIndex;
    WordDisplay4 display;
    public Word4 (string _word, WordDisplay4 _display){
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
