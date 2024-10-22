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
        FirebaseAuthManager authManager = FindObjectOfType<FirebaseAuthManager>();
        if (authManager != null)
        {
            auth = authManager.auth;
        }
        LoadUserInfo();
        // GetIndexScene.Instance.indexPreviousScene = SceneManager.GetActiveScene().buildIndex;
    }
    // public void Update()
    // {
    //     LoadUserInfo();
    // }
    public void LoadUserInfo()
    {
        User user = APIUser.Instance.GetUser();
        Debug.Log("username:  " + user.username + ", password: " + user.id_level);
        level.text = user.id_level.ToString();
        username.text = user.username;
        experience.text = user.experience.ToString();
        // // Debug.Log("UserInfo loaded: " + APIUser.Instance.GetUser().id_user);
        // databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        // // if (auth != null && auth.CurrentUser != null)
        // // {
        // //    FirebaseUser user = auth.CurrentUser;
        // //    Debug.Log("userId:"+user.UserId);
        // databaseReference.Child("Users").Child("1").GetValueAsync().ContinueWithOnMainThread(task =>
        //    {
        //        if (task.IsFaulted)
        //        {
        //            Debug.Log("fail ne");
        //        }
        //        else if (task.IsCompleted)
        //        {
        //            DataSnapshot snapshot = task.Result;

        //            Debug.Log("success ne");

        //            Debug.Log("co data hong ne");
        //            var check =
        //                   // Retrieve data from the snapshot
        //                   experience.text = snapshot.Child("experience").GetValue(true).ToString();
        //            level.text = snapshot.Child("id_level").GetValue(true).ToString();
        //            username.text = snapshot.Child("username").GetValue(true).ToString();

        //            // Now you have the user data, you can use it as needed
        //            Debug.Log("User: " + username.text + ", id_degree: " + level.text + ", experiences: " + experience.text);
        //        }
        //    });
        // }
        // else
        // {
        //     Debug.LogWarning("User not authenticated or user information is not available.");
        // }
    }

    // private void Awake()
    // {
    //     LoadUserInfo();
    // }

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