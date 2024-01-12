using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BBCountDownGamePlay : MonoBehaviour
{
    private float currentTime = 0f;
    [SerializeField] private float startingTime;
    [SerializeField] private float dangerTime;
    public TextMeshProUGUI countDownText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        // countDownText.text = currentTime.ToString("0");
        // isCountdownStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");
        if (currentTime < dangerTime)
        {
            countDownText.color = Color.red;
        }
        if (currentTime <= 0)
        {

            FindAnyObjectByType<MovementController>().DeathSequence();
            Destroy(gameObject);
        }

    }
    public void AddTimer(int time)
    {
        currentTime += time;
    }
}
