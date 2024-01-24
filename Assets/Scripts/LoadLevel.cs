using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour
{
    public string nameScene;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            print("Trigger Enetered");
            // collision.gameObject.SetActive(false);

            SceneManager.LoadScene(nameScene);
        }

    }
    // public void ModeSelect()
    // {
    //     StartCoroutine(LoadAfterDelay());
    // }
    // IEnumerable LoadAfterDelay()
    // {
    //     yield return new WaitForSeconds(delaySecond);

    // }
}
