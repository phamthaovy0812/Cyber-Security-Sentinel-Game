using UnityEngine;

public class WordNextLevel : MonoBehaviour
{
  public void GoToMenuLevel()
  {
    Time.timeScale = 1;
    UnityEngine.SceneManagement.SceneManager.LoadScene(WordConstants.DATA.TYPING_MENU);
  }
  public void GoToLevel1()
  {
    Time.timeScale = 1;
    UnityEngine.SceneManagement.SceneManager.LoadScene(WordConstants.DATA.LEVEL_1);
  }
  public void GoToLevel2()
  {
    Time.timeScale = 1;
    UnityEngine.SceneManagement.SceneManager.LoadScene(WordConstants.DATA.LEVEL_2);
  }
  public void GoToLevel3()
  {
    Time.timeScale = 1;
    UnityEngine.SceneManagement.SceneManager.LoadScene(WordConstants.DATA.LEVEL_3);
  }
  public void GoToLevel4()
  {
    Time.timeScale = 1;
    UnityEngine.SceneManagement.SceneManager.LoadScene(WordConstants.DATA.LEVEL_4);
  }
  public void GoToTypingGame()
  {
    Time.timeScale = 1;
    UnityEngine.SceneManagement.SceneManager.LoadScene(WordConstants.DATA.HOME_TYPING);
  }
  public void GoToHome()
  {
    Time.timeScale = 1;
    UnityEngine.SceneManagement.SceneManager.LoadScene(WordConstants.DATA.HOME);

  }
}