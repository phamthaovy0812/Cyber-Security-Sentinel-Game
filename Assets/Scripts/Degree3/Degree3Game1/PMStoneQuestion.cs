using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PMStoneQuestion : MonoBehaviour
{
    public static PMStoneQuestion Instance { get; private set; }
    [Header("Titlemap")]
    public Tilemap insertAnswerDestructibles;
    // public GameObject AddTimeObject;
    Rigidbody2D rb;
    [Header("Questions")]
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

    private Question[] m_QuestionData = { new Question("", "", "", "", "", "", "a") };
    private int m_QuestionIndex = 0;
    private bool checkCorrectAnswer = false;
    private bool checkCorrect = false;
    private int countCorrect = 0;
    private bool checkPressOneAnswer = false;
    int layer1;
    int layer2;
    [SerializeField] private TextMeshProUGUI speedPoliceText;
    [SerializeField] private TextMeshProUGUI speedThiefText;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        insertAnswerDestructibles = GetComponent<Tilemap>();

        m_QuestionData = GetQuestion.Instance.getListQuestionTopicOfDegree1().ToArray();
        m_QuestionIndex = UnityEngine.Random.Range(0, m_QuestionData.Length);
        layer1 = LayerMask.NameToLayer("enemy");
        layer2 = LayerMask.NameToLayer("Stone");
        speedPoliceText.text = FindAnyObjectByType<MovementPacman>().speed.ToString();
        speedThiefText.text = FindAnyObjectByType<MoveEnemy>().speed.ToString();

    }
    private void Update()
    {
        Physics2D.IgnoreLayerCollision(layer1, layer2, true);
        if (checkCorrectAnswer)
        {
            countCorrect++;
            if (countCorrect == 1 || countCorrect == 3 || countCorrect == 5 || countCorrect >= 8)
            {
                FindAnyObjectByType<MovementPacman>().speed += 1;
            }
            FindAnyObjectByType<MoveEnemy>().enabled = true;
            Vector3 hitPosPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;
            // Instantiate(AddTimeObject, hitPosPlayer, Quaternion.identity);
            RemoveItemAnswer(hitPosPlayer, Vector2.up);
            RemoveItemAnswer(hitPosPlayer, Vector2.down);
            RemoveItemAnswer(hitPosPlayer, Vector2.left);
            RemoveItemAnswer(hitPosPlayer, Vector2.right);
            // Time.timeScale = 1;
            QuestionObj.SetActive(false);

            Debug.Log("Movement pacman: " + FindAnyObjectByType<MovementPacman>().speed);
            speedPoliceText.text = FindAnyObjectByType<MovementPacman>().speed.ToString();
            speedThiefText.text = FindAnyObjectByType<MoveEnemy>().speed.ToString();
            checkCorrectAnswer = false;
            FindAnyObjectByType<PMCountdownPlayGame>().AddTime();


        }
    }

    void FixedUpdate()
    {
        Physics.IgnoreLayerCollision(layer1, layer2, true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            FindAnyObjectByType<MoveEnemy>().enabled = false;
            checkPressOneAnswer = false;
            CallQuestion();
            FindAnyObjectByType<CountDown>().StartCountdown();

        }


    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            FindAnyObjectByType<MoveEnemy>().enabled = true;
            QuestionObj.SetActive(false);

            StopAllCoroutines();
        }

    }
    // function 
    private void RemoveItemAnswer(Vector3 position, Vector3 direction)
    {
        position += direction;
        ClearAnswerDestructible(position);

    }
    private void ClearAnswerDestructible(Vector2 position)
    {
        Vector3Int cell = insertAnswerDestructibles.WorldToCell(position);
        TileBase tile = insertAnswerDestructibles.GetTile(cell);

        if (tile != null)
        {

            insertAnswerDestructibles.SetTile(cell, null);

        }
        // tilemapCollider.OverrideTilemapColliderGeometry(destructibleTiles);
    }

    // question
    public void BtnAnswer_Pressd(string pSlectedAnswer)
    {
        bool iscorrectAnswer = false;

        if (m_QuestionData[m_QuestionIndex].correctAnswer.Equals(pSlectedAnswer) && !checkPressOneAnswer)
        {

            iscorrectAnswer = true;
            checkCorrect = true;

        }
        else
        {
            Debug.Log("Cau tra loiw sai ");

        }
        if (!checkPressOneAnswer)
        {
            StartCoroutine(QuestionCoroutine(pSlectedAnswer, iscorrectAnswer));
            checkPressOneAnswer = true;
        }
        // StartCoroutine(ExampleCoroutine());
    }
    public void Btn_Exit()
    {
        QuestionObj.SetActive(false);
    }
    IEnumerator QuestionCoroutine(string pSlectedAnswer, bool iscorrectAnswer)
    {
        switch (pSlectedAnswer)
        {
            case "a":
                {
                    m_TxtAnswerA.GetComponent<TextMeshProUGUI>().color = Color.white;
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
                    m_TxtAnswerB.GetComponent<TextMeshProUGUI>().color = Color.white;
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
                    m_TxtAnswerC.GetComponent<TextMeshProUGUI>().color = Color.white;

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
                    m_TxtAnswerD.GetComponent<TextMeshProUGUI>().color = Color.white;

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
        checkCorrectAnswer = checkCorrect;
        checkCorrect = false;
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
        m_TxtAnswerA.GetComponent<TextMeshProUGUI>().color = Color.black;
        m_TxtAnswerB.GetComponent<TextMeshProUGUI>().color = Color.black;
        m_TxtAnswerC.GetComponent<TextMeshProUGUI>().color = Color.black;
        m_TxtAnswerD.GetComponent<TextMeshProUGUI>().color = Color.black;
    }
    public void CallQuestion()
    {
        // Time.timeScale = 0;
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

}
