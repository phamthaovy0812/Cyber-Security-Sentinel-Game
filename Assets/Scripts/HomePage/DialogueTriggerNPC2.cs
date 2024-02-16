using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC2 : MonoBehaviour
{
    public Dialogue dialogueScript;
    public DialogString dialogString;

    public bool playerDetected = false;
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
            HomeManager.Instance.NPC = 2;
            if (!APIUser.Instance.GetUser().isOpenDegree2)//&& HomeManager.Instance.id_level == 1
            {
                dialogueScript.dialogues = new List<List<string>>();
                dialogueScript.dialogues = dialogString.docBeginStartingSeeNPCDegree2;
                ActiveHomePage.Instance.isOpenFlagPolice = false;
            }
            else if (APIUser.Instance.GetUser().isOpenDegree2 && HomeManager.Instance.id_level > 2)
            {
                Debug.Log("2");
                dialogueScript.dialogues = new List<List<string>>();
                dialogueScript.dialogues = new List<List<string>>();
                dialogueScript.dialogues = dialogString.docAfterCompleteDegree2;
            }
            else if (APIUser.Instance.GetUser().isOpenDegree2)
            {
                Debug.Log("3");
                dialogueScript.dialogues = new List<List<string>>();
                dialogueScript.dialogues = new List<List<string>>();
                dialogueScript.dialogues = dialogString.docAfterSeeNPCDegree2;
            }

            playerDetected = true;
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
