using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput2 : MonoBehaviour
{
    public WordManager2 wordManager;
    // Update is called once per frame
    void Update()
    {
        foreach (char letter in Input.inputString){
            Debug.Log(letter);
            wordManager.TypeLetter(letter);
        }
        
    }
}
