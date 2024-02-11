using UnityEngine;

public class WordGameOver : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == LayerMask.GetMask("Obstacle"))
        {
            Debug.Log("va cham ne");
            FindObjectOfType<WordManager>().GameOver(false);
        }
    }
}