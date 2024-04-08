using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class HomePageHandle : MonoBehaviour
{
    public GameObject dialogInfoGame;
    public GameObject scriptInfo1;
    public GameObject scriptInfo2;
    public FirebaseUser user;
    [SerializeField] private static HomePageHandle instance;                             //instance variable
    public static HomePageHandle Instance { get => instance; }

    [SerializeField] TMP_Text username;
    [SerializeField] TMP_Text level;
    [SerializeField] TMP_Text experience;
    private FirebaseAuth auth;
    DatabaseReference databaseReference;

    public void Start()
    {
        LoadUserInfo();
    }
    public void LoadUserInfo()
    {
        User user = APIUser.Instance.GetUser();
        Debug.Log("username:  " + user.username + ", password: " + user.id_level);
        level.text = user.id_level.ToString();
        username.text = user.username;
        experience.text = user.experience.ToString();
    }


    public void openDialogInfoGame()
    {
        scriptInfo1.SetActive(true);
        scriptInfo2.SetActive(false);
        dialogInfoGame.SetActive(true);
    }
    public void closenDialogInfoGame()
    {
        dialogInfoGame.SetActive(false);
    }

    public void nextPageInfo()
    {
        scriptInfo1.SetActive(false);
        scriptInfo2.SetActive(true);
    }
}