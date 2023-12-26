using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = {
        "security", "protection", "defense", "safeguard", "encryption",
        "authentication", "authorization", "firewall", "vulnerability","breach",
        "breach", "privacy", "cyber", "threat", "risk",
        "intrusion", "detection", "prevention", "malware", "ransomware",
        "password", "biometrics", "access", "control", "secure",
        "network", "surveillance", "encryption", "compliance", "incident",
        "response", "patching", "monitoring", "cybersecurity", "awareness",
        "phishing", "social", "engineering", "hacker", "data",
        "identity", "theft", "encryption", "key", "privacy",
        "policy", "secure", "software", "information", "technology",
        "secure", "communication",  "audit", 
   };

    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];
        return randomWord;
    }
}
