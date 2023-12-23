using UnityEngine;

public class FBQuestion : MonoBehaviour
{
     public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            FBScore.instance.UpdateScore();
            // Destroy(gameObject);
        }
    }
}