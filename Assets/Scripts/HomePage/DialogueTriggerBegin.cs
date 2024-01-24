using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerBegin : MonoBehaviour
{
    public bool playerDetected = true;

    private void Update()
    {

        if (playerDetected && APIUser.Instance.GetUser().id_level == "0") // && 
        {
            FindAnyObjectByType<Dialogue>().dialogues = new List<List<string>>();
            FindAnyObjectByType<HomeManager>().NPC = -1;
            FindAnyObjectByType<Dialogue>().dialogues = FindAnyObjectByType<DialogString>().docBeginStartingGame;
            FindAnyObjectByType<Dialogue>().StartDialogue();
            playerDetected = false;

            ActiveHomePage.Instance.isBeginGame = false;

        }
    }
}
