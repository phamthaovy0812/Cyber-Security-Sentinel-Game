using UnityEngine;

public class ZoomImg : MonoBehaviour
{
    public GameObject pannel;

    public void OpenPannel (){
        pannel.SetActive(true);
    }
    public void ClosePannel (){
        pannel.SetActive(false);
    }
}