using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BBStartGame : MonoBehaviour
{
    public TextMeshProUGUI countDownText;
    public GameObject gameObjDestroy;

    public float countdownTime = 3; // Set the initial countdown time


    // Hàm để bắt đầu countdown
    public void Start()
    {
        FindAnyObjectByType<STEnemySpawner>().enabled = false;
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        float currentTime = countdownTime;

        while (currentTime > 0)
        {
            // Update the UI text with the current countdown time
            countDownText.text = currentTime.ToString("0");

            // Wait for one second
            yield return new WaitForSeconds(1f);

            // Decrease the countdown time
            currentTime--;

        }
        countDownText.text = "BẮT ĐẦU !";
        yield return new WaitForSeconds(1f);
        FindAnyObjectByType<STEnemySpawner>().enabled = true;

        gameObjDestroy.SetActive(false);

    }
}
