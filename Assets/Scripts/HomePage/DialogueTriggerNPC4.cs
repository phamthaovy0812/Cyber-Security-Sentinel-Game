using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC4 : MonoBehaviour
{
    public Dialogue dialogueScript;
    public DialogString dialogString;

    public bool playerDetected = false;
    private bool isCompletedDialog = false;

    Rigidbody2D _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();



    }

    //Detect trigger with player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If we triggerd the player enable playerdeteced and show indicator
        if (collision.gameObject.tag == "Player")
        {
            HomeManager.Instance.NPC = 4;
            dialogueScript.dialogues = new List<List<string>>();
            dialogueScript.dialogues = dialogString.docBeginStartingSeeNPCDegree4;
            ActiveHomePage.Instance.isOpenFlagPolice = false;
            // if (HomeManager.Instance.id_level < 4)
            // {
            //     dialogueScript.dialogues = new List<List<string>>();
            //     dialogueScript.dialogues = dialogString.docNoCompleteDegree4;

            // }

            // else if (!APIUser.Instance.GetUser().isOpenDegree4)//&& HomeManager.Instance.id_level == 4
            // {
            //     Debug.Log("4");
            //     dialogueScript.dialogues = new List<List<string>>();
            //     dialogueScript.dialogues = dialogString.docBeginStartingSeeNPCDegree4;
            //     ActiveHomePage.Instance.isOpenFlagPolice = false;


            // }
            // else if (APIUser.Instance.GetUser().isOpenDegree4 && HomeManager.Instance.id_level > 4)
            // {
            //     Debug.Log("2");
            //     dialogueScript.dialogues = new List<List<string>>();
            //     dialogueScript.dialogues = new List<List<string>>();
            //     dialogueScript.dialogues = dialogString.docAfterCompleteDegree4;
            // }
            // else if (APIUser.Instance.GetUser().isOpenDegree4)
            // {
            //     Debug.Log("3");
            //     dialogueScript.dialogues = new List<List<string>>();
            //     dialogueScript.dialogues = new List<List<string>>();
            //     dialogueScript.dialogues = dialogString.docAfterSeeNPCDegree4;
            // }

            playerDetected = true;

            // dialogueScript.dialogues = dialoguesSeePolice;
            // dialogueScript.ToggleIndicator(playerDetected);

            // dialogueScript.dialogues = dialoguesSeePolice;
            // dialogueScript.ToggleIndicator(playerDetected);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //If we lost trigger  with the player disable playerdeteced and hide indicator
        if (collision.gameObject.tag == "Player")
        {

            playerDetected = false;
            // dialogueScript.ToggleIndicator(playerDetected);
            if (dialogueScript != null)
            {
                dialogueScript.EndDialogue();

            }
        }
    }
    //While detected if we interact start the dialogue
    private void Update()
    {
        if (playerDetected) //APIUser.Instance.GetUser().experience == 0 && 
        {
            dialogueScript.StartDialogue();
            HomeManager.Instance.isOpenBtn = false;

            playerDetected = false;

        }
    }
}
