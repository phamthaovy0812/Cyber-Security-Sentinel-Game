using UnityEngine;

[RequireComponent(typeof(MovementPacman))]
public class Pacman : MonoBehaviour
{
    [SerializeField]
    private AnimatedSprite deathSequence;
    private SpriteRenderer spriteRenderer;
    private MovementPacman movement;
    private new Collider2D collider;
    public GameObject gameOver;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponent<MovementPacman>();
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        // Set the new direction based on the current input
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            movement.SetDirection(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            movement.SetDirection(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movement.SetDirection(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            movement.SetDirection(Vector2.right);
        }

        // Rotate pacman to face the movement direction
        float angle = Mathf.Atan2(movement.direction.y, movement.direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void ResetState()
    {
        enabled = true;
        spriteRenderer.enabled = true;
        collider.enabled = true;
        deathSequence.enabled = false;
        movement.ResetState();
        gameObject.SetActive(true);
    }

    public void DeathSequence()
    {
        enabled = false;
        spriteRenderer.enabled = false;
        collider.enabled = false;
        movement.enabled = false;
        deathSequence.enabled = true;
        deathSequence.Restart();
    }
    public void GameOVer(bool isWin)
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
        float currentTime = FindAnyObjectByType<PMCountdownPlayGame>().currentTime;
        if (isWin)
        {
            AudioBomberman.instance.PlaySFX(AudioBomberman.instance.winAudio);
        }
        else
        {
            AudioBomberman.instance.PlaySFX(AudioBomberman.instance.failAudio);

        }
        int star = 0;
        if (isWin)
        {
            if (currentTime > 120)
            {
                star = 3;
            }
            else if (currentTime > 60)
            {
                star = 2;
            }
            else
            {
                star = 1;
            }

        }
        FindAnyObjectByType<GameOver>().gameOver(star);


    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Debug.Log("Game over");
            GameOVer(true);
        }
    }

}
