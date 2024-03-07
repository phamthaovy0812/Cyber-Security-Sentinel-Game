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
    [SerializeField] private int idGame;
    LevelData levelData;
    int indexItem;


    public void gameOver(int star)
    {
        Time.timeScale = 0;
        indexItem = LevelSystemManager.Instance.CurrentLevel;
        levelData = APIUser.Instance.GetLevelData(idGame);
        Debug.Log("Game Over");
        Debug.Log("index Item: " + indexItem);
        if (star > 0)
        {
            titleGameOver.text = "Chiến thắng";
            if (idGame == 1)
            {
                if (star > levelData.levelItemsArray[indexItem].starAchieved)
                {
                    scoreText.text = "+" + ((star - APIUser.Instance.GetLevelData(idGame).levelItemsArray[indexItem].starAchieved) * 112) + "exp";
                }
                else
                {
                    scoreText.text = "";
                }

            }
            else if (idGame == 2)
            {
                int scoreDegree2 = levelData.levelItemsArray[indexItem].starAchieved;
                Debug.Log("score degree 2: " + scoreDegree2);

                int point = 0;
                if (star > scoreDegree2)
                {

                    if (star == 3)
                    {

                        if (scoreDegree2 == 2)
                        {
                            point = 100;
                        }
                        else if (scoreDegree2 == 1)
                        {
                            point = 200;
                        }
                        else
                        {
                            point = 500;
                        }

                    }
                    else if (star == 2)
                    {


                        if (scoreDegree2 == 1)
                        {
                            point = 100;
                        }
                        else
                        {
                            point = 400;
                        }
                    }
                    else if (star == 1)
                    {


                        point = 300;
                    }
                    scoreText.text = "+" + point + " exp";
                }

                else
                {

                    scoreText.text = "";
                }


            }
            else if (idGame == 3)
            {
                // if ()
                int scoreDegree3 = levelData.levelItemsArray[indexItem].starAchieved;
                int point3 = 0;
                if (star > scoreDegree3)
                {
                    if (star == 3)
                    {
                        if (scoreDegree3 == 2)
                        {
                            point3 = 100;
                        }
                        else if (scoreDegree3 == 1)
                        {
                            point3 = 200;
                        }
                        else
                        {
                            point3 = 500;
                        }

                    }
                    else if (star == 2)
                    {
                        if (scoreDegree3 == 1)
                        {
                            point3 = 100;
                        }
                        else
                        {
                            point3 = 400;
                        }
                    }
                    else if (star == 1)
                    {
                        point3 = 300;
                    }
                    scoreText.text = "+" + point3 + "exp";
                }
                else
                {
                    scoreText.text = "";
                }
            }


        }
        else
        {
            titleGameOver.text = "Thất bại";
            scoreText.text = "";

        }
        SetStar(star);
        LevelSystemManager.Instance.LevelComplete(star);
    }
    IEnumerable UpFirebase(int star)
    {
        yield return new WaitForSeconds(1);

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
        levelData = APIUser.Instance.GetLevelData(idGame);
        if (instance == null)                                               //if instance is null
        {
            instance = this;
            //set this as instance                              //make it DontDestroyOnLoad
        }
        else
        {
            Destroy(gameObject);                                            //else destroy it
        }
    }

}
