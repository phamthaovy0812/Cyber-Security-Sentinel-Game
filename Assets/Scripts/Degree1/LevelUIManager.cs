using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class LevelUIManager : MonoBehaviour
{
    private static LevelUIManager instance;                             //instance variable
    public static LevelUIManager Instance { get => instance; }          //instance getter

    [SerializeField] private LevelBtnScript levelBtnPrefab;              //ref to LevelButton prefab
    [SerializeField] private Transform levelBtnGridHolder;
    [SerializeField] private int idGame;            //ref to grid holder

    private void Start()
    {
        Debug.Log("load level successfully");
        InitializeUI();
    }

    private void Awake()
    {
        LevelSystemManager.Instance.LevelData = APIUser.Instance.GetLevelData(idGame);

        if (instance == null)                                               //if instance is null
        {
            instance = this;                                                //set this as instance
        }
        else
        {
            Destroy(gameObject);                                            //else destroy it
        }
    }

    public void InitializeUI()                                             //method to create the level buttons
    {
        Debug.Log("Get level item array");

        LevelItem[] levelItemsArray = LevelSystemManager.Instance.LevelData.levelItemsArray;  //get the level data array

        for (int i = 0; i < levelItemsArray.Length; i++)                         //loop through entire array
        {
            LevelBtnScript levelButton = Instantiate(levelBtnPrefab, levelBtnGridHolder);    //create button for each element in array
                                                                                             //and set the button
            levelButton.SetLevelButton(levelItemsArray[i], i);
        }

        //create button for each element in array
        //and set the button

    }
}
