using System.Collections;
using UnityEngine;

public class WelcomePageHandle : MonoBehaviour
{
    private void Awake()
    {
    }

    public void openLoginPage()
    {
     UnityEngine.SceneManagement.SceneManager.LoadScene("SignPage");

    }
}