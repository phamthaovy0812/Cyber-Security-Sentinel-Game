using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    // [SerializeField] private static MovementController instance;                             //instance variable
    // public static MovementController Instance { get => instance; }          //instance getter

    private Rigidbody2D rb;
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    [Header("Input")]
    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;
    public KeyCode inputSpace = KeyCode.Z;

    [Header("Sprites")]
    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;
    public GameObject gameOver;
    public GameObject itemQuestion;
    private bool checkPassGame = false;

    [Header("Text")]
    public TextMeshProUGUI txtSpeed;
    public int countCorrectAnswer = 0;
    bool isOpenQuestion = false;
    bool isWin = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererDown;
        SetDirection(Vector2.down, spriteRendererDown);
        spriteRendererDeath.enabled = true;
        txtSpeed.text = speed.ToString();
        countCorrectAnswer = 0;
    }
    public void AddSpeed()
    {
        speed++;
        txtSpeed.text = speed.ToString();

    }

    private void Update()
    {
        if (Input.GetKey(inputUp) || Input.GetKey(KeyCode.W))
        {
            SetDirection(Vector2.up, spriteRendererUp);

        }
        else if (Input.GetKey(inputDown) || Input.GetKey(KeyCode.S))
        {
            SetDirection(Vector2.down, spriteRendererDown);
        }
        else if (Input.GetKey(inputLeft) || Input.GetKey(KeyCode.A))
        {
            SetDirection(Vector2.left, spriteRendererLeft);
        }
        else if (Input.GetKey(inputRight) || Input.GetKey(KeyCode.D))
        {
            SetDirection(Vector2.right, spriteRendererRight);
        }
        else
        {
            SetDirection(Vector2.zero, activeSpriteRenderer);
        }
        if (FindAnyObjectByType<Ufo>()._currentHealth <= 0)
        {
            isWin = true;
            DeathSequence(true);

        }

    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;


        Vector2 translation = speed * Time.fixedDeltaTime * direction;

        rb.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        direction = newDirection;

        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp ? true : false;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown ? true : false;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft ? true : false;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight ? true : false;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            DeathSequence(false);
            isWin = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Chest"))
        {
            StopAllCoroutines();
            itemQuestion.SetActive(true);
            FindAnyObjectByType<InsertAnswerDestructibles>().checkAppear = true;
        }
    }

    public void DeathSequence(bool isWin)
    {
        enabled = false;
        GetComponent<BombController>().enabled = false;

        spriteRendererUp.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;
        spriteRendererDeath.enabled = true;

        // Invoke(nameof(OnDeathSequenceEnded), 1.25f);
        StartCoroutine(DelayPlayerDeathCoroutine(isWin));

    }
    IEnumerator DelayPlayerDeathCoroutine(bool isWin)
    {
        yield return new WaitForSeconds(1f);

        Time.timeScale = 0;
        gameOver.SetActive(true);
        if (isWin)
        {
            float currentTime = FindObjectOfType<BBCountDownGamePlay>().GetTime();

            if (currentTime > 119)
                FindAnyObjectByType<GameOver>().gameOver(3);
            else if (currentTime > 59)
            {
                FindAnyObjectByType<GameOver>().gameOver(2);

            }
            else
            {
                FindAnyObjectByType<GameOver>().gameOver(1);

            }

        }
        else
        {
            FindAnyObjectByType<GameOver>().gameOver(0);

        }

    }
    public void Btn_AgainPlay()
    {
        Time.timeScale = 1;
        Debug.Log("BtnAgain");
        // LevelSystemManager.Instance.CurrentLevel = LevelSystemManager.Instance.getCurrentLevel();
        int level = LevelSystemManager.Instance.CurrentLevel + 1;

        //set the CurrentLevel, we subtract 1 as level data array start from 0
        SceneManager.LoadScene("Degree1Game2Level_" + level);
        //load the level
        // Reload the current scene
        // SceneManager.LoadScene("Game1");
    }
    public void Btn_NextLevel()
    {
        Debug.Log("btn next level");
        if (isWin)
        {
            Time.timeScale = 1;
            LevelSystemManager.Instance.CurrentLevel += 1;
            int level = LevelSystemManager.Instance.CurrentLevel + 1;
            //set the CurrentLevel, we subtract 1 as level data array start from 0
            SceneManager.LoadScene("Degree1Game2Level_" + level);
        }

    }
    public void Btn_Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Degree1Game2MenuLevel");
    }

    private void OnDeathSequenceEnded()
    {
        gameObject.SetActive(false);
        GameManager.Instance.CheckWinState();
    }


}
