using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    //Fields
    //Window
    public GameObject window;
    // //Indicator
    // public GameObject indicator;
    //Text component
    public TMP_Text dialogueText;
    public TMP_Text continueText;
    //Dialogues list
    public List<List<string>> dialogues = new List<List<string>>();
    //Writing speed
    public float writingSpeed;
    //Index on dialogue
    private int index;
    int indexDialog = 0;
    //Character index
    private int charIndex;
    //Started boolean
    private bool started;
    //Wait for next boolean
    private bool waitForNext;

    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }
    //Start Dialogue
    public void StartDialogue()
    {
        if (started)
            return;

        //Boolean to indicate that we have started
        started = true;
        //Show the window
        ToggleWindow(true);
        //Start with first dialogue
        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        //start index at zero
        index = i;
        //Reset the character index
        charIndex = 0;
        //clear the dialogue component text
        dialogueText.text = string.Empty;
        //Start writing
        StartCoroutine(Writing());
    }

    //End Dialogue
    public void EndDialogue()
    {
        //Stared is disabled
        started = false;
        //Disable wait for next as well
        waitForNext = false;
        charIndex = 0;
        index = 0;
        indexDialog = 0;
        dialogueText.text = "";
        //Stop all Ienumerators
        //Hide the window
        // set flag position police 
        StopAllCoroutines();
        ToggleWindow(false);

        Debug.Log("EndDialogue");


    }
    //Writing logic
    IEnumerator Writing()
    {
        continueText.text = "Nhấn Space để tiếp tục";
        yield return new WaitForSeconds(writingSpeed);

        string currentDialogue = dialogues[indexDialog][index];
        //Write the character
        dialogueText.text += currentDialogue[charIndex];
        //increase the character index 
        charIndex++;
        //Make sure you have reached the end of the sentence
        if (charIndex < currentDialogue.Length)
        {
            //Wait x seconds 
            yield return new WaitForSeconds(writingSpeed);
            //Restart the same process
            StartCoroutine(Writing());
        }
        else
        {

            //End this sentence and wait for the next one
            waitForNext = true;

        }
    }

    private void Update()
    {
        if (!started)
            return;

        if (indexDialog < dialogues.Count)
        {
            if (indexDialog % 2 == 0)
            {

                FindAnyObjectByType<HomeManager>().isOpenPoliceCharacter = true;

            }
            else
            {
                FindAnyObjectByType<HomeManager>().isOpenPoliceCharacter = false;

            }

            if (waitForNext) //  && Input.GetKeyDown(KeyCode.Space)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    waitForNext = false;

                    index++;

                    //Check if we are in the scope fo dialogues List
                    if (index < dialogues[indexDialog].Count)
                    {
                        //If so fetch the next dialogue
                        GetDialogue(index);
                    }
                    else
                    {
                        //If not end the dialogue process

                        //Hide the window
                        // ToggleWindow(false);
                        index = -1;
                        waitForNext = true; indexDialog += 1;

                    }
                }


            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StopAllCoroutines();
                    //Stared is disabled

                    dialogueText.text = dialogues[indexDialog][index];
                    //Stop all Ienumerators
                    //Hide the window
                    // set flag position police 
                    waitForNext = true;

                }
            }


        }
        else
        {
            continueText.text = "";
            // FindAnyObjectByType<HomeManager>().isOpenBtn = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FindAnyObjectByType<HomeManager>().Btn_Join();
            }

            // EndDialogue();
        }

    }
}
