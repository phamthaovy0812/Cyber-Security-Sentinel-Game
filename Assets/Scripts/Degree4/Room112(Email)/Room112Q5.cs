using System.Collections;
using TMPro;
using UnityEngine;

public class Room112Q5 : MonoBehaviour
{
   public TMP_InputField q4;
   public GameObject right;
   public GameObject wrong;
   public GameObject ques4;
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

      ques4.SetActive(true);

   }
   public void CheckQ2()
   {
      if (q4.text == "c" || q4.text == "C")
      {
         ques4.SetActive(false);
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
      ques4.SetActive(false);
      right.SetActive(true);
   }

}