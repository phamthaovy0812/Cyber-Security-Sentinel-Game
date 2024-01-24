using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    private static HomeManager instance;                             //instance variable
    public static HomeManager Instance { get => instance; }

    [Header("Object Flags")]
    public GameObject flagPolice;
    public GameObject flagDegree1;
    public GameObject flagDegree2;
    public GameObject flagDegree3;
    public GameObject flagDegree4;
    public GameObject policeCharacter;
    public GameObject playerCharacter;
    [Header("Button")]
    public GameObject btnJoin;
    // public GameObject btnExitGame;
    public bool isOpenBtn = false;
    // public GameObject flagDegree3;
    // public GameObject flagDegree4;

    public bool isOpenPoliceCharacter = true;
    public int NPC = -1;

    public int id_level;

    // Start is called before the first frame update
    void Start()
    {
        // flagPolice.SetActive(false);
        // flagDegree1.SetActive(false);
        // flagDegree2.SetActive(false);
        // flagDegree3.SetActive(false);
        // flagDegree4.SetActive(false);
        // btnJoin.SetActive(false);
        // NPC = -1;
        // btnExitGame.SetActive(false);
        id_level = Int32.Parse(APIUser.Instance.GetUser().id_level);
    }
    private void Awake()
    {
        if (instance == null)                                               //if instance is null
        {
            instance = this;                                                //set this as instance
                                                                            // DontDestroyOnLoad(gameObject);                                  //make it DontDestroyOnLoad
        }
        else
        {
            Destroy(gameObject);                                            //else destroy it
        }
    }
    public void Btn_Join()
    {
        Debug.Log("indexNPC: " + NPC);
        FindAnyObjectByType<Dialogue>().EndDialogue();

        switch (NPC)
        {

            case -1:
                {
                    ActiveHomePage.Instance.isOpenFlagPolice = true;
                    ActiveHomePage.Instance.isBeginGame = false;

                    break;
                }
            // police 
            case 0:
                {
                    if (id_level == 0)
                    {
                        Debug.Log("Enter beginning game");
                        APIUser.Instance.UpdateIsOpenStartGame(true);
                        APIUser.Instance.UpdateIdLevel(1);

                    }

                    if (id_level == 1)
                    {

                        APIUser.Instance.UpdateIsOpenDegree1(true);
                    }
                    if (id_level == 2)
                    {

                        APIUser.Instance.UpdateIsOpenDegree2(true);

                    }
                    if (id_level == 3)
                    {

                        APIUser.Instance.UpdateIsOpenDegree3(true);

                    }
                    if (id_level == 4)
                    {

                        APIUser.Instance.UpdateIsOpenDegree4(true);

                    }
                    if (id_level == 0)
                    {
                        ActiveHomePage.Instance.isOpenFlagPolice = true;
                    }
                    break;
                }
            case 1:
                {

                    APIUser.Instance.UpdateIsOpenDegree1(true);

                    // scene play game degree1
                    Debug.Log("Load Scene play game degree1");
                    SceneManager.LoadScene("Degree1Game2");
                    break;
                }
            case 3:
                {

                    if (id_level >= 3)
                    {

                        APIUser.Instance.UpdateIsOpenDegree3(true);
                        // SceneManager.LoadScene("Degree1Game2");
                    }

                    // scene play game degree1

                    break;
                }
        }
    }
    IEnumerator SetActiveDialogue()
    {
        yield return new WaitForSeconds(2);

    }


    // Update is called once per frame
    void Update()
    {
        if (ActiveHomePage.Instance.isOpenFlagPolice)
        {
            flagPolice.SetActive(true);

        }
        else
        {
            flagPolice.SetActive(false);
        }
        if (ActiveHomePage.Instance.isOpenFlagDegree1)
        {
            flagDegree1.SetActive(true);

        }
        else
        {
            flagDegree1.SetActive(false);
        }
        if (ActiveHomePage.Instance.isOpenFlagDegree2)
        {
            flagDegree2.SetActive(true);

        }
        else
        {
            flagDegree2.SetActive(false);
        }
        if (ActiveHomePage.Instance.isOpenFlagDegree3)
        {
            flagDegree3.SetActive(true);

        }
        else
        {
            flagDegree3.SetActive(false);
        }
        if (ActiveHomePage.Instance.isOpenFlagDegree4)
        {
            flagDegree4.SetActive(true);

        }
        else
        {
            flagDegree4.SetActive(false);
        }

        if (isOpenPoliceCharacter)
        {
            policeCharacter.SetActive(true);
            playerCharacter.SetActive(false);
        }
        else
        {
            policeCharacter.SetActive(false);
            playerCharacter.SetActive(true);
        }
        if (isOpenBtn)
        {
            btnJoin.SetActive(true);
            // btnExitGame.SetActive(true);
        }
        else
        {
            btnJoin.SetActive(false);
            // btnExitGame.SetActive(false);
        }
    }
}
