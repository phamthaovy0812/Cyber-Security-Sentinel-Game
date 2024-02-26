using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;



public class SaveLoadData : MonoBehaviour
{
    private static SaveLoadData instance;

    public static SaveLoadData Instance { get => instance; }
    LevelData levelData;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Method to initialize the SaveLoad Script
    public void Initialize()
    {
        // SaveData();
        // ClearData();
        // LoadData();
        if (PlayerPrefs.GetInt("GameStartFirstTime") == 1)  //if PlayerPrefs of "GameStartFirstTime" value is 1, means we are playing the game again
        {
            LoadData();                                     //so we load the data
        }
        else                                                //if its not 1, means we are playing the game 1st time
        {
            SaveData();                                     //save the data 1st
            PlayerPrefs.SetInt("GameStartFirstTime", 1);    //save the PlayerPrefs
        }
    }

    //this is Unity method which is called when game is crashed or in background or quit
    private void OnApplicationPause(bool pause)
    {
        // SaveData();                                 //great for saving the data. Note: In editor doesnt work correctly, but works great in Build
    }

    /// <summary>
    /// Method used to save the data
    /// </summary>
    public async void SaveData()
    {
        //convert the data to string

        string levelDataString = JsonUtility.ToJson(LevelSystemManager.Instance.LevelData);
        if (LevelSystemManager.Instance.idGame == 1)
        {
            APIUser.Instance.SetLevelDataDegree1(LevelSystemManager.Instance.LevelData);

        }
        else
        {
            APIUser.Instance.SetLevelDataDegree3(LevelSystemManager.Instance.LevelData);

        }

        try
        {
            //save the string as json 
            DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
            // string json = JsonUtility.ToJson(degree);
            await reference.Child("ScoreDegree").Child(APIUser.Instance.GetUser().id_user).Child(LevelSystemManager.Instance.idGame.ToString()).SetRawJsonValueAsync(levelDataString);

        }
        catch (System.Exception e)
        {
            //if we get any error debug it
            Debug.Log("Error Saving Data:" + e);
            throw;
        }
    }

    //Method used to load the data
    public void LoadData()
    {
        try
        {

            //create LevelData from json
            if (levelData != null)
            {
                //set the LevelData of LevelSystemManager
                LevelSystemManager.Instance.LevelData.levelItemsArray = levelData.levelItemsArray;
                LevelSystemManager.Instance.LevelData.lastUnlockedLevel = levelData.lastUnlockedLevel;
            }
            // Debug.Log("path: " + Application.persistentDataPath);
            Debug.Log("Data Loaded");
        }
        catch (System.Exception e)
        {
            Debug.Log("Error Loading Data:" + e);
            throw;
        }

    }

    /// <summary>
    /// Method to clear all the save data
    /// </summary>
    public void ClearData()
    {
        Debug.Log("Data Cleared");
        LevelData levelData = new LevelData();
        SaveData();
        PlayerPrefs.SetInt("GameStartFirstTime", 1);
    }


}
[System.Serializable]
public class LevelData
{
    public int lastUnlockedLevel = 0;   //has referece to lastUnlockedLevel
    public LevelItem[] levelItemsArray;       //reference to level data
}

[System.Serializable]
public class LevelItem                  //level item
{
    public bool unlocked;
    public int starAchieved;
    public LevelItem()
    {
        unlocked = false;
        starAchieved = 0;
    }
    public LevelItem(bool unlock, int star)
    {
        this.unlocked = unlock;
        this.starAchieved = star;
    }
}


