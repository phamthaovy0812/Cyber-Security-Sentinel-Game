using System.Collections;
using TMPro;
using UnityEngine;

public class Room456Q3 : MonoBehaviour
{
   public TMP_InputField q3;
   public GameObject right;
   public GameObject wrong;
   public GameObject ques3;
   public void CheckQ2()
   {
      if (q3.text == "3" )
      {
         ques3.SetActive(false);
         right.SetActive(true);
      }
      else
      {
         wrong.SetActive(true);
      }
   }

}