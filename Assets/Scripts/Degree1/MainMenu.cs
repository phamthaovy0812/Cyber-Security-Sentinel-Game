using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string nameScene;
    public GameObject OptionsMenu;


    public void Start()
    {
        SaveLoadData.Instance.LoadData();
    }
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

        SceneManager.LoadScene(GetIndexScene.Instance.indexPreviousScene, LoadSceneMode.Single);
    }
    public void OnClickBackOption()
    {
        OptionsMenu.SetActive(false);

    }



}
