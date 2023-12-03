using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    public GameObject pause;

    public void clickButtonPause(){
        Time.timeScale = 0;
        pause.SetActive(true);
    }
    public void clickButtonPlay(){
        Time.timeScale = 1;
        pause.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
