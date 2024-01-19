using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FBGameManager : MonoBehaviour
{
   public static FBGameManager instance;
   [SerializeField] private GameObject _gameOver;
   
   private void Awake()
   {
    if( instance == null){
        instance=this;
        Time.timeScale= 1f;
    }
   }
   public void GameOver(){
    _gameOver.SetActive(true);
    Time.timeScale = 0f;
   }
   public void RestartGame(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

}
