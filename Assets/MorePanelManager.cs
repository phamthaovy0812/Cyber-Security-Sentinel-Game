using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorePanelManager : MonoBehaviour
{

    [Header("Panel Manager")]
    public GameObject taskPanel;
    public GameObject docPanel;
    public GameObject lineTask;
    public GameObject lineDoc;
    [Header("Task")]
    public GameObject task1;
    public GameObject task2;
    public GameObject task3;
    public GameObject task4;
    [Header("Icon Completed task")]
    public GameObject iconCompleted1;
    public GameObject iconCompleted2;
    public GameObject iconCompleted3;
    public GameObject iconCompleted4;
    // [Header("Button Link Document")]


    public void OpenTaskPanel()
    {
        lineDoc.SetActive(false);
        lineTask.SetActive(true);
        taskPanel.SetActive(true);
        docPanel.SetActive(false);
    }
    public void OpenDocumentPanel()
    {
        lineTask.SetActive(false);
        lineDoc.SetActive(true);
        taskPanel.SetActive(false);
        docPanel.SetActive(true);
    }
    public void goToDocumentOfDegree(int degree)
    {
        string url = "";
        if (degree == 1)
        {
            url = "https://docs.google.com/document/d/16K3R_jK_pvnKq_4CoFgpz-BiyAhoN-XLuQEVCc7Cg_U/edit?usp=sharing";
        }
        else if (degree == 2)
        {
            url = "https://docs.google.com/document/d/1B11euPrOXBllSimCZAivF7EjhLBaI56xsFbUNPj_Sy4/edit?usp=sharing";

        }
        else if (degree == 3)
        {
            url = "https://docs.google.com/document/d/1rhC6StQe-2sBZe3TGUZjSEFiHpwQzfCwVwFL4D_s2Ls/edit?usp=sharing";

        }
        else
        {
            url = "https://docs.google.com/document/d/1rhC6StQe-2sBZe3TGUZjSEFiHpwQzfCwVwFL4D_s2Ls/edit?usp=sharing";

        }
        Application.OpenURL(url);

    }
    // Update is called once per frame
    void Start()
    {
        lineDoc.SetActive(false);
        lineTask.SetActive(true);
        taskPanel.SetActive(true);
        docPanel.SetActive(false);

        iconCompleted1.SetActive(false);
        iconCompleted2.SetActive(false);
        iconCompleted3.SetActive(false);
        iconCompleted4.SetActive(false);

    }
    void Update()
    {
        if (APIUser.Instance.GetUser().id_level == 1)
        {
            task1.SetActive(true);
            task2.SetActive(false);
            task3.SetActive(false);
            task4.SetActive(false);

            iconCompleted1.SetActive(false);
            iconCompleted2.SetActive(false);
            iconCompleted3.SetActive(false);
            iconCompleted4.SetActive(false);
        }
        if (APIUser.Instance.GetUser().id_level == 2)
        {
            task1.SetActive(true);
            task2.SetActive(true);
            task3.SetActive(false);
            task4.SetActive(false);

            iconCompleted1.SetActive(true);
            iconCompleted2.SetActive(false);
            iconCompleted3.SetActive(false);
            iconCompleted4.SetActive(false);
        }
        if (APIUser.Instance.GetUser().id_level == 3)
        {
            task1.SetActive(true);
            task2.SetActive(true);
            task3.SetActive(true);
            task4.SetActive(false);

            iconCompleted1.SetActive(true);
            iconCompleted2.SetActive(true);
            iconCompleted3.SetActive(false);
            iconCompleted4.SetActive(false);
        }
        if (APIUser.Instance.GetUser().id_level == 4)
        {
            task1.SetActive(true);
            task2.SetActive(true);
            task3.SetActive(true);
            task4.SetActive(true);

            iconCompleted1.SetActive(true);
            iconCompleted2.SetActive(true);
            iconCompleted3.SetActive(true);
            iconCompleted4.SetActive(false);
        }
        if (APIUser.Instance.GetUser().id_level == 4)
        {

            iconCompleted1.SetActive(true);
            iconCompleted2.SetActive(true);
            iconCompleted3.SetActive(true);
            iconCompleted4.SetActive(true);
        }
    }
}
