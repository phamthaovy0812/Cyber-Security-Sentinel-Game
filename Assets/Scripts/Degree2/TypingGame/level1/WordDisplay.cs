using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
// public int count=0;
public class WordDisplay : MonoBehaviour
{
    public TMP_Text text;
    private string check ;
    public GameObject word1;
    public GameObject word2;
    public GameObject word3;
    public GameObject word4;
    public GameObject word5;
    // public GameObject openSecurity;
    public float fallSpeed = 1f;
   
   public void Start()
   {
   
   }

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
        int count = FindAnyObjectByType<WordManager>().count;
        if ( count == 5){
           FindAnyObjectByType<WordManager>().openSecurity.SetActive(true);
        FindAnyObjectByType<WordManager>().word.SetActive(false);

        }
         //firewall, network, policy, risk, phishing
        if (check == "firewall")
        {
            count++;
            Debug.Log(count);
            word1.SetActive(true);
        }
         if (check == "network")
        {
            count++;
            Debug.Log(count);
            word2.SetActive(true);
        }
         if (check == "policy")
        {
            count++;
            Debug.Log(count);
            word3.SetActive(true);
        }
         if (check == "risk")
        {
            count++;
            Debug.Log(count);
            word4.SetActive(true);
        }
         if (check == "phishing")
        {
            count++;
            Debug.Log(count);
            word5.SetActive(true);
        }
        FindAnyObjectByType<WordManager>().count=count;

    }
    
}
