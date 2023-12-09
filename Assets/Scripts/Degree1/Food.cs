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
    [SerializeField] private GameObject overPanelGameOver;
    [SerializeField] private UnityEngine.UI.Image[] starsArray;
    [SerializeField] private TextMeshProUGUI txtScore;

    [SerializeField]
    private QuestionData[] m_QuestionData = {
        new QuestionData(
            questions: "Làm thế nào bạn có thể xác định một trang web có dấu hiệu của trang web lừa đảo?",
            answerA: " Trang web chứa nhiều thông tin chi tiết và có mục giới thiệu rõ ràng.",
            answerB: "Trang web không có địa chỉ liên hệ hoặc thông tin về công ty.",
            answerC: "Trang web có địa chỉ bảo mật 'https' và biểu tượng ổ khóa.",
            answerD: "Trang web yêu cầu người dùng nhập thông tin cá nhân.",
            correctAnswer: "b"),
        new QuestionData(
            questions: "Một trang web an toàn thường sử dụng gì để bảo vệ thông tin của người dùng?",
            answerA: " Địa chỉ web không có mục giới thiệu.",
            answerB: "Không có biểu tượng ổ khóa hoặc giao thức 'https'.",
            answerC: "Địa chỉ web chứa nhiều thông tin cá nhân của người dùng.",
            answerD: "Sử dụng chứng chỉ SSL và giao thức 'https'.",
            correctAnswer: "d"),
        new QuestionData(
            questions: "Thông báo nào có thể xuất phát từ các trang web lừa đảo?",
            answerA: "Thông báo về sự cố giao dịch và yêu cầu nhập thông tin cá nhân.",
            answerB: "Các thông báo giúp người dùng cảm thấy an toàn và hạnh phúc.",
            answerC: "Thông báo trúng thưởng và quà tặng mà không yêu cầu gì.",
            answerD: "Cả A và C.",
            correctAnswer: "d"),
        new QuestionData(
            questions: "Khi một trang web yêu cầu người dùng cung cấp nhiều thông tin cá nhân như địa chỉ nhà, số điện thoại, số CMND/CCCD, hoặc số tài khoản ngân hàng, điều này có thể đề xuất gì?",
            answerA: "Trang web là một nguồn tin cậy và an toàn.",
            answerB: " Trang web không liên quan đến việc nhận diện trang web lừa đảo.",
            answerC: "Trang web có dấu hiệu của trang web lừa đảo và có thể muốn đánh cắp thông tin cá nhân.",
            answerD: "Trang web đang cung cấp dịch vụ tài chính trực tuyến.",
            correctAnswer: "c"),
        new QuestionData(
            questions: " Dấu hiệu nào sau đây có thể xuất hiện trên trang web lừa đảo liên quan đến tên miền?",
            answerA: "Tên miền dài và khó nhớ, chứa các ký tự lạ hoặc sai chính tả.",
            answerB: "  Sử dụng dịch vụ rút gọn tên miền",
            answerC: "Tên miền sử dụng chứng chỉ SSL.",
            answerD: "Tên miền phổ biến như .com, .vn, .edu",
            correctAnswer: "a"),


     };

    private int m_QuestionIndex;
    public float delay = 3;
    int countQuestion = -1;
    public bool clickAnswer = false;

    private void Start()
    {
        score = 0;
        Time.timeScale = 1;
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
            if (countFood > 10)
            {
                GameOver(score);
            }
            if (index % 2 == 1 && countQuestion < 3)
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

            if (countFood > 8 && countQuestion > 1)
            {
                CallQuestion();
            }
            else if (countFood > 7 && countQuestion > 0)
            {
                CallQuestion();
            }
            else if (countFood > 6 && countQuestion > -1)
            {
                CallQuestion();
            }
            countFood++;
            RandomPose();
            index = UnityEngine.Random.Range(0, 20);
        }
    }
    public void CallQuestion()
    {
        Time.timeScale = 0;
        m_QuestionIndex = UnityEngine.Random.Range(0, m_QuestionData.Length);

        InitQuestion(m_QuestionIndex);
        questions.SetActive(true);

        countQuestion++;
    }
    public void BtnAgain()
    {
        Debug.Log("BtnAgain");
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneIndex);
        // SceneManager.LoadScene("Game1");
    }
    public void NextLevel()
    {
        //set the CurrentLevel, we subtract 1 as level data array start from 0
        SceneManager.LoadScene("Level_" + LevelSystemManager.Instance.getCurrentLevel() + 2);
    }
    public void MenuLevel()
    {
        //set the CurrentLevel, we subtract 1 as level data array start from 0
        SceneManager.LoadScene("MenuLevel");
    }
    public void GameOver(float score)
    {
        Time.timeScale = 0;
        overPanelGameOver.SetActive(true);
        Debug.Log("Game Over");

        if (score == 180)
        {
            countStar = 3;

        }
        else if (score >= 155)
        {
            countStar = 2;
        }
        else if (score >= 130)
        {
            countStar = 1;
        }
        else
        {
            countStar = 0;
        }
        if (countStar > 0)
        {
            LevelSystemManager.Instance.LevelComplete(countStar, score);
        }


        txtScore.text = score.ToString();
        SetStar(countStar);

    }
    private void SetStar(int starAchieved)
    {
        for (int i = 0; i < starsArray.Length; i++)             //loop through entire star array
        {

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
