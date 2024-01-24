using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueScript;
    public DialogString dialogString;
    public int indexNPC = 0; // 1: NPC0, 2: NPC1, 3: NPC2, 4: NPC3  
    public bool playerDetected = false;
    private bool isCompletedDialog = false;

    Rigidbody2D _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        dialogueScript.dialogues = new List<List<string>>();

        HomeManager.Instance.NPC = 0;
    }

    //Detect trigger with player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If we triggerd the player enable playerdeteced and show indicator
        if (collision.gameObject.tag == "Player")
        {
            HomeManager.Instance.NPC = 0;

            if (!APIUser.Instance.GetUser().isOpenStartGame)
            {
                Debug.Log("Start game");
                dialogueScript.dialogues = new List<List<string>>();

                dialogueScript.dialogues = dialogString.docBeginStartingSeePolice;
                ActiveHomePage.Instance.isOpenFlagPolice = false;
                playerDetected = true;

            }
            else
            {
                if (HomeManager.Instance.id_level == 1)
                {
                    dialogueScript.dialogues = new List<List<string>>();
                    dialogueScript.dialogues = dialogString.docNoCompleteDegree1;

                }
                if (HomeManager.Instance.id_level == 2)
                {
                    dialogueScript.dialogues = new List<List<string>>();
                    dialogueScript.dialogues = dialogString.docNoCompleteDegree2;

                }
                if (HomeManager.Instance.id_level == 3)
                {
                    dialogueScript.dialogues = new List<List<string>>();
                    dialogueScript.dialogues = dialogString.docNoCompleteDegree3;

                }
                if (HomeManager.Instance.id_level == 4)
                {
                    dialogueScript.dialogues = new List<List<string>>();
                    dialogueScript.dialogues = dialogString.docNoCompleteDegree4;

                }
                playerDetected = true;

            }



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
            ActiveHomePage.Instance.isOpenFlagPolice = false;
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
