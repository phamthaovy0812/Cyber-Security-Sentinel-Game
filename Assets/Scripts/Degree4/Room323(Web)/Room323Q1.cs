using System.Collections;
using TMPro;
using UnityEngine;

public class Room323Q1 : MonoBehaviour
{
   public TMP_InputField q1;
   public GameObject right;
   public GameObject wrong;
   public GameObject ques1;


   public void CheckQ1()
   {
      if (q1.text == "2")
      {
         ques1.SetActive(false);
         right.SetActive(true);
      }
      else
      {
         wrong.SetActive(true);
      }
   }
  

}