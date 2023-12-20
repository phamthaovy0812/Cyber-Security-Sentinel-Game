using Unity.VisualScripting;
using UnityEngine;

public class PassedGame : MonoBehaviour
{

	private Rigidbody2D rb;
	public bool isHaveKey = false;

	public void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			if (Key.Instance.isHaveKey)
			{
				Debug.Log("Complete Game Object");

			}

		}
	}

}