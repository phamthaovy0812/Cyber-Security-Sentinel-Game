using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAddScoreEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyObject());
    }

    IEnumerator destroyObject()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
