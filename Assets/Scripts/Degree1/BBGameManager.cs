using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BBGameManager : MonoBehaviour
{
    public GameObject pause;
    public GameObject play;
    public GameObject panel;
    public void Btn_Pause()
    {
        Time.timeScale = 0;
        play.SetActive(true);
        panel.SetActive(true);
        pause.SetActive(false);
    }
    public void Btn_Play()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
        play.SetActive(false);
        pause.SetActive(true);

    }
    public void Btn_Exit()
    {
        SceneManager.LoadScene("Degree1Game2MenuLevel");
    }
}
