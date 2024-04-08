using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTriggerNPC1 : MonoBehaviour
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
            HomeManager.Instance.NPC = 1;
            if (HomeManager.Instance.id_level < 1)
            {
                dialogueScript.dialogues = new List<List<string>>();
                dialogueScript.dialogues = dialogString.docNoCompleteDegree1;

            }

            else if (!APIUser.Instance.GetUser().isOpenDegree1)//&& HomeManager.Instance.id_level == 1
            {
                Debug.Log("1");
                dialogueScript.dialogues = new List<List<string>>();
                dialogueScript.dialogues = dialogString.docBeginStartingSeeNPCDegree1;
                ActiveHomePage.Instance.isOpenFlagPolice = false;


            }
            else if (APIUser.Instance.GetUser().isOpenDegree1 && HomeManager.Instance.id_level > 1)
            {
                Debug.Log("2");
                dialogueScript.dialogues = new List<List<string>>();
                dialogueScript.dialogues = new List<List<string>>();
                dialogueScript.dialogues = dialogString.docAfterCompleteDegree1;
            }
            else if (APIUser.Instance.GetUser().isOpenDegree1)
            {
                Debug.Log("3");
                dialogueScript.dialogues = new List<List<string>>();
                dialogueScript.dialogues = new List<List<string>>();
                dialogueScript.dialogues = dialogString.docAfterSeeNPCDegree1;
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
