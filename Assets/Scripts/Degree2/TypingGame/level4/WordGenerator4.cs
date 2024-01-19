using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordGenerator4 : MonoBehaviour
{
    //firewall, network, policy, risk, phishing
    private static string[] wordList = {
        "possession", "preamble", "protocol", "ransomware",
         "reconnaissance", "registry", "response", 
         "risk", "root", "rootkit", "router", "safety",
          "scavenging", "segment", "server", "session", 
          "share", "shell", "signature", "smartcard",
           "smishing", "smurf", "sniffer", "sniffing",
            "socket", "socks", "software", "spam", "spoof",
             "stealthing", "steganalysis", "steganography", 
             "stimulus", "switch", "syslog", "synchronization", 
             "tamper", "tcp", "threat", "token", "topology",
              "traceroute", "trunking", "trust", "tunnel",
               "unicast", "unix", "virus", "vishing", "whois",
         "windump", "wiretapping", "wireless", "worm", "zombies"
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
