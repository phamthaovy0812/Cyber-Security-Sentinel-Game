using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Extensions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystemManager : MonoBehaviour
{
    [SerializeField] private static LevelSystemManager instance;                             //instance variable
    public static LevelSystemManager Instance { get => instance; }          //instance getter

    [Tooltip("Set the default Level data so when game start 1st time, this data will be saved")]
    [SerializeField] private LevelData levelData;

    public LevelData LevelData { get => levelData; set => levelData = value; }   //getter

    private int currentLevel;
    public int sceneBuildIndex;
    public int idGame;            //ref to grid holder
                                  //keep track of current level player is playing
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }   //getter and setter for currentLevel

    private void Awake()
    {
        // SaveLoadData.Instance.LoadData();

        Debug.Log("LoadData in level system manager");
        if (instance == null)                                               //if instance is null
        {
            instance = this;                                                //set this as instance
            DontDestroyOnLoad(gameObject);                                  //make it DontDestroyOnLoad
        }
        else
        {
            Destroy(gameObject);                                            //else destroy it
        }
    }

    public void OnClickExit()
    {
        Time.timeScale = 1;
        SaveLoadData.Instance.SaveData();
        SaveLoadData.Instance.LoadData();
        // load the previous scene
        if (idGame == 1)
        {
            SceneManager.LoadScene("Degree1Game2");
        }
        if (idGame == 2)
        {
            SceneManager.LoadScene("TypingHome");
        }
        if (idGame == 3)
        {
            SceneManager.LoadScene("Degree3Game1");
        }

    }

    // private void OnEnable()
    // {
    //     SaveLoadData.Instance.Initialize();
    // }
    public int getCurrentLevel()
    {
        return currentLevel;
    }

    public void LevelComplete(int starAchieved)                             //method called when player win the level
    {

        if (starAchieved > APIUser.Instance.GetLevelData(idGame).levelItemsArray[currentLevel].starAchieved)
        {
            // xuwr lys update diem cho user
            int score = starAchieved - APIUser.Instance.GetLevelData(idGame).levelItemsArray[currentLevel].starAchieved;
            if (idGame == 1)
            {
                APIUser.Instance.UpdateExperiences(score * 112);

            }
            else if (idGame == 2)
            {
                int scoreDegree2 = APIUser.Instance.GetLevelData(idGame).levelItemsArray[currentLevel].starAchieved;
                int point = 0;
                if (starAchieved == 3)
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
                else if (starAchieved == 2)
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
                else if (starAchieved == 1)
                {
                    point = 300;
                }

                APIUser.Instance.UpdateExperiences(point);

            }
            else if (idGame == 3)
            {
                // if ()
                int scoreDegree3 = APIUser.Instance.GetLevelData(idGame).levelItemsArray[currentLevel].starAchieved;
                int point3 = 0;
                if (starAchieved == 3)
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
                else if (starAchieved == 2)
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
                else if (starAchieved == 1)
                {
                    point3 = 300;
                }

                APIUser.Instance.UpdateExperiences(point3);

            }
            levelData.levelItemsArray[currentLevel].starAchieved = starAchieved;
        }
        //save the stars achieved by the player in level
        if (levelData.lastUnlockedLevel <= (currentLevel + 1) && (currentLevel + 1) < APIUser.Instance.GetLevelData(idGame).levelItemsArray.Length && starAchieved > 0) //&& starAchieved > 0
        {
            levelData.lastUnlockedLevel = currentLevel + 1;           //change the lastUnlockedLevel to next level                                                    //and make next level unlock true
            levelData.levelItemsArray[levelData.lastUnlockedLevel].unlocked = true;

        }
        SaveLoadData.Instance.SaveData();
        SaveLoadData.Instance.LoadData();
    }

}
