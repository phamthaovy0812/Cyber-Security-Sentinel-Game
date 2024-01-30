using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerBegin : MonoBehaviour
{
    private void Update()
    {

        if (APIUser.Instance.GetUser().experience == 0 && APIUser.Instance.GetUser().id_level == -1) // && 
        {
            FindAnyObjectByType<Dialogue>().dialogues = new List<List<string>>();
            FindAnyObjectByType<HomeManager>().NPC = -1;
            FindAnyObjectByType<Dialogue>().dialogues = FindAnyObjectByType<DialogString>().docBeginStartingGame;
            FindAnyObjectByType<Dialogue>().StartDialogue();

        }
    }
}
