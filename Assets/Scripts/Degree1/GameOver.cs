using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private static GameOver instance;                             //instance variable
    public static GameOver Instance { get => instance; }
    [SerializeField] private UnityEngine.UI.Image[] starsArray;
    [SerializeField] private TextMeshProUGUI titleGameOver;
    [SerializeField] private TextMeshProUGUI scoreText;

    // Start is called before the first frame update

    public void gameOver(bool isWin)
    {
        Time.timeScale = 0;

        Debug.Log("Game Over");
        if (isWin)
        {
            titleGameOver.text = "Chiến thắng";
            if (APIUser.Instance.GetUser().id_level == 1)
            {
                LevelSystemManager.Instance.LevelComplete(3);
                scoreText.text = "+180exp";
            }
        }
        else
        {
            titleGameOver.text = "Thất bại";
            LevelSystemManager.Instance.LevelComplete(0);

        }
        // SetStar(star);


    }
    private void SetStar(int starAchieved)
    {
        for (int i = 0; i < starsArray.Length; i++)             //loop through entire star array
        {

            if (i < starAchieved)
            {
                starsArray[i].GetComponent<UnityEngine.UI.Image>().color = Color.white;              //set its color to unlockColor
            }
            else
            {
                starsArray[i].GetComponent<UnityEngine.UI.Image>().color = Color.grey;                //else set its color to lockColor
            }
        }
    }

    private void Awake()
    {
        if (instance == null)                                               //if instance is null
        {
            instance = this;                                                //set this as instance                              //make it DontDestroyOnLoad
        }
        else
        {
            Destroy(gameObject);                                            //else destroy it
        }
    }

}
