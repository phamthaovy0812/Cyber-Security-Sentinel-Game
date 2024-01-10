using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    public TMP_Text text;
    public GameObject word1;
    public GameObject word2;
    public GameObject word3;
    public GameObject word4;
    public GameObject word5;
    public float fallSpeed = 1f;
   

    public void SetWord (string word){
        text.text=word;
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
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) {
            WordManager.instance.GameOver();
        }
    }

      private void CheckAndActivateWord()
    {
         //firewall, network, policy, risk, phishing
        if (text.text.ToLower() == "firewall")
        {
            word1.SetActive(true);
        }
         if (text.text.ToLower() == "network")
        {
            word2.SetActive(true);
        }
         if (text.text.ToLower() == "policy")
        {
            word3.SetActive(true);
        }
         if (text.text.ToLower() == "risk")
        {
            word4.SetActive(true);
        }
         if (text.text.ToLower() == "phishing")
        {
            word5.SetActive(true);
        }
    }
    
}
