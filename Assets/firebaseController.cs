using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net.Mail;
using Firebase;
using Firebase.Auth;
using System;
using System.Threading.Tasks;
using Firebase.Extensions;
using UnityEngine.Tilemaps;
using Firebase.Database;
using System.Text.RegularExpressions;
using System.Web;

public class firebaseController : MonoBehaviour
{


    // public GameObject signin, register, login, notificationPanel, forgetPasswordPanel;

    // public TMP_InputField forgotPasswordEmail;

    // public Text notif_Title_Text, notif_Message_Text;
    [Header("Login")]
    public GameObject loginPanel;
    public TMP_InputField loginEmail, loginPassword;
    [Header("Signup")]
    public GameObject signupPanel;
    public GameObject signupSuccess;
    public TMP_InputField signupEmail, signupPassword, signupCPassword, signupUserName;
    [Header("Forgot Password")]
    public GameObject forgetPasswordPanel;
    public TMP_InputField forgotPasswordEmail;
    [Header("Notifications errors")]
    public GameObject notificationPanel;
    public TMP_Text notif_Title_Text, notif_Message_Text;
    public TMP_Text htmlText;
    public bool isExitUser;


    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;

    bool isSignIn = false;


    public static string StripHTML(bool decode = true)
    {
        string HTMLText = "The <i>quick brown fox</i> jumps over the <b>lazy dog</b>.";
        Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
        var stripped = reg.Replace(HTMLText, "");
        return decode ? HttpUtility.HtmlDecode(stripped) : stripped;
    }
    void Start()
    {
        Logout();
        // htmlText.text = StripHTML();
        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
        notificationPanel.SetActive(false);
        forgetPasswordPanel.SetActive(false);
        signupSuccess.SetActive(false);
        isExitUser = false;
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                InitializeFirebase();

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    public void Logout()
    {
        if (auth != null && user != null)
        {
            auth.SignOut();
        }
    }
    public void OpenLoginPanel()
    {
        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
        notificationPanel.SetActive(false);
        forgetPasswordPanel.SetActive(false);
    }

    public void OpenSignupPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(true);
        // login.SetActive(false);
        forgetPasswordPanel.SetActive(false);
        notificationPanel.SetActive(false);

    }

    // public void OpenLoginPanel()
    // {
    //     signin.SetActive(false);
    //     register.SetActive(false);
    //     login.SetActive(true);
    //     forgetPasswordPanel.SetActive(false);
    // }

    public void Openforgetpass()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        forgetPasswordPanel.SetActive(true);
        notificationPanel.SetActive(false);

    }



    public void LoginUser()
    {
        if (string.IsNullOrEmpty(loginEmail.text) && string.IsNullOrEmpty(loginPassword.text))
        {
            showNotificationMessage("Lỗi", "Ô nhập bị trống! Làm ơn hãy nhập vào ô trống");
            return;
        }

        // Do Login
        SignInUser(loginEmail.text, loginPassword.text);

    }

    public void SignUpUser()
    {
        if (string.IsNullOrEmpty(signupEmail.text) && string.IsNullOrEmpty(signupPassword.text) && string.IsNullOrEmpty(signupCPassword.text) && string.IsNullOrEmpty(signupUserName.text)) // && string.IsNullOrEmpty(signupFirstName.text) && string.IsNullOrEmpty(signupLastName.text)
        {
            // showNotificationMessage("Error", "Field Empty! Please Input Details In All Fields");
            showNotificationMessage("Lỗi", "Ô nhập bị trống! Làm ơn hãy nhập vào ô trống");
            return;
        }
        if (signupCPassword.text != signupCPassword.text)
        {
            showNotificationMessage("Lỗi", "Mật khẩu không khớp");
            return;
        }
        // Do SignUp

        CreteUser(signupEmail.text, signupPassword.text, signupUserName.text);
    }


    public void forgetPass()
    {
        if (string.IsNullOrEmpty(forgotPasswordEmail.text))
        {
            showNotificationMessage("Lỗi", "Ô nhập bị trống! Làm ơn hãy nhập vào ô trống");

            return;

        }

        forgetPasswordSubmition(forgotPasswordEmail.text);

    }

    private void showNotificationMessage(string title, string message)
    {
        notif_Title_Text.text = "" + title;
        notif_Message_Text.text = "" + message;

        notificationPanel.SetActive(true);
    }


    public void CloseNotif_Panel()
    {
        notif_Title_Text.text = "";
        notif_Message_Text.text = "";
        notificationPanel.SetActive(false);
    }







    void CreteUser(string email, string password, string Username)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {


                foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
                {
                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null)
                    {
                        var errorCode = (AuthError)firebaseEx.ErrorCode;
                        showNotificationMessage("Error", GetErrorMessage(errorCode));
                    }
                }


                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result.User;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            CreateNewUser(username: Username, password: password, email: email);


        });
    }

    public async void CreateNewUser(string username, string password, string email)
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        string userId;
        userId = System.Guid.NewGuid().ToString(); ;
        User user = new User(userId, email, username, password, -1, 0);
        await reference.Child("Users")
            .Child(userId)
            .Child("id_user")
            .SetValueAsync(user.id_user);
        await reference.Child("Users")
            .Child(userId)
            .Child("username")
            .SetValueAsync(user.username);
        await reference.Child("Users")
            .Child(userId)
            .Child("password")
            .SetValueAsync(user.password);
        await reference.Child("Users")
            .Child(userId)
            .Child("email")
            .SetValueAsync(user.email);
        await reference.Child("Users")
            .Child(userId)
            .Child("id_level")
            .SetValueAsync(user.id_level);
        await reference.Child("Users")
            .Child(userId)
            .Child("experience")
            .SetValueAsync(user.experience);
        await reference.Child("Users")
        .Child(userId)
        .Child("isOpenDegree1")
        .SetValueAsync(user.isOpenDegree1);
        await reference.Child("Users")
            .Child(userId)
            .Child("isOpenDegree2")
            .SetValueAsync(user.isOpenDegree2);
        await reference.Child("Users")
            .Child(userId)
            .Child("isOpenDegree3")
            .SetValueAsync(user.isOpenDegree3);
        await reference.Child("Users")
            .Child(userId)
            .Child("isOpenDegree4")
            .SetValueAsync(user.isOpenDegree4);
        await reference.Child("Users")
            .Child(userId)
            .Child("isOpenStartGame")
            .SetValueAsync(user.isOpenStartGame);



        LevelItem[] levelItems = {
            new LevelItem(unlock: true, star: 0),
            new LevelItem(unlock: false, star: 0),
            new LevelItem(unlock: false, star: 0),
            new LevelItem(unlock: false, star: 0),
            new LevelItem(unlock: false, star: 0),
            new LevelItem(unlock: false, star: 0),
        };

        LevelData levelData = new LevelData();
        levelData.lastUnlockedLevel = 0;
        levelData.levelItemsArray = levelItems;
        string levelDataString = JsonUtility.ToJson(levelData);
        await reference.Child("ScoreDegree").Child(userId).Child("1").SetRawJsonValueAsync(levelDataString);

        LevelItem[] levelItems3 = {
            new LevelItem(unlock: true, star: 0),
            new LevelItem(unlock: false, star: 0),
            new LevelItem(unlock: false, star: 0),
            new LevelItem(unlock: false, star: 0),
        };

        LevelData levelData3 = new LevelData();
        levelData3.lastUnlockedLevel = 0;
        levelData3.levelItemsArray = levelItems3;
        string levelDataString3 = JsonUtility.ToJson(levelData3);
        await reference.Child("ScoreDegree").Child(userId).Child("2").SetRawJsonValueAsync(levelDataString3);
        await reference.Child("ScoreDegree").Child(userId).Child("3").SetRawJsonValueAsync(levelDataString3);
        // degree 4
        LevelItem[] levelItems4 = {
            new LevelItem(unlock: true, star: 0),
            new LevelItem(unlock: true, star: 0),
            new LevelItem(unlock: true, star: 0),
            new LevelItem(unlock: true, star: 0),
            new LevelItem(unlock: false, star: 0),
            new LevelItem(unlock: false, star: 0),
            new LevelItem(unlock: false, star: 0),
            new LevelItem(unlock: false, star: 0),
        };

        LevelData levelData4 = new LevelData();
        levelData4.lastUnlockedLevel = 0;
        levelData4.levelItemsArray = levelItems4;
        string levelDataString4 = JsonUtility.ToJson(levelData4);
        await reference.Child("ScoreDegree").Child(userId).Child("4").SetRawJsonValueAsync(levelDataString4);
        Debug.Log("New User Created");
        StartCoroutine(SignUpSuccess());
    }
    IEnumerator SignUpSuccess()
    {
        signupSuccess.SetActive(true);
        yield return new WaitForSeconds(1);
        signupSuccess.SetActive(false);
        yield return new WaitForSeconds(1);

        OpenLoginPanel();

    }






    private void SignInUser(string email, string password)
    {

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
       {
           if (task.IsCanceled)
           {
               //    Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
               return;
           }
           if (task.IsFaulted)
           {
               //    Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);

               foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
               {
                   Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                   if (firebaseEx != null)
                   {
                       var errorCode = (AuthError)firebaseEx.ErrorCode;
                       showNotificationMessage("Error", GetErrorMessage(errorCode));
                   }
               }


               return;
           }

           Firebase.Auth.FirebaseUser newUser = task.Result.User;

           StartCoroutine(StartHomePage(email, password));
           // Open mainscean
       });

    }
    IEnumerator StartHomePage(string email, string password)
    {
        APIUser.Instance.getConnectedUserByUId(email, password);
        // Debug.Log("email: " + email + " password: " + password);
        yield return new WaitForSeconds(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomePage");

    }

    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
                isSignIn = true;
            }
        }
    }


    void OnDestroy()
    {
        auth.StateChanged -= AuthStateChanged;
        auth = null;
    }


    private void UpdateUserProfile(string UserName)
    {
        Firebase.Auth.FirebaseUser user = auth.CurrentUser;
        if (user != null)
        {
            Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile
            {
                DisplayName = "UserName",
                PhotoUrl = new System.Uri("https://via.placeholder.com/150C/O%20https://placeholding.com/"),
            };
            user.UpdateUserProfileAsync(profile).ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("UpdateUserProfileAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
                    return;
                }

                Debug.Log("User profile updated successfully.");

                showNotificationMessage("Alert", "Account Successfully Created");
            });
        }
    }


    bool isSigned = false;

    private static string GetErrorMessage(AuthError errorCode)
    {
        var message = "";
        switch (errorCode)
        {
            case AuthError.AccountExistsWithDifferentCredentials:
                message = "Tài khoản không tồn tại";//"Account Not Exist";
                break;
            case AuthError.MissingPassword:
                message = "Mật khẩu chưa nhập"; //"Missing Password";
                break;
            case AuthError.WeakPassword:
                message = "Mật khẩu quá yếu"; //"Password So Weak";
                break;
            case AuthError.WrongPassword:
                message = "Sai mật khẩu";//"Wrong Password";
                break;
            case AuthError.EmailAlreadyInUse:
                message = "Email đã được sử dụng";// "Your Email Already in Use";
                break;
            case AuthError.InvalidEmail:
                message = "Email không hợp lệ";//"Your Email Already In Use";
                break;
            case AuthError.MissingEmail:
                message = "Email đang trống"; //"Your Email Missing";
                break;
            default:
                message = "Lỗi không hợp lệ"; //"Invalid Error";
                break;
        }
        return message;
    }

    void forgetPasswordSubmition(string forgetPasswordEmail)
    {
        auth.SendPasswordResetEmailAsync(forgetPasswordEmail).ContinueWithOnMainThread(task =>
        {

            if (task.IsCanceled)
            {
                Debug.LogError("SendPasswordResetEmailAsync was cancled");
            }

            if (task.IsFaulted)
            {
                foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
                {
                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null)
                    {
                        var errorCode = (AuthError)firebaseEx.ErrorCode;
                        showNotificationMessage("Error", GetErrorMessage(errorCode));
                    }
                }
            }



            showNotificationMessage("Alert", "Sucessfully Send Email For Reset Password");
        }


        );
    }


    void updated()
    {
        if (isSignIn)
        {
            if (!isSigned)
            {
                isSigned = true;
                Debug.Log("Success");
            }
        }
    }



}
