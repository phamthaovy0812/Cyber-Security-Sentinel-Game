using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButtonScript : MonoBehaviour
{
    public randomItemPickup randomItem;
    public GameObject itemChestGridHolder;
    // private void Start()
    // {

    //     InitializeUI();
    // }
    public void InitializeUI()                                             //method to create the level buttons
    {
        randomItemPickup item = Instantiate(randomItem, transform.position, Quaternion.identity);
        // StartCoroutine(detroy(item));
    }
    IEnumerator detroy(randomItemPickup item)
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
    // Update is called once per frame

}
