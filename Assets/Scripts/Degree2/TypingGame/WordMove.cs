using UnityEngine;

public class WordMove : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private void Update()
    {
        transform.position+= Vector3.left * _speed *Time.deltaTime;
    }
}