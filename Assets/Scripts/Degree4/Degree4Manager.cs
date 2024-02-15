using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Degree4Manager : MonoBehaviour
{
    public GameObject room10;
    public GameObject room15;
    public GameObject room22;
    public GameObject room432;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LevelData levelData = APIUser.Instance.GetLevelData(4);
        if (levelData.levelItemsArray[4].unlocked == true)
        {
            room10.SetActive(false);
        }
        if (levelData.levelItemsArray[5].unlocked == true)
        {
            room15.SetActive(false);
        }
        if (levelData.levelItemsArray[6].unlocked == true)
        {
            room22.SetActive(false);
        }
        if (levelData.levelItemsArray[7].unlocked == true)
        {
            room432.SetActive(false);
        }
    }
}
