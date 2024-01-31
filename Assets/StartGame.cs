using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public TextMeshProUGUI countDownText;
    public GameObject gameObjDestroy;
    public GameObject enemy;

    public float countdownTime = 3; // Set the initial countdown time

    // Start is called before the first frame update

    // Hàm để bắt đầu countdown
    public void Start()
    {
        // Use a coroutine to handle the countdown
        // FindAnyObjectByType<MoveEnemy>().enabled = false;
        FindAnyObjectByType<MovementPacman>().enabled = false;
        enemy.SetActive(false);
        // FindAnyObjectByType<GhostPacmanFrightened>().enabled = false;
        // FindAnyObjectByType<GhostPacman>().enabled = false;

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
        // FindAnyObjectByType<MoveEnemy>().enabled = true;
        FindAnyObjectByType<MovementPacman>().enabled = true;
        // FindAnyObjectByType<GhostPacmanFrightened>().enabled = true;
        // FindAnyObjectByType<GhostPacman>().enabled = true;
        enemy.SetActive(true);
        gameObjDestroy.SetActive(false);

    }
}
