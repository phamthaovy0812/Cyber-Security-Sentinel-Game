using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HaveStar : MonoBehaviour
{
    [SerializeField] private static HaveStar instance;
    public static HaveStar Instance { get => instance; }

    // ================= questions
    public GameObject QuestionObj;
    [SerializeField] private TextMeshProUGUI m_TxtQuestion;
    [SerializeField] private TextMeshProUGUI m_TxtAnswerA;
    [SerializeField] private TextMeshProUGUI m_TxtAnswerB;
    [SerializeField] private TextMeshProUGUI m_TxtAnswerC;
    [SerializeField] private TextMeshProUGUI m_TxtAnswerD;
    [SerializeField] private UnityEngine.UI.Image m_ImageAnswerA;
    [SerializeField] private UnityEngine.UI.Image m_ImageAnswerB;
    [SerializeField] private UnityEngine.UI.Image m_ImageAnswerC;
    [SerializeField] private UnityEngine.UI.Image m_ImageAnswerD;

    private Question[] m_QuestionData = { new Question("", "", "", "", "", "", "") };
    private int m_QuestionIndex = 0;
    bool checkAnswer = false;

    int countStar = 0;
    public TextMeshProUGUI txtcountStar;
    public void Start()
    {
        // m_QuestionData = GetQuestion.Instance.getListQuestionTopicOfDegree1().ToArray();
        m_QuestionIndex = UnityEngine.Random.Range(0, m_QuestionData.Length);
    }

    public void BtnAnswer_Pressd(string pSlectedAnswer)
    {
        Debug.Log("Press Answer");
        bool iscorrectAnswer = false;

        if (m_QuestionData[m_QuestionIndex].correctAnswer.Equals(pSlectedAnswer))
        {
            Debug.Log("CorrectAnswer:  " + m_QuestionData[m_QuestionIndex].correctAnswer + "; correctPress: " + pSlectedAnswer);
            iscorrectAnswer = true;
            countStar++;
            txtcountStar.text = countStar.ToString();

            Debug.Log("Building add bomb");
            checkAnswer = true;
            Debug.Log("Cau tra loiw chinh xac");
        }
        else
        {
            Debug.Log("Cau tra loiw sai ");

        }

        StartCoroutine(QuestionCoroutine(pSlectedAnswer, iscorrectAnswer));
        // StartCoroutine(ExampleCoroutine());
    }
    public void BtnAnswer_Pressd_Test(string pSlectedAnswer)
    {
        Debug.Log("Press Answer");

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
        QuestionObj.SetActive(false);

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
    public void CallQuestion()
    {
        Time.timeScale = 0;
        // // countQuestion++;
        // while (arrayCheckAppearQuestion[m_QuestionIndex] == 1)
        // {
        //     m_QuestionIndex = UnityEngine.Random.Range(0, m_QuestionData.Length);
        // }
        m_QuestionIndex = UnityEngine.Random.Range(0, m_QuestionData.Length);
        // arrayCheckAppearQuestion[m_QuestionIndex] = 1;
        InitQuestion(m_QuestionIndex);
        QuestionObj.SetActive(true);


    }
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
