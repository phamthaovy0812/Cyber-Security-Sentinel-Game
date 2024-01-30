using System.Collections;
using TMPro;
using UnityEngine;

public class Room323Q4 : MonoBehaviour
{
   public TMP_InputField q4;
   public GameObject right;
   public GameObject wrong;
   public GameObject ques4;
 
   public void CheckQ2()
   {
      if (q4.text == "A" || q4.text == "a")
      {
         ques4.SetActive(false);
         right.SetActive(true);
      }
      else
      {
         wrong.SetActive(true);
      }
   }
  

}