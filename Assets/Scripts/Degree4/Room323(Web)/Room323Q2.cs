using System.Collections;
using TMPro;
using UnityEngine;

public class Room323Q2 : MonoBehaviour
{
   public TMP_InputField q2;
   public GameObject right;
   public GameObject wrong;
   public GameObject ques2;


   public void CheckQ2()
   {
      if (q2.text == "3")
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


}