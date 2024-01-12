using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour
{
    public string nameScene;

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
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
