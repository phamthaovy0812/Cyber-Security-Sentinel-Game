using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    //firewall, network, policy, risk, phishing
    private static string[] wordList = {
        "security", "protection", "defense", "safeguard", "encryption",
        "authentication", "authorization", "firewall", "vulnerability",
        "breach", "privacy", "cyber", "threat", "risk",
        "intrusion", "detection", "prevention", "malware", "ransomware",
        "password", "biometrics", "access", "control", "secure",
        "network", "surveillance", "compliance", "incident",
        "response", "patching", "monitoring", "cybersecurity", "awareness",
        "phishing", "social", "engineering", "hacker", "data",
        "identity", "theft",  "key",
        "policy", "software", "information", "technology",
        "communication",  "audit", "hihi"
   };

    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];
        // after random, remove this word in list
        wordList = wordList.Where((val,idx) => idx!= randomIndex).ToArray();
        return randomWord;
    }
}
