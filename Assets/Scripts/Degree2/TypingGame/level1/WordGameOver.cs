using UnityEngine;

public class WordGameOver : MonoBehaviour
{
       public void OnTriggerEnter2D(Collider2D other)
    {
             
        if (other.CompareTag("Obstacle")) {
            Debug.Log("va cham ne");
            FindObjectOfType<WordManager>().GameOver();
        }
    }
}