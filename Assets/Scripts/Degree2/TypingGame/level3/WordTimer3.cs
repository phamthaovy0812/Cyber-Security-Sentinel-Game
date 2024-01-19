using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer3 : MonoBehaviour
{
    public WordManager3 wordManager;
    public float wordDelay =2f;
    private float nextWordTime = 0f;

    private void Update()
    {
        if (Time.time >= nextWordTime){
            wordManager.AddWord();
            nextWordTime = Time.time + wordDelay;
            wordDelay *= .99f;
        }
    }
}
