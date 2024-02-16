using System.Collections;
using TMPro;
using UnityEngine;

public class Room412Q3 : MonoBehaviour
{
   public TMP_InputField q3;
   public GameObject right;
   public GameObject wrong;
   public GameObject ques3;
   public GameObject npc1;
   public GameObject npc2;
   public void Repply()
   {
      right.SetActive(false);
      npc2.SetActive(true);
   }

   public void showQues()
   {
      npc1.SetActive(false);

      ques3.SetActive(true);

   }
   public void CheckQ2()
   {
      if (q3.text == "C" || q3.text == "c")
      {
         ques3.SetActive(false);
         right.SetActive(true);
         FindAnyObjectByType<EndTalking>().countCorrect++;

      }
      else
      {
         wrong.SetActive(true);
      }
   }
   public void NextStep()
   {
      wrong.SetActive(false);
      ques3.SetActive(false);
      right.SetActive(true);
   }

}