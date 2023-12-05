using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneBuildIndex;
    public GameObject OptionsMenu;

    public void Level_1(){
        
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
        Application.Quit();
    }
    public void OnClickBackOption()
    {
        OptionsMenu.SetActive(false);

    }
    


}
