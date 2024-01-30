using System.Collections;
using TMPro;
using UnityEngine;

public class Room112Q1 : MonoBehaviour
{
   public TMP_InputField q1;
   public GameObject right;
   public GameObject wrong;
   public GameObject ques1;
   public GameObject npc;
   public GameObject npcNext;
   public void goto2 (){
      right.SetActive(false);
      wrong.SetActive(false);
      npcNext.SetActive(true);
   }
   
   public void showQues(){
      npc.SetActive(false);
      ques1.SetActive(true);

   }
   public void CheckQ1()
   {
      if (q1.text == "5")
      {
         ques1.SetActive(false);
         right.SetActive(true);
      }
      else
      {
         wrong.SetActive(true);
      }
   }
   public void NextStep()
   {
      wrong.SetActive(false);
      ques1.SetActive(false);
      right.SetActive(true);
   }

}