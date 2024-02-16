using System.Collections;
using TMPro;
using UnityEngine;

public class Room412Q2 : MonoBehaviour
{
   public TMP_InputField q2;
   public GameObject right;
   public GameObject wrong;
   public GameObject ques2;
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

      ques2.SetActive(true);

   }
   public void CheckQ2()
   {
      if (q2.text == "0")
      {
         ques2.SetActive(false);
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
      ques2.SetActive(false);
      right.SetActive(true);
   }

}