using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string nameScene;
    public GameObject OptionsMenu;



    public void OnClickPlay()
    {
        // SceneManager.LoadScene("MenuLevel"); 
        SaveLoadData.Instance.LoadData();

        SceneManager.LoadScene(nameScene);

    }

    public void OnClickOption()
    {

        OptionsMenu.SetActive(true);

    }
    public void OnClickExit()
    {

        SceneManager.LoadScene("HomeText");
    }
    public void OnClickBackOption()
    {
        OptionsMenu.SetActive(false);

    }



}
