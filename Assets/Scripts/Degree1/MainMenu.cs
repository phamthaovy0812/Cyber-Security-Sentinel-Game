using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneBuildIndex;
    public GameObject OptionsMenu;

    public void Start()
    {
        SaveLoadData.Instance.LoadData();
    }
    public void OnClickPlay()
    {
        // SceneManager.LoadScene("MenuLevel"); 
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);

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
