using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    //firewall, network, policy, risk, phishing
    private static string[] wordList = {
        "security",
        "firewall", 
        "vulnerability",
         "breach", "privacy", "cyber", "threat",
         "risk",
        "intrusion",
        "password", 
        "biometrics", "access", "control", "secure",
        "network", 
        "response", 
        "phishing",
         "social", 
        "engineering", "hacker", "data",
       "identity", "theft",  "key",
        "policy", 
       "communication",  "audit",
     "surveillance", "compliance", "incident", "software", "information", "technology",
    // "patching", "monitoring", "cybersecurity", "awareness",
      "detection", "prevention", "malware", "ransomware",
     //  "protection", "defense", "safeguard", "encryption",

   };

    public static string GetRandomWord()
    {
        if (wordList == null || wordList.Length==0){
            return null;
        }
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];
        // after random, remove this word in list
        wordList = wordList.Where((val,idx) => idx!= randomIndex).ToArray();
        return randomWord;
    }
}
