using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    private static HomeManager instance;                             //instance variable
    public static HomeManager Instance { get => instance; }
    bool isOpenEndGame = true;

    [Header("Object Flags")]
    public GameObject flagPolice;
    public GameObject flagDegree1;
    public GameObject flagDegree2;
    public GameObject flagDegree3;
    public GameObject flagDegree4;
    public GameObject policeCharacter;
    public GameObject playerCharacter;
    [Header("Degree ")]
    public GameObject degree1Object;
    public GameObject degree2Object;
    public GameObject degree3Object;
    public GameObject degree4Object;
    [Header("NPC ")]
    public GameObject NPCDegree1Obect;
    public GameObject NPCDegree2Obect;
    public GameObject NPCDegree3Obect;
    public GameObject NPCDegree4Obect;
    [Header("Level up")]
    public GameObject LevelUpObject;
    public GameObject PassedDegree1Panel;
    public GameObject PassedDegree2Panel;
    public GameObject PassedDegree3Panel;
    public GameObject PassedDegree4Panel;
    public GameObject EndGamePanel;
    [Header("Medal")]
    public GameObject bronzeMedal;
    public GameObject silverMedal;
    public GameObject goldMedal;
    [Header("Username text")]

    public TextMeshProUGUI usernameOfCertificate1;
    public TextMeshProUGUI usernameOfCertificate2;
    public TextMeshProUGUI usernameOfCertificate3;
    public TextMeshProUGUI usernameOfCertificate4;
    [Header("Profiles")]
    public GameObject ProfilesObject;
    public GameObject badgeOfDegree1Object;
    public GameObject badgeOfDegree2Object;
    public GameObject badgeOfDegree3Object;
    public GameObject badgeOfDegree4Object;
    public GameObject medalOfProfiles1;
    public GameObject medalOfProfiles2;
    public GameObject medalOfProfiles3;
    public TextMeshProUGUI usernameProfileDegree1;
    public TextMeshProUGUI usernameProfileDegree2;
    public TextMeshProUGUI usernameProfileDegree3;
    public TextMeshProUGUI usernameProfileDegree4;
    public GameObject degree4Room;
    public TMP_Text usernameText;
    public TMP_Text experienceText;
    public TMP_Text levelText;
    public TMP_Text usernameToolbarText;
    public TMP_Text levelToolbarText;
    public TMP_Text experienceToolbarText;


    [Header("Button")]
    public GameObject MorePanel;
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
        badgeOfDegree1Object.SetActive(false);
        badgeOfDegree2Object.SetActive(false);
        badgeOfDegree3Object.SetActive(false);
        badgeOfDegree4Object.SetActive(false);

        bronzeMedal.SetActive(false);
        silverMedal.SetActive(false);
        goldMedal.SetActive(false);
        medalOfProfiles1.SetActive(false);
        medalOfProfiles2.SetActive(false);
        medalOfProfiles3.SetActive(false);

        // btnJoin.SetActive(false);
        // NPC = -1;
        // btnExitGame.SetActive(false);
        UpdateProfile();
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

            Destroy(gameObject);

        }

    }


    // profile object
    public void UpdateProfile()
    {
        usernameText.text = usernameToolbarText.text = APIUser.Instance.GetUser().username;
        levelText.text = levelToolbarText.text = APIUser.Instance.GetUser().id_level.ToString();
        experienceText.text = experienceToolbarText.text = APIUser.Instance.GetUser().experience.ToString();
        Debug.Log("id_level: " + id_level);
        if (id_level == 2)
        {
            Debug.Log("id_level 1: " + id_level);

            badgeOfDegree1Object.SetActive(true);
        }
        if (id_level == 3)
        {
            Debug.Log("id_level 2: " + id_level);

            badgeOfDegree1Object.SetActive(true);
            badgeOfDegree2Object.SetActive(true);
        }
        if (id_level == 4)
        {
            Debug.Log("id_level 3: " + id_level);

            badgeOfDegree1Object.SetActive(true);
            badgeOfDegree2Object.SetActive(true);
            badgeOfDegree3Object.SetActive(true);
        }
        if (id_level == 5)
        {
            Debug.Log("id_level 4: " + id_level);

            badgeOfDegree1Object.SetActive(true);
            badgeOfDegree2Object.SetActive(true);
            badgeOfDegree3Object.SetActive(true);
            badgeOfDegree4Object.SetActive(true);

            if (APIUser.Instance.GetUser().experience >= 9200 && APIUser.Instance.GetUser().experience < 9600)
            {
                OpenBronzeMedal();
            }
            else if (APIUser.Instance.GetUser().experience >= 9600 && APIUser.Instance.GetUser().experience < 9800)
            {
                OpenSilverMedal();
            }
            else if (APIUser.Instance.GetUser().experience >= 9800)
            {
                OpenGoldMedal();
            }
        }

    }

    void OpenBronzeMedal()
    {
        bronzeMedal.SetActive(true);
        silverMedal.SetActive(false);
        goldMedal.SetActive(false);
        medalOfProfiles1.SetActive(true);
        medalOfProfiles2.SetActive(false);
        medalOfProfiles3.SetActive(false);
    }
    void OpenSilverMedal()
    {
        bronzeMedal.SetActive(false);
        silverMedal.SetActive(true);
        goldMedal.SetActive(false);
        medalOfProfiles1.SetActive(false);
        medalOfProfiles2.SetActive(true);
        medalOfProfiles3.SetActive(false);
    }
    void OpenGoldMedal()
    {
        bronzeMedal.SetActive(false);
        silverMedal.SetActive(false);
        goldMedal.SetActive(true);
        medalOfProfiles1.SetActive(false);
        medalOfProfiles2.SetActive(false);
        medalOfProfiles3.SetActive(true);
    }
    public void Btn_MorePanel()
    {
        MorePanel.SetActive(true);
    }
    public void Btn_Exit_MorePanel()
    {
        MorePanel.SetActive(false);
    }
    public void Btn_display_Profile()
    {
        Debug.Log("Btn_display_Profile");
        ProfilesObject.SetActive(true);
    }
    public void Btn_Exit_Profile()
    {
        Debug.Log("Btn_Exit_Profile");
        ProfilesObject.SetActive(false);
    }
    public void Btn_TurnOffSound_Profile()
    {
        ProfilesObject.SetActive(false);
    }
    public void Btn_Share_Profile()
    {
        ProfilesObject.SetActive(false);
    }

    [Obsolete]
    public void Btn_Logout()
    {
        Application.LoadLevel("SignPage");
        // SceneManager.LoadScene("SignPage");
    }
    public void Btn_Join()
    {
        switch (NPC)
        {

            case -1:
                {
                    ActiveHomePage.Instance.isOpenFlagPolice = true;
                    APIUser.Instance.UpdateIdLevel(0);
                    id_level = 0;
                    FindAnyObjectByType<Dialogue>().EndDialogue();

                    break;
                }
            // police 
            case 0:
                {
                    switch (id_level)
                    {
                        case 0:
                            {
                                Debug.Log("Enter beginning game");
                                APIUser.Instance.UpdateIsOpenStartGame(true);
                                APIUser.Instance.UpdateIdLevel(1);
                                id_level = 1;
                                ActiveHomePage.Instance.isOpenFlagDegree1 = true;
                                ActiveHomePage.Instance.isOpenFlagPolice = false;

                                break;
                            }
                        case 1:
                            {
                                // APIUser.Instance.UpdateIsOpenDegree1(true);
                                ActiveHomePage.Instance.isOpenFlagDegree1 = true;
                                break;
                            }
                        case 2:
                            {
                                // APIUser.Instance.UpdateIsOpenDegree2(true);
                                ActiveHomePage.Instance.isOpenFlagDegree2 = true;
                                break;
                            }
                        case 3:
                            {
                                APIUser.Instance.UpdateIsOpenDegree3(true);
                                ActiveHomePage.Instance.isOpenFlagDegree3 = true;
                                break;
                            }
                        case 4:
                            {
                                // APIUser.Instance.UpdateIsOpenDegree4(true);
                                ActiveHomePage.Instance.isOpenFlagDegree4 = true;
                                FindAnyObjectByType<Dialogue>().EndDialogue();


                                break;
                            }
                    }
                    FindAnyObjectByType<Dialogue>().EndDialogue();

                    break;
                }
            case 1:
                {

                    APIUser.Instance.UpdateIsOpenDegree1(true);

                    // scene play game degree1
                    StartCoroutine(SetActiveDialogue("Degree1Game2"));
                    break;
                }
            case 2:
                {

                    APIUser.Instance.UpdateIsOpenDegree2(true);

                    // scene play game degree1
                    StartCoroutine(SetActiveDialogue("TypingHome"));
                    break;
                }
            case 3:
                {

                    APIUser.Instance.UpdateIsOpenDegree3(true);

                    // scene play game degree1
                    StartCoroutine(SetActiveDialogue("Degree3Game1"));
                    // scene play game degree1

                    break;
                }
            case 4:
                {
                    degree4Room.SetActive(true);
                    APIUser.Instance.UpdateIsOpenDegree3(true);
                    break;
                }
        }
    }
    IEnumerator SetActiveDialogue(string nameScene)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nameScene);

    }

    public void ClosePanelPassedDegree()
    {
        PassedDegree1Panel.SetActive(false);
        PassedDegree2Panel.SetActive(false);
        PassedDegree3Panel.SetActive(false);
        PassedDegree4Panel.SetActive(false);
        LevelUpObject.SetActive(false);

    }
    public void Btn_NextLevelUp()
    {
        Debug.Log("Exit level up");
        if (id_level < 5)
        {
            APIUser.Instance.UpdateIdLevel(id_level + 1);
            id_level += 1;

            ActiveHomePage.Instance.isOpenFlagPolice = true;
        }
        PassedDegree1Panel.SetActive(false);
        PassedDegree2Panel.SetActive(false);
        PassedDegree3Panel.SetActive(false);
        PassedDegree4Panel.SetActive(false);
        LevelUpObject.SetActive(false);
    }
    public void Btn_End_Game()
    {
        LevelUpObject.SetActive(false);
    }
    private void UpdateUsernameOfCertificate()
    {
        string username = APIUser.Instance.GetUser().username;
        usernameOfCertificate1.text = username;
        usernameOfCertificate2.text = username;
        usernameOfCertificate3.text = username;
        usernameOfCertificate4.text = username;
        usernameProfileDegree1.text = username;
        usernameProfileDegree2.text = username;
        usernameProfileDegree3.text = username;
        usernameProfileDegree4.text = username;

    }
    // Update is called once per frame
    void Update()
    {
        // Update profile information
        id_level = APIUser.Instance.GetUser().id_level;

        UpdateProfile();
        UpdateUsernameOfCertificate();

        if (id_level == 1)
        {
            degree1Object.SetActive(true);
            degree2Object.SetActive(false);
            degree3Object.SetActive(false);
            degree4Object.SetActive(false);

            NPCDegree1Obect.SetActive(true);
            NPCDegree2Obect.SetActive(false);
            NPCDegree3Obect.SetActive(false);
            NPCDegree4Obect.SetActive(false);
        }
        if (id_level == 2)
        {
            degree1Object.SetActive(true);
            degree2Object.SetActive(true);
            degree3Object.SetActive(false);
            degree4Object.SetActive(false);

            NPCDegree1Obect.SetActive(true);
            NPCDegree2Obect.SetActive(true);
            NPCDegree3Obect.SetActive(false);
            NPCDegree4Obect.SetActive(false);
        }
        if (id_level == 3)
        {
            degree1Object.SetActive(true);
            degree2Object.SetActive(true);
            degree3Object.SetActive(true);
            degree4Object.SetActive(false);

            NPCDegree1Obect.SetActive(true);
            NPCDegree2Obect.SetActive(true);
            NPCDegree3Obect.SetActive(true);
            NPCDegree4Obect.SetActive(false);
        }
        if (id_level > 3)
        {
            degree1Object.SetActive(true);
            degree2Object.SetActive(true);
            degree3Object.SetActive(true);
            degree4Object.SetActive(true);

            NPCDegree1Obect.SetActive(true);
            NPCDegree2Obect.SetActive(true);
            NPCDegree3Obect.SetActive(true);
            NPCDegree4Obect.SetActive(true);

            degree4Room.SetActive(true);
        }
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
        // open dialog level up
        if (APIUser.Instance.GetUser().experience >= 9800 && id_level == 4)
        {
            PassedDegree4Panel.SetActive(true);
        }
        else if (APIUser.Instance.GetUser().experience >= 5600 && id_level == 3)
        {
            PassedDegree3Panel.SetActive(true);
        }
        else if (APIUser.Instance.GetUser().experience >= 3600 && id_level == 2)
        {
            PassedDegree2Panel.SetActive(true);
        }
        else if (APIUser.Instance.GetUser().experience >= 1600 && id_level == 1)
        {
            PassedDegree1Panel.SetActive(true);
        }
        if (id_level == 5 && isOpenEndGame)
        {
            LevelUpObject.SetActive(true);
            isOpenEndGame = false;
        }
    }
}
