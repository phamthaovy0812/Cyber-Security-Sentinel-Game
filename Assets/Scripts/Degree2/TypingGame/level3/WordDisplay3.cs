using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WordDisplay3 : MonoBehaviour
{
    public TMP_Text text;
    private string check ;
    public GameObject word1;
    public GameObject word2;
    public GameObject word3;
    public GameObject word4;
    public GameObject word5;
    public float fallSpeed = 1f;
   

    public void SetWord (string word){
        text.text=word;
        check= word;
    }

    public void RemoveLetter (){
        text.text = text.text.Remove(0,1);
        text.color = Color.red;
    }
    public void RemoveWord (){
        WordScore.instance.UpdateScore();
        CheckAndActivateWord();
        Destroy(gameObject);
    }


    private void Update()
    {
        transform.Translate(0f,-fallSpeed *Time.deltaTime,0f);
    }

      private void CheckAndActivateWord()
    {
        int count = FindAnyObjectByType<WordManager3>().count;
        if ( count == 5){
           FindAnyObjectByType<WordManager3>().openSecurity.SetActive(true);

        }

         //firewall, network, policy, risk, phishing
        if (check == "authorization")
        {
            Debug.Log("check word?");
            word1.SetActive(true);
        }
         if (check == "availability")
        {
            Debug.Log("check word?");
            word2.SetActive(true);
        }
         if (check == "reconnaissance")
        {
            Debug.Log("check word?");
            word3.SetActive(true);
        }
         if (check == "polymorphism")
        {
            Debug.Log("check word?");
            word4.SetActive(true);
        }
         if (check == "protocol")
        {
            Debug.Log("check word?");
            word5.SetActive(true);
        }
        FindAnyObjectByType<WordManager3>().count=count;
    }
    
}
