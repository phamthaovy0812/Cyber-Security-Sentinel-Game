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
    // Start is called before the first frame update

    public void gameOver(int countCorrectAnswer)
    {
        Time.timeScale = 0;
        int star = 0;
        if (countCorrectAnswer <= 5)
        {
            star = 0;
        }
        else if (countCorrectAnswer <= 6)
        {
            star = 1;
        }
        else if (countCorrectAnswer <= 7)
        {
            star = 2;
        }
        else if (countCorrectAnswer <= 8)
        {
            star = 3;
        }
        Debug.Log("Game Over");

        SetStar(star);
        LevelSystemManager.Instance.LevelComplete(3);

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
