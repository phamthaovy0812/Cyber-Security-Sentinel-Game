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

    // Start is called before the first frame update
    void Start()
    {


    }


    public void gameOver(int star)
    {
        Time.timeScale = 0;
        indexItem = LevelSystemManager.Instance.CurrentLevel;
        levelData = LevelSystemManager.Instance.LevelData;
        Debug.Log("Game Over");
        if (star > 0)
        {
            titleGameOver.text = "Chiến thắng";
            Debug.Log("levelData: " + JsonUtility.ToJson(levelData));

            Debug.Log("Star: " + star);
            Debug.Log("index item: " + indexItem);
            Debug.Log("id game: " + idGame);

            Debug.Log("star level: " + levelData.levelItemsArray[indexItem].starAchieved);
            if (star > levelData.levelItemsArray[indexItem].starAchieved)
            {
                scoreText.text = "+" + ((star - APIUser.Instance.GetLevelData(idGame).levelItemsArray[indexItem].starAchieved) * 112) + "exp";
            }
            else
            {
                scoreText.text = "";
            }
        }
        else
        {
            titleGameOver.text = "Thất bại";
            LevelSystemManager.Instance.LevelComplete(0);
            scoreText.text = "";

        }
        SetStar(star);
        LevelSystemManager.Instance.LevelComplete(star);


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
