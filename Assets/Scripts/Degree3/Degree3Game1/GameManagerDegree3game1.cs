using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerDegree3game1 : MonoBehaviour
{
    public static GameManagerDegree3game1 Instance { get; private set; }

    [SerializeField] private GhostPacman[] ghosts;
    [SerializeField] private Pacman pacman;
    [SerializeField] private Transform pellets;

    [SerializeField] private GameObject gameOver;

    private int ghostMultiplier = 1;


    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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

    // private void SetLives(int lives)
    // {
    //     this.lives = lives;
    //     livesText.text = "x" + lives.ToString();
    // }

    // private void SetScore(int score)
    // {
    //     this.score = score;
    //     scoreText.text = score.ToString().PadLeft(2, '0');
    // }
    // public void SetStar(int star)
    // {
    //     this.star = star;
    //     txtStar.text = star.ToString();
    // }


    // public void PacmanEaten()
    // {
    //     pacman.DeathSequence();

    //     SetLives(lives - 1);

    //     if (lives > 0)
    //     {
    //         Invoke(nameof(ResetState), 3f);
    //     }
    //     else
    //     {
    //         GameOver();
    //     }
    // }

    // public void GhostEaten(GhostPacman ghost)
    // {
    //     int points = ghost.points * ghostMultiplier;
    //     SetScore(score + points);

    //     ghostMultiplier++;
    // }

    // public void PelletEaten(Pellet pellet)
    // {
    //     pellet.gameObject.SetActive(false);

    //     SetScore(score + pellet.points);

    //     if (!HasRemainingPellets())
    //     {
    //         pacman.gameObject.SetActive(false);
    //         Invoke(nameof(NewRound), 3f);
    //     }
    // }

    // public void PowerPelletEaten(PowerPellet pellet)
    // {
    //     // for (int i = 0; i < ghosts.Length; i++)
    //     // {
    //     //     ghosts[i].frightened.Enable(pellet.duration);
    //     // }
    //     PelletEaten(pellet);

    //     CancelInvoke(nameof(ResetGhostMultiplier));
    //     Invoke(nameof(ResetGhostMultiplier), pellet.duration);
    // }

    // private bool HasRemainingPellets()
    // {
    //     foreach (Transform pellet in pellets)
    //     {
    //         if (pellet.gameObject.activeSelf)
    //         {
    //             return true;
    //         }
    //     }

    //     return false;
    // }

    // private void ResetGhostMultiplier()
    // {
    //     ghostMultiplier = 1;
    // }

}
