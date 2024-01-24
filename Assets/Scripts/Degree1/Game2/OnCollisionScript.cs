using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionScript : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(destroyItems());
    }
    public void DestroyItem()
    {
        Destroy(gameObject);
    }
    IEnumerator destroyItems()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);

    }


}
