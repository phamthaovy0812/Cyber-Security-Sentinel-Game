using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneBuildIndex;
    public GameObject OptionsMenu;
    public GameObject PlayMenu;

    public void Level_1(){
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
    public void OnClickPlay()
    {
        PlayMenu.SetActive(true);
        
    }
    public void OnClickBackPlay()
    {
        PlayMenu.SetActive(false);

    }
    public void OnClickOption()
    {
        
        OptionsMenu.SetActive(true);

    }
    public void OnClickExit()
    {
        Application.Quit();
    }
    public void OnClickBackOption()
    {
        OptionsMenu.SetActive(false);

    }
    


}
