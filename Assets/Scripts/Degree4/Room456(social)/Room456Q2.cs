using System.Collections;
using TMPro;
using UnityEngine;

public class Room456Q2 : MonoBehaviour
{
   public TMP_InputField q2;
   public GameObject right;
   public GameObject wrong;
   public GameObject ques2;

   public void CheckQ2()
   {
      if (q2.text == "C" || q2.text == "c")
      {
         ques2.SetActive(false);
         right.SetActive(true);
      }
      else
      {
         wrong.SetActive(true);
      }
   }

}