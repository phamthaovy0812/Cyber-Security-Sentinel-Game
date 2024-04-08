using System.Collections;
using UnityEngine;

public class WelcomePageHandle : MonoBehaviour
{
    public void openLoginPage()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SignPage");

    }
}