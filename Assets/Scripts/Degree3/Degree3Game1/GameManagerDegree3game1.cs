using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerDegree3game1 : MonoBehaviour
{
    public static GameManagerDegree3game1 Instance { get; private set; }

    [SerializeField] private GhostPacman[] ghosts;
    [SerializeField] private Pacman pacman;
    [SerializeField] private Transform pellets;

    [SerializeField] private GameObject gameOver;
    public GameObject pausePanel;
    public GameObject playPanel;


    private int ghostMultiplier = 1;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
    }



    private void ResetState()
    {

        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].ResetState();
        }

        pacman.ResetState();
    }

    private void GameOver()
    {
        gameOver.SetActive(true);
        // gameOverText.enabled = true;

        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].gameObject.SetActive(false);
        }

        pacman.gameObject.SetActive(false);
    }
    public void Btn_AgainPlay()
    {
        gameOver.SetActive(false);

    }
    public void Btn_Home()
    {
        Debug.Log("Home btn");
    }

    public void Btn_Pause()
    {
        pausePanel.SetActive(false);
        playPanel.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Pause btn");

    }
    public void Btn_Play()
    {
        pausePanel.SetActive(true);
        playPanel.SetActive(false);
        Time.timeScale = 1;

    }
    public void Btn_Exit()
    {
        SceneManager.LoadScene("Degree3Game1MenuLevel");
    }

}
