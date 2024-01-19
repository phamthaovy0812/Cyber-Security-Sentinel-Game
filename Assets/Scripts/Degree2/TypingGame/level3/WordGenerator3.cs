using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordGenerator3 : MonoBehaviour
{
    //firewall, network, policy, risk, phishing
    private static string[] wordList = {
       "applet", "algorithm", "arpanet", "auditing", "authentication",
        "authenticity", "authorization", "availability", "backdoor", 
        "bandwidth", "banner", "bind", "biometrics",
        "bit", "botnet", "bridge", "broadcast", "browser", 
        "rootkit", "router", "safety", "scavenging",
         "plaintext", "polymorphism", "polyinstantiation", 
          "protocol", "ransomware", "reconnaissance", "registry", 
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
