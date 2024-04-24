using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsiveSize : MonoBehaviour
{
    public GameObject backgroundImageObject;
    public float varScale = 1f;
    // Start is called before the first frame update
    void Awake()
    {
        Camera mainCamera = Camera.main;
        ScreenCredentials();
    }


    // Update is called once per frame
    void ScreenCredentials()
    {
        int height = Screen.height;
        int width = Screen.width;
        Debug.Log("Screen height: " + height + " width" + width);
        int y = 768;
        int x = 1024;
        if (Screen.height.Equals(y) && Screen.width.Equals(x))
        {
            Vector3 newScale = transform.localScale;
            newScale *= varScale;
            backgroundImageObject.transform.localScale = newScale;

        }
        else
        {
            Debug.Log("Not equal");
        }

    }
}
