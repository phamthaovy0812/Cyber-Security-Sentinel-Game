using System.Collections;
using TMPro;
using UnityEngine;

public class Room456Q1 : MonoBehaviour
{
   public TMP_InputField q1;
   public GameObject right;
   public GameObject wrong;
   public GameObject ques1;
   public void CheckQ1()
   {
      if (q1.text == "B" || q1.text == "b")
      {
         ques1.SetActive(false);
         right.SetActive(true);
         FindAnyObjectByType<EndTalking>().countCorrect++;

      }
      else
      {
         wrong.SetActive(true);
      }
   }

}