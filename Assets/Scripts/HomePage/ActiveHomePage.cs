using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveHomePage : MonoBehaviour
{
    private static ActiveHomePage instance;
    public static ActiveHomePage Instance { get => instance; }
    [Header("flagDegree")]
    public bool isOpenFlagPolice = false;
    public bool isOpenFlagDegree1 = false;
    public bool isOpenFlagDegree2 = false;
    public bool isOpenFlagDegree3 = false;
    public bool isOpenFlagDegree4 = false;
    public bool isBeginGame = true;

    private void Awake()
    {
        if (instance == null)                                               //if instance is null
        {
            instance = this;                                                //set this as instance
                                                                            // DontDestroyOnLoad(gameObject);                                  //make it DontDestroyOnLoad
        }
        else
        {
            Destroy(gameObject);                                            //else destroy it
        }
    }
}
