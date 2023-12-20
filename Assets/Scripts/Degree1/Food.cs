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
    public GameObject enemy4;
    public GameObject enemy5;




    [SerializeField] private TextMeshProUGUI m_TxtQuestion;
    [SerializeField] private TextMeshProUGUI m_TxtAnswerA;
    [SerializeField] private TextMeshProUGUI m_TxtAnswerB;
    [SerializeField] private TextMeshProUGUI m_TxtAnswerC;
    [SerializeField] private TextMeshProUGUI m_TxtAnswerD;
    [SerializeField] private UnityEngine.UI.Image m_ImageAnswerA;
    [SerializeField] private UnityEngine.UI.Image m_ImageAnswerB;
    [SerializeField] private UnityEngine.UI.Image m_ImageAnswerC;
    [SerializeField] private UnityEngine.UI.Image m_ImageAnswerD;


    private Question[] m_QuestionData;
    private int m_QuestionIndex;
    public float delay = 3;
    int countQuestion = 0;
    public bool clickAnswer = false;
    bool checkAppearQuestion = true;
    public int indexLevel;
    private int[] arrayCheckAppearQuestion;
    // Question[] m_QuestionData;
    int indexCurrentLevel;
    private void Start()
    {
        Time.timeScale = 1;
        score = 0;
        indexCurrentLevel = LevelSystemManager.Instance.getCurrentLevel();
        arrayCheckAppearQuestion = new int[GetQuestion.Instance.getListQuestionTopicOfDegree1().Count];
        Debug.Log("Count of questions: " + GetQuestion.Instance.getListQuestionTopicOfDegree1().Count);
        m_QuestionData = GetQuestion.Instance.getListQuestionTopicOfDegree1().ToArray();
        m_QuestionIndex = UnityEngine.Random.Range(0, m_QuestionData.Length);

        RandomPose();
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

        if (m_QuestionData[m_QuestionIndex].correctAnswer.Equals(pSlectedAnswer))
        {
            Debug.Log("CorrectAnswer:  " + m_QuestionData[m_QuestionIndex].correctAnswer + "; correctPress: " + pSlectedAnswer);
            iscorrectAnswer = true;
            score += 25;
            scoreTextMesh.text = " " + score;
            Debug.Log("Cau tra loiw chinh xac");
        }
        else
        {
            Debug.Log("Cau tra loiw sai ");

        }

        StartCoroutine(QuestionCoroutine(pSlectedAnswer, iscorrectAnswer));
        // StartCoroutine(ExampleCoroutine());
    }
    private void NextQuestion()
    {
        Time.timeScale = 1;
        questions.SetActive(false);
    }
    IEnumerator QuestionCoroutine(string pSlectedAnswer, bool iscorrectAnswer)
    {
        switch (pSlectedAnswer)
        {
            case "a":
                {
                    if (iscorrectAnswer)
                    {
                        m_ImageAnswerA.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }
                    else
                    {
                        m_ImageAnswerA.GetComponent<UnityEngine.UI.Image>().color = Color.red;

                    }
                    break;
                }

            case "b":
                {
                    if (iscorrectAnswer)
                    {
                        m_ImageAnswerB.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }
                    else
                    {
                        m_ImageAnswerB.GetComponent<UnityEngine.UI.Image>().color = Color.red;

                    }
                    break;
                }


            case "c":
                {

                    if (iscorrectAnswer)
                    {
                        m_ImageAnswerC.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }
                    else
                    {
                        m_ImageAnswerC.GetComponent<UnityEngine.UI.Image>().color = Color.red;

                    }
                    break;
                }

            case "d":
                {

                    if (iscorrectAnswer)
                    {
                        m_ImageAnswerD.GetComponent<UnityEngine.UI.Image>().color = Color.green;
                    }
                    else
                    {
                        m_ImageAnswerD.GetComponent<UnityEngine.UI.Image>().color = Color.red;

                    }
                    break;
                }


        }
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(2);
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

        m_TxtQuestion.text = m_QuestionData[index].question;
        m_TxtAnswerA.text = "A: " + m_QuestionData[index].answerA;
        m_TxtAnswerB.text = "B: " + m_QuestionData[index].answerB;
        m_TxtAnswerC.text = "C: " + m_QuestionData[index].answerC;
        m_TxtAnswerD.text = "D: " + m_QuestionData[index].answerD;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {


            if (countFood > 6 && countQuestion < 0)
            {
                checkAppearQuestion = false;
                Debug.Log("check 6: countQuestion: " + countQuestion);

                CallQuestion();
            }

            else if (countFood > 7 && countQuestion < 1)
            {
                checkAppearQuestion = false;
                Debug.Log("check 7 countQuestion: " + countQuestion);

                CallQuestion();
            }
            else if (countFood > 8 && countQuestion < 2)
            {
                checkAppearQuestion = false;
                Debug.Log("check 8  countQuestion: " + countQuestion);
                CallQuestion();
            }
            else if (index % 2 == 1 && countQuestion < 3 && checkAppearQuestion == true)
            {
                CallQuestion();
            }
            else
            {
                score += 15;
                scoreTextMesh.text = " " + score;
            }

            if (countFood == 2)
            {
                enemy1.SetActive(true);
            }
            if (countFood == 4)
            {
                enemy2.SetActive(true);
            }

            if (countFood == 6 && LevelSystemManager.Instance.getCurrentLevel() > 2)
            {

                enemy3.SetActive(true);
            }
            if (countFood == 6 && LevelSystemManager.Instance.getCurrentLevel() > 4)
            {
                enemy4.SetActive(true);
            }
            if (countFood == 8 && LevelSystemManager.Instance.getCurrentLevel() > 5)
            {
                enemy5.SetActive(true);
            }

            if (countFood > 9)
            {
                GameOver.Instance.gameOver(score);
            }
            else
            {
                countFood++;
                RandomPose();
                index = UnityEngine.Random.Range(0, 20);
            }

        }
    }
    public void CallQuestion()
    {
        Time.timeScale = 0;
        countQuestion++;
        while (arrayCheckAppearQuestion[m_QuestionIndex] == 1)
        {
            m_QuestionIndex = UnityEngine.Random.Range(0, m_QuestionData.Length);
        }
        arrayCheckAppearQuestion[m_QuestionIndex] = 1;
        InitQuestion(m_QuestionIndex);
        questions.SetActive(true);


    }
    public void BtnAgain()
    {

        Debug.Log("BtnAgain");
        LevelSystemManager.Instance.CurrentLevel = LevelSystemManager.Instance.getCurrentLevel() + 1;
        int level = LevelSystemManager.Instance.getCurrentLevel();
        //set the CurrentLevel, we subtract 1 as level data array start from 0
        SceneManager.LoadScene("Degree1Game1Level_" + level);
        //load the level
        // Reload the current scene
        // SceneManager.LoadScene("Game1");
    }
    public void NextLevel()
    {
        //set the CurrentLevel, we subtract 1 as level data array start from 0
        SceneManager.LoadScene("Degree1Game1Level_" + LevelSystemManager.Instance.getCurrentLevel() + 2);
    }
    public void MenuLevel()
    {
        Time.timeScale = 0;
        SaveLoadData.Instance.LoadData();
        //set the CurrentLevel, we subtract 1 as level data array start from 0
        SceneManager.LoadScene("Degree1Game1MenuLevel");
    }
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
