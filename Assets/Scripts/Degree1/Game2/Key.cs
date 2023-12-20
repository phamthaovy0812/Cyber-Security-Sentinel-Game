using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{
	[SerializeField] private static Key instance;

	public static Key Instance { get { return instance; } }
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
			Destroy(gameObject, 1f);
			isHaveKey = true;
		}
	}
	private void Awake()
	{
		if (instance == null)                                               //if instance is null
		{
			instance = this;                                                //set this as instance                        //make it DontDestroyOnLoad
		}
		else
		{
			Destroy(gameObject);                                            //else destroy it
		}
	}
}