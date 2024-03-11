using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string nameScene;
    public GameObject OptionsMenu;



    public void OnClickPlay()
    {
        // SceneManager.LoadScene("MenuLevel"); 


        SceneManager.LoadScene(nameScene);

    }

    public void OnClickOption()
    {

        OptionsMenu.SetActive(true);

    }
    public void OnClickExit()
    {
        AudioBomberman.instance.DestroySoundGameBomberman();
        SceneManager.LoadScene("HomePage");
    }
    public void OnClickBackOption()
    {
        OptionsMenu.SetActive(false);

    }



}
