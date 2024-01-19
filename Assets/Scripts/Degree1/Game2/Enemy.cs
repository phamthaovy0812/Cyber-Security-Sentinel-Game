using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject gameOver;

    private void Start()
    {
        // seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        // freezeDuration = 0;
        // target = FindObjectOfType<Player>().transform;

        // InvokeRepeating("CalculatePath", 0f, repeatTimeUpdatePath);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("collision");
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }

}
