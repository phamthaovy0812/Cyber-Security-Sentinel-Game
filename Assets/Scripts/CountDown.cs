using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{

    public TextMeshProUGUI countDownText;
    public GameObject gameObjDestroy;

    public float countdownTime = 0f; // Set the initial countdown time

    // Start is called before the first frame update

    // Hàm để bắt đầu countdown
    public void StartCountdown(int countDown)
    {
        countdownTime = countDown;
        // Use a coroutine to handle the countdown
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
        gameObjDestroy.SetActive(false);

    }
}
