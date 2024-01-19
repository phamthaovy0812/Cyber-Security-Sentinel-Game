using UnityEngine;

public class WordGameOver2 : MonoBehaviour
{
       public void OnTriggerEnter2D(Collider2D other)
    {
              Debug.Log("va cham ne?");
        if (other.CompareTag("Obstacle")) {
            Debug.Log("va cham ne");
            FindObjectOfType<WordManager2>().GameOver();
        }
    }
}