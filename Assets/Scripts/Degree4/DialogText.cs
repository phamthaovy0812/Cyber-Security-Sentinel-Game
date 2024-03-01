using System.Collections;
using TMPro;
using UnityEngine;

public class DialogText : MonoBehaviour
{
    // public TMP_Text dialogueText;
    // //content list
    // public string content = "Chao canh sat";
    // //Writing speed
    // public float writingSpeed;
    // //Index on dialogue
    // private int index;
    // int indexDialog = 0;
    // //Character index
    // private int charIndex;
    // //Started boolean
    // private bool started;
    // //Wait for next boolean
    // public bool waitForNext;
    // private bool isNextTalk;
    // public bool isNPCTalk;
    // public void Start()
    // {
    //     isNextTalk = false;
    //     StartDialogue();
    // }

    // //Start Dialogue
    // public void StartDialogue()
    // {
    //     if (started)
    //         return;

    //     //Boolean to indicate that we have started
    //     started = true;
    //     //Show the window
    //     //Start with first dialogue
    //     GetDialogue(0);
    // }

    // private void GetDialogue(int i)
    // {
    //     //start index at zero
    //     index = i;
    //     //Reset the character index
    //     charIndex = 0;
    //     //clear the dialogue component text
    //     dialogueText.text = string.Empty;
    //     //Start writing
    //     StartCoroutine(Writing());
    // }

    // //End Dialogue
    // public void EndDialogue()
    // {
    //     //Stared is disabled
    //     started = false;
    //     //Disable wait for next as well
    //     waitForNext = false;
    //     charIndex = 0;
    //     index = 0;
    //     indexDialog = 0;
    //     dialogueText.text = "";
    //     //Stop all Ienumerators
    //     //Hide the window
    //     // set flag position police 
    //     StopAllCoroutines();

    //     Debug.Log("EndDialogue");


    // }
    // //Writing logic
    // IEnumerator Writing()
    // {
    //     // continueText.text = "Nhấn Space để tiếp tục";
    //     yield return new WaitForSeconds(writingSpeed);

    //     string currentDialogue = content;
    //     //Write the character
    //     dialogueText.text += currentDialogue[charIndex];
    //     //increase the character index 
    //     charIndex++;
    //     //Make sure you have reached the end of the sentence
    //     if (charIndex < currentDialogue.Length)
    //     {
    //         //Wait x seconds 
    //         yield return new WaitForSeconds(writingSpeed);
    //         //Restart the same process
    //         StartCoroutine(Writing());
    //     }
    //     else
    //     {

    //         //End this sentence and wait for the next one
    //         waitForNext = true;

    //     }
    // }

    // private void Update()
    // {
    //     if (!started)
    //         return;
    //     if (waitForNext) //  && Input.GetKeyDown(KeyCode.Space)
    //     {
    //         if (Input.GetKeyDown(KeyCode.Space))
    //         {
    //             waitForNext = false;
    //             if (isNPCTalk)
    //             {
    //                 FindAnyObjectByType<ActiveObject>().NPCActive();
    //             }
    //             else
    //             {
    //                 FindAnyObjectByType<ActiveObject>().PlayerActive();
    //             }
    //             // index++;

    //             // //Check if we are in the scope fo content List
    //             // if (index < content.Length)
    //             // {
    //             //     //If so fetch the next dialogue
    //             //     GetDialogue(index);
    //             // }
    //             // else
    //             // {
    //             //     //If not end the dialogue process

    //             //     //Hide the window
    //             //     // ToggleWindow(false);
    //             //     index = -1;
    //             //     waitForNext = true; indexDialog += 1;
    //             //     EndDialogue();

    //             // }

    //             isNextTalk = true;
    //         }


    //     }
    //     else
    //     {
    //         if (Input.GetKeyDown(KeyCode.Space))
    //         {
    //             StopAllCoroutines();
    //             //Stared is disabled

    //             dialogueText.text = content;
    //             //Stop all Ienumerators
    //             //Hide the window
    //             // set flag position police 
    //             waitForNext = true;

    //         }
    //     }


    // }
    public TMP_Text dialogText;
    public string[] content;
    public float speed;
    private int m_sentenceIndex;
    private Coroutine m_showCo;
    public bool isEndTalk = false;

    private void Start()
    {

        if (!isEndTalk)
        {
            dialogText.text = content[m_sentenceIndex].ToString();

        }
        // m_showCo = StartCoroutine(ShowCo());
    }
    // private IEnumerator ShowCo()
    // {
    //     dialogText.text = "";
    //     foreach (char letter in content[m_sentenceIndex].ToCharArray())
    //     {
    //         dialogText.text += letter;
    //         yield return new WaitForSeconds(speed);
    //     }

    //     isEndTalk = true;
    // }
    // public void NextDialog()
    // {
    //     if (m_sentenceIndex < content.Length - 1)
    //     {

    //         m_sentenceIndex++;
    //         dialogText.text = content[m_sentenceIndex];
    //         if (m_showCo != null)
    //         {
    //             StopCoroutine(m_showCo);
    //         }
    //         m_showCo = StartCoroutine(ShowCo());
    //         isEndTalk = true;
    //     }
    // }

}