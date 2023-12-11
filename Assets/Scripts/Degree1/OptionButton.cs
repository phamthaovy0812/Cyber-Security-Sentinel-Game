using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionButton : MonoBehaviour
{
    public GameObject pause;

    public void clickButtonPause()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }
    public void clickButtonPlay()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }
    public void clickButtonBack()
    {
        // load the previous scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Start is called before the first frame update

}
