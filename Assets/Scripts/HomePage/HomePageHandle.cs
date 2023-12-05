using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class HomePageHandle : MonoBehaviour
{
    public GameObject dialogInfoGame;
    public GameObject scriptInfo1;
    public GameObject scriptInfo2;
    public FirebaseUser user;

    [SerializeField] TMP_Text username;
    [SerializeField] TMP_Text level;
    [SerializeField] TMP_Text experience;
    private FirebaseAuth auth;
    DatabaseReference databaseReference;

    private void Start()
    {
        FirebaseAuthManager authManager = FindObjectOfType<FirebaseAuthManager>();
        if (authManager != null)
        {
            auth = authManager.auth;
            databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
            LoadUserInfo();
        }
    }

    private void LoadUserInfo()
    {
        if (auth != null && auth.CurrentUser != null)
        {
            FirebaseUser user = auth.CurrentUser;
            databaseReference.Child("Users").Child(user.UserId).GetValueAsync().ContinueWithOnMainThread(task =>
               {
                   if (task.IsCompleted)
                   {
                       DataSnapshot snapshot = task.Result;

                       if (snapshot.Exists)
                       {
                           // Retrieve data from the snapshot
                           experience.text = snapshot.Child("experiences").GetValue(true).ToString();
                           level.text = snapshot.Child("id_degree").GetValue(true).ToString();
                           username.text = snapshot.Child("username").GetValue(true).ToString();

                           // Now you have the user data, you can use it as needed
                           Debug.Log("User: " + username + ", id_degree: " + level.text + ", experiences: " + experience.text);
                       }
                   }
               });
        }
        else
        {
            Debug.LogWarning("User not authenticated or user information is not available.");
        }
    }

    private void Awake()
    {
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