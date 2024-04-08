using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class wishedListPrefab : MonoBehaviour
{
    public TextMeshProUGUI wishedlistText;
    public List<string> wishedList;
    void Start()
    {
        wishedList = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        string list = "";
        foreach (string item in wishedList)
        {
            list += item + "\n";
        }
        wishedlistText.text = list;
    }
}
