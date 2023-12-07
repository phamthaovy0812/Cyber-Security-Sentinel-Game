using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using System;
using System.Security.Permissions;
using UnityEngine.SceneManagement;



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
    [SerializeField] private static Food instance;                             //instance variable
    public static Food Instance { get => instance; } 
    public BoxCollider2D foodSpawn;
    public float score;
    public int index = 0;
    public int countFood = 0;
    int countStar;
    public float waitTimeCheckAns = 3f;
    public TextMeshProUGUI scoreTextMesh;
    public GameObject questions;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;




    [SerializeField] private TextMeshProUGUI m_TxtQuestion;
    [SerializeField] private TextMeshProUGUI m_TxtAnswerA;
    [SerializeField] private TextMeshProUGUI m_TxtAnswerB;
    [SerializeField] private TextMeshProUGUI m_TxtAnswerC;
    [SerializeField] private TextMeshProUGUI m_TxtAnswerD;
    [SerializeField] private UnityEngine.UI.Image m_ImageAnswerA;
    [SerializeField] private UnityEngine.UI.Image m_ImageAnswerB;
    [SerializeField] private UnityEngine.UI.Image m_ImageAnswerC;
    [SerializeField] private UnityEngine.UI.Image m_ImageAnswerD;
    [SerializeField] private GameObject overPanelGameOver;
    [SerializeField] private UnityEngine.UI.Image[] starsArray;
    [SerializeField] private TextMeshProUGUI txtScore;

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
        Time.timeScale = 1;
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

        StartCoroutine(ExampleCoroutine(pSlectedAnswer, iscorrectAnswer));
        // StartCoroutine(ExampleCoroutine());
    }
    private void NextQuestion()
    {
        Time.timeScale = 1;
        questions.SetActive(false);
    }
    IEnumerator ExampleCoroutine(string pSlectedAnswer, bool iscorrectAnswer)
    {
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
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        questions.SetActive(false);

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
            if (countFood == 2)
            {
                enemy1.SetActive(true);
            }
            if (countFood == 4)
            {
                enemy2.SetActive(true);
            }
            if (countFood == 6)
            {
                enemy3.SetActive(true);
            }
            if(score >= 100){
                GameOver(score);
            }
            countFood++;
            RandomPose();
            index = UnityEngine.Random.Range(0, 20);
        }
    }
    public void BtnMenuLevel(){
        

    }
    public void NextLevel(){
        
         //set the CurrentLevel, we subtract 1 as level data array start from 0
        SceneManager.LoadScene(2);  
    }
    public void GameOver(float score)
    {
        Time.timeScale = 0;
        overPanelGameOver.SetActive(true);
        Debug.Log("Game Over");

        if (score >= 300)
        {
            countStar = 3;

        }
        else if (score >= 200)
        {
            countStar = 2;
        }
        else if (score >= 50)
        {
            countStar = 1;
        }
        else
        {
            countStar = 0;
        }
        
        LevelSystemManager.Instance.LevelComplete(countStar, score);
        
        txtScore.text = score.ToString();
        SetStar(countStar);

    }
    private void SetStar(int starAchieved)
    {
        for (int i = 0; i < starsArray.Length; i++)             //loop through entire star array
        {
            /// <summary>
            /// if i is less than starAchieved
            /// Eg: if 2 stars are achieved we set the start at index 0 and 1 color to unlockColor, as array start from 0 element
            /// </summary>
            if (i < starAchieved)
            {
                starsArray[i].GetComponent<UnityEngine.UI.Image>().color = Color.white;              //set its color to unlockColor
            }
            else
            {
                starsArray[i].GetComponent<UnityEngine.UI.Image>().color = Color.black;                //else set its color to lockColor
            }
        }
    }
}
