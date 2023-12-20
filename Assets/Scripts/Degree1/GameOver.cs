using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private static GameOver instance;                             //instance variable
    public static GameOver Instance { get => instance; }
    public float score;
    public int index = 0;
    public int countFood = 0;
    int countStar;
    [SerializeField] private UnityEngine.UI.Image[] starsArray;
    [SerializeField] private GameObject overPanelGameOver;
    [SerializeField] private TextMeshProUGUI txtScore;
    // Start is called before the first frame update

    public void gameOver(float score)
    {
        Time.timeScale = 0;
        overPanelGameOver.SetActive(true);
        Debug.Log("Game Over");

        if (score >= 180)
        {
            countStar = 3;

        }
        else if (score >= 155)
        {
            countStar = 2;
        }
        else if (score >= 130)
        {
            countStar = 1;
        }
        else
        {
            countStar = 0;
        }
        if (countStar > 0)
        {
            LevelSystemManager.Instance.LevelComplete(countStar);
        }


        txtScore.text = score.ToString();
        SetStar(countStar);

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
                starsArray[i].GetComponent<UnityEngine.UI.Image>().color = Color.black;                //else set its color to lockColor
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
