using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using System;
using System.Security.Permissions;



public class QuestionData
{
    public string questions;
    public string answerA;
    public string answerB;
    public string answerC;
    public string answerD;
    public string correctAnswer;

    public QuestionData()
    {
        questions = answerA = answerB = answerC = answerD = correctAnswer = "";
    }
    public QuestionData(string questions, string answerA, string answerB, string answerC, string answerD, string correctAnswer)
    {
        this.questions = questions;
        this.answerA = answerA;
        this.answerB = answerB;
        this.answerC = answerC;
        this.answerD = answerD;
        this.correctAnswer = correctAnswer;
    }
}
public class Food : MonoBehaviour
{
    public BoxCollider2D foodSpawn;
    public float score;
    public int index = 0;
    public float waitTimeCheckAns = 3f;
    public TextMeshProUGUI scoreTextMesh;
    public GameObject questions;




    [SerializeField] private TextMeshProUGUI m_TxtQuestion;
    [SerializeField] private TextMeshProUGUI m_TxtAnswerA;
    [SerializeField] private TextMeshProUGUI m_TxtAnswerB;
    [SerializeField] private TextMeshProUGUI m_TxtAnswerC;
    [SerializeField] private TextMeshProUGUI m_TxtAnswerD;
    [SerializeField] private UnityEngine.UI.Image m_ImageAnswerA;
    [SerializeField] private UnityEngine.UI.Image m_ImageAnswerB;
    [SerializeField] private UnityEngine.UI.Image m_ImageAnswerC;
    [SerializeField] private UnityEngine.UI.Image m_ImageAnswerD;

    [SerializeField]
    private QuestionData[] m_QuestionData = {
        new QuestionData(questions: "Cau hoi 1", answerA: "Dap an A",answerB: "Dap an B",answerC: "Dap an C", answerD: "Dap an D", correctAnswer: "a"),
        new QuestionData(questions: "Cau hoi 2", answerA: "Dap an A",answerB: "Dap an B",answerC: "Dap an C", answerD: "Dap an D", correctAnswer: "a"),
        new QuestionData(questions: "Cau hoi 3", answerA: "Dap an A",answerB: "Dap an B",answerC: "Dap an C", answerD: "Dap an D", correctAnswer: "a"),
        new QuestionData(questions: "Cau hoi 4", answerA: "Dap an A",answerB: "Dap an B",answerC: "Dap an C", answerD: "Dap an D", correctAnswer: "a"),
        new QuestionData(questions: "Cau hoi 5", answerA: "Dap an A",answerB: "Dap an B",answerC: "Dap an C", answerD: "Dap an D", correctAnswer: "a"),

     };

    private int m_QuestionIndex;
    public float delay = 3;
    float timer;
    public bool clickAnswer = false;
    private void Start()
    {
        m_QuestionIndex = UnityEngine.Random.Range(0, m_QuestionData.Length);
        RandomPose();


    }
    private void Update()
    {
        scoreTextMesh.text = " " + score;
        
        m_QuestionIndex = UnityEngine.Random.Range(0, m_QuestionData.Length);

    }
    private void RandomPose()
    {
        Bounds bounds = this.foodSpawn.bounds;
        float x = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
        float y = UnityEngine.Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    public void BtnAnswer_Pressd(string pSlectedAnswer)
    {
        bool iscorrectAnswer = false;
        
        if (m_QuestionData[m_QuestionIndex].correctAnswer == pSlectedAnswer)
        {
            iscorrectAnswer = true;

            score += 40;
            Debug.Log("Cau tra loiw chinh xac");
        }
        else
        {
            iscorrectAnswer = false;
            Debug.Log("Cau tra loiw sai ");

        }

        clickAnswer = true;
        
        StartCoroutine(ExampleCoroutine(pSlectedAnswer,iscorrectAnswer));
        // StartCoroutine(ExampleCoroutine());
    }
    private void NextQuestion()
    {
        Time.timeScale = 1;
        questions.SetActive(false);
    }
    IEnumerator ExampleCoroutine(string pSlectedAnswer, bool iscorrectAnswer)
    {
        Debug.Log("Begin:  ");
        switch (pSlectedAnswer)
        {
            case "a":
                {
                    m_ImageAnswerA.GetComponent<UnityEngine.UI.Image>().color = iscorrectAnswer ? Color.green : Color.red;
                    break;
                }

            case "b":
                m_ImageAnswerB.GetComponent<UnityEngine.UI.Image>().color = iscorrectAnswer ? Color.green : Color.red;
                break;
            case "c":
                m_ImageAnswerC.GetComponent<UnityEngine.UI.Image>().color = iscorrectAnswer ? Color.green : Color.red;
                break;
            case "d":
                m_ImageAnswerD.GetComponent<UnityEngine.UI.Image>().color = iscorrectAnswer ? Color.green : Color.red;

                break;


        }
        Debug.Log("Begin time ");
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(3);
        Debug.Log("Mid: ");
        Time.timeScale = 1;
        questions.SetActive(false);
        Debug.Log("End ");

    }
    private void InitQuestion(int index)
    {
        if (index < 0 || index >= m_QuestionData.Length)
        {
            return;
        }

        m_ImageAnswerA.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        m_ImageAnswerB.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        m_ImageAnswerC.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        m_ImageAnswerD.GetComponent<UnityEngine.UI.Image>().color = Color.white;

        m_TxtQuestion.text = m_QuestionData[index].questions;
        m_TxtAnswerA.text = "A: " + m_QuestionData[index].answerA;
        m_TxtAnswerB.text = "B: " + m_QuestionData[index].answerB;
        m_TxtAnswerC.text = "C: " + m_QuestionData[index].answerC;
        m_TxtAnswerD.text = "D: " + m_QuestionData[index].answerD;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (index % 2 == 1)
            {
                Time.timeScale = 0;
                questions.SetActive(true);
                InitQuestion(m_QuestionIndex);
            }
            else
            {
                score += 20;
            }

            RandomPose();

            index = UnityEngine.Random.Range(0, 20);
        }
    }
}
