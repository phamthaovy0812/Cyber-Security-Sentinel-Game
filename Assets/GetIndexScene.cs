using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetIndexScene : MonoBehaviour
{
    [SerializeField] private static GetIndexScene instance;                             //instance variable
    public static GetIndexScene Instance { get => instance; }
    public int indexPreviousScene;
    // Start is called before the first frame update
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
