using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordGenerator2 : MonoBehaviour
{
    //firewall, network, policy, risk, phishing
    private static string[] wordList = {
       "countermeasure", "crimeware", "cron", "cryptanalysis", 
       "daemon", "datagram", "decapsulation", "decryption", 
       "defacement", "disassembly", "disruption", "domain",
        "dumpsec", "eavesdropping", "encapsulation", "encryption",
         "ethernet", "event", "exposure", "filter", "finger", 
         "fingerprinting", "firewall", "flooding", "forest",
          "fragmentation", "frames", "fuzzing", "gateway",
           "gnutella", "hardening", "header", "honeymonkey", "hops", 
    //   "host", "https", "hub", "hyperlink", "identity", "incident", 
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
