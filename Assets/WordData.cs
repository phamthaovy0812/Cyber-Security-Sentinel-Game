using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordData : MonoBehaviour
{
    private static WordData instance;                             //instance variable
	public static WordData Instance { get => instance; }
    private void Awake()
	{
		if (instance == null)                                               //if instance is null
		{
			instance = this;                                                //set this as instance																// DontDestroyOnLoad(gameObject);                                                          // DontDestroyOnLoad(gameObject);                                  //make it DontDestroyOnLoad
		}
		else
		{
			Destroy(gameObject);                                            //else destroy it
		}
	}
    public List<WordList> WordListData()
     {
          List<WordList> listWord = new List<WordList>();

          // level 1
          string[] wordList1 = {"security","firewall","vulnerability","breach", "privacy", "cyber", "threat","risk","intrusion","password",
        "biometrics", "access", "control", "secure","network","response", 
        "phishing","social","engineering", "hacker", "data", "identity","theft",  "key","policy","communication",  "audit",
//      "surveillance", "compliance", "incident", "software", "information", "technology",
//     "patching", "monitoring", "cyber security", "awareness",
//       "detection", "prevention", "malware", "ransomware",
//       "protection", "defense", "safeguard", "encryption",

   };
          string[] wishedList1 = {
        "firewall","network","policy","risk","phishing"
   };
          listWord.Add(new WordList(1, wordList1, wishedList1));

          // level 2
          string[] wordList2 = {"countermeasure", "crimeware", "cron", "cryptanalysis",
       "daemon", "datagram", "decapsulation", "decryption",
       "defacement", "disassembly", "disruption", "domain",
        "dumpsec", "eavesdropping", "encapsulation", "encryption",
         "ethernet", "event", "exposure", "filter", "finger",
         "fingerprinting", "firewall", "flooding", "forest",
          "fragmentation", "frames", "fuzzing", "gateway",
           "gnutella", "hardening", "header", "honeymonkey", "hops", 
    //   "host", "https", "hub", "hyperlink", "identity", "incident", 
   };
          string[] wishedList2 = {
        "eavesdropping","fragmentation","hardening","fuzzing","crimeware"
   };
          listWord.Add(new WordList(2, wordList2, wishedList2));

          // level 3
          string[] wordList3 = { "applet", "algorithm", "arpanet", "auditing", "authentication",
        "authenticity", "authorization", "availability", "backdoor",
        "bandwidth", "banner", "bind", "biometrics",
        "bit", "botnet", "bridge", "broadcast", "browser",
        "rootkit", "router", "safety", "scavenging",
         "plaintext", "polymorphism", "polyinstantiation",
          "protocol", "ransomware", "reconnaissance", "registry",
   };
          string[] wishedList3 = {
        "authorization","availability","reconnaissance","polymorphism","protocol"
   };
          listWord.Add(new WordList(3, wordList3, wishedList2));
          // level 4
          string[] wordList4 = {"possession", "preamble", "protocol", "ransomware",
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
          string[] wishedList4 = {
        "scavenging","signature","synchronization","virus","server"
   };
          listWord.Add(new WordList(4, wordList4, wishedList4));

          return listWord;
     }

     public bool isFindWordInArray(string word, string[] listword)
     {
          List<string> list = listword.ToList();
          return list.Contains(word);
     }
}
