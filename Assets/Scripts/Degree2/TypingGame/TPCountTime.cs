using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCountTime : MonoBehaviour
{
    public float currentTime = 0f;
    public TMPro.TextMeshProUGUI countDownText;
    public bool isGameOver = false;
    void Start()
    {
        isGameOver = false;
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            currentTime += 1 * Time.deltaTime;
            countDownText.text = currentTime.ToString("0");
        }
    }
}
