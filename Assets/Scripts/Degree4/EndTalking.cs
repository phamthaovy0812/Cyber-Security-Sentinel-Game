using TMPro;
using UnityEngine;

public class EndTalking : MonoBehaviour
{
    public GameObject npc1;
    public GameObject npc2;
    public GameObject npc;
    public GameObject player1;

    public void Repply1(){
        npc1.SetActive(true);
        npc.SetActive(false);
    }
    public void Repply2(){
        npc1.SetActive(false);
        player1.SetActive(true);
    }
    public void Repply3(){
        player1.SetActive(false);
        npc2.SetActive(true);
    }
    public void gotoHome(){
        npc2.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomeText");
    }


}