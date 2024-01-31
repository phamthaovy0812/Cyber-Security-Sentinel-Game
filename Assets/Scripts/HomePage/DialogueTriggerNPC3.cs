using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTriggerNPC3 : MonoBehaviour
{
    public Dialogue dialogueScript;
    public DialogString dialogString;

    public bool playerDetected = false;
    private bool isCompletedDialog = false;
    int exp = 2000;
    Rigidbody2D _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        dialogueScript.dialogues = new List<List<string>>();


    }

    //Detect trigger with player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If we triggerd the player enable playerdeteced and show indicator
        if (collision.gameObject.tag == "Player")
        {
            HomeManager.Instance.NPC = 3;
            if (!APIUser.Instance.GetUser().isOpenDegree3 && HomeManager.Instance.id_level == 3)
            {

                dialogueScript.dialogues = dialogString.docBeginStartingSeeNPCDegree3;
                ActiveHomePage.Instance.isOpenFlagPolice = false;


            }
            else if (APIUser.Instance.GetUser().isOpenDegree3 && HomeManager.Instance.id_level > 3)
            {
                dialogueScript.dialogues = new List<List<string>>();
                dialogueScript.dialogues = dialogString.docAfterCompleteDegree3;
            }
            else if (APIUser.Instance.GetUser().isOpenDegree3)
            {
                dialogueScript.dialogues = new List<List<string>>();
                dialogueScript.dialogues = dialogString.docAfterSeeNPCDegree3;
            }

            playerDetected = true;

            // dialogueScript.dialogues = dialoguesSeePolice;
            // dialogueScript.ToggleIndicator(playerDetected);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //If we lost trigger  with the player disable playerdeteced and hide indicator
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player disabled");
            playerDetected = false;
            // dialogueScript.ToggleIndicator(playerDetected);
            dialogueScript.EndDialogue();
        }
    }
    //While detected if we interact start the dialogue
    private void Update()
    {
        if (playerDetected) //APIUser.Instance.GetUser().experience == 0 && 
        {
            dialogueScript.StartDialogue();
            HomeManager.Instance.isOpenBtn = false;
            isCompletedDialog = true;
            playerDetected = false;

        }
    }
}
