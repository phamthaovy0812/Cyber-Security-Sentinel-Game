using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WordDisplay4 : MonoBehaviour
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
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     WordManager.instance.GameOver();
        
    // }
    //  private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Obstacle")) {
    //         WordManager.instance.GameOver();
    //     }
    // }

      private void CheckAndActivateWord()
    {
        int count = FindAnyObjectByType<WordManager4>().count;
        if ( count == 5){
            
           FindAnyObjectByType<WordManager4>().openSecurity.SetActive(true);

        }

         //firewall, network, policy, risk, phishing
        if (check == "scavenging")
        {
            Debug.Log("check word?");
            word1.SetActive(true);
        }
         if (check == "signature")
        {
            Debug.Log("check word?");
            word2.SetActive(true);
        }
         if (check == "synchronization")
        {
            Debug.Log("check word?");
            word3.SetActive(true);
        }
         if (check == "virus")
        {
            Debug.Log("check word?");
            word4.SetActive(true);
        }
         if (check == "server")
        {
            Debug.Log("check word?");
            word5.SetActive(true);
        }
        FindAnyObjectByType<WordManager4>().count=count;
    }
    
}
