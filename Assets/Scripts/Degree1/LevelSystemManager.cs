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

    public LevelData LevelData { get => levelData; }   //getter

    private int currentLevel;
    public int sceneBuildIndex;                                           //keep track of current level player is playing
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }   //getter and setter for currentLevel


    private void Start()
    {

        FirebaseDatabase.DefaultInstance.GetReference("Users").GetValueAsync().ContinueWithOnMainThread((task) =>
       {

           if (task.IsFaulted)
           {
               Debug.Log("error read desk data");
           }
           else if (task.IsCompleted)
           {
               DataSnapshot snapshot = task.Result;
               Debug.Log(snapshot.ChildrenCount);
               if (snapshot.ChildrenCount > 0)
               {
                   foreach (DataSnapshot snapshotChild in snapshot.Children)
                   {
                       try
                       {
                           //    User user = JsonUtility.FromJson<User>(snapshotChild.GetRawJsonValue());
                           //    string t = JsonUtility.ToJson(user);
                           //    Debug.Log(snapshotChild.GetRawJsonValue().ToString());
                           string str = snapshotChild.GetRawJsonValue();
                           Debug.Log("str = " + str);



                       }
                       catch (System.Exception ex)
                       {
                           Debug.Log(snapshotChild.Key);
                           Debug.Log(snapshotChild.Value);
                           Debug.Log(ex.Data);
                           Debug.Log(ex.Message);
                       }
                   }
               }
           }
       }
        );

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        var json = JsonUtility.ToJson(new User());
        reference.Child("test2").Child("test2").SetRawJsonValueAsync(json);
        // User user = new User("",",","","","",100);
        // string json = JsonUtility.ToJson(user);
        // DatabaseReference dbRef = FirebaseDatabase.DefaultInstance.RootReference;
        // dbRef.Child("Users").Child("SystemInfo.deviceUniqueIdentifier").Push().SetRawJsonValueAsync(json);

        FirebaseDatabase.DefaultInstance
  .GetReference("ScoreDegree").Child(SystemInfo.deviceUniqueIdentifier)
  .GetValueAsync().ContinueWithOnMainThread(task =>
  {
      if (task.IsFaulted)
      {
          Debug.Log("No read data from database");
      }
      else if (task.IsCompleted)
      {
          DataSnapshot snapshot = task.Result;


          foreach (DataSnapshot item in snapshot.Children)
          {
              int score = item.Value.ConvertTo<int>();
              if (score == -1)
              {

              }
              // Debug.Log("Data snapshot: " + item.Value);

          }

          // Do something with snapshot...
      }
  });

    }
    private void Awake()
    {
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
        Debug.Log("exit successfully");
        // load the previous scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void Update()
    {
        SaveLoadData.Instance.LoadData();
    }

    private void OnEnable()
    {
        SaveLoadData.Instance.Initialize();
    }

    public void LevelComplete(int starAchieved, float score)                             //method called when player win the level
    {
        levelData.levelItemsArray[currentLevel].starAchieved = starAchieved;
        if (score > levelData.levelItemsArray[currentLevel].score)
        {
            levelData.levelItemsArray[currentLevel].score = score;
        }

        //save the stars achieved by the player in level
        if (levelData.lastUnlockedLevel <= (currentLevel + 1))
        {
            levelData.lastUnlockedLevel = currentLevel + 1;           //change the lastUnlockedLevel to next level                                                    //and make next level unlock true
            levelData.levelItemsArray[levelData.lastUnlockedLevel].unlocked = true;

        }
        SaveLoadData.Instance.SaveData();
    }

}
