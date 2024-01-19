using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Pellet : MonoBehaviour
{
    public int points = 10;

    // protected virtual void Eat()
    // {
    //     GameManagerDegree3game1.Instance.PelletEaten(this);
    // }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
    //     {
    //         Eat();
    //     }
    // }

}
