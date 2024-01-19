using UnityEngine;

public class STEnemyAttack : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {

            FindAnyObjectByType<Ufo>().TakeDamage(10);
        }

    }

}