using UnityEngine;

public class Collider2DStar : MonoBehaviour
{
	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Player"))
		{
			Debug.Log("Player is already");
			// HaveStar.Instance.CallQuestion();
			Destroy(gameObject);
		}
	}
}