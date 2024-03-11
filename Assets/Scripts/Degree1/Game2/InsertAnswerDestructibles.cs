using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InsertAnswerDestructibles : MonoBehaviour
{
    [SerializeField] private static InsertAnswerDestructibles instance;                             //instance variable
    public static InsertAnswerDestructibles Instance { get => instance; }          //instance getter

    // public Tilemap insertAnswerDestructibles;
    private Rigidbody2D rb;
    public Vector3Int location;
    [Header("GameObject")]
    // public GameObject gameObjectChooseAnswer;
    public GameObject itemChoice;

    private int randomIndex;
    private ListArrayAnswer listArrayAnswer;
    private ArrayAnswer[] arrayAnswers;

    private int[] arrayCheckAppeared;
    private int countWrongAnswer;
    private int indexLevel;
    public int countCorrectAnswer = 0;
    [Header("Text")]
    public TextMeshProUGUI AnswerText;
    // public TextMeshProUGUI choiceItemText;
    public TextMeshProUGUI isCorrectAnswerText;
    public TextMeshProUGUI questionText;
    private bool checkCorrect = false;
    public bool checkAppear = false;
    ListQuestion[] listQuestions = {
        new ListQuestion("Một trong các dấu hiệu nhận biết Lừa đảo qua website là: ","Một trong các cách phòng tránh Lừa đảo qua website là: "),
        new ListQuestion("Một trong các dấu hiệu nhận biết lừa đảo qua mạng xã hội: ","Một trong các cách phòng tránh lừa đảo qua mạng xã hội: "),
        new ListQuestion("Một trong các dấu hiệu nhận biết Lừa đảo qua tin nhắn SMS : ","Một trong các cách phòng tránh Lừa đảo qua tin nhắn SMS : "),
        new ListQuestion("Một trong các dấu hiệu nhận biết Lừa Đảo qua Email: ","Một trong các cách phòng tránh Lừa Đảo qua Email: "),
        new ListQuestion("Một trong các dấu hiệu nhận biết lừa đảo qua ứng dụng: ","Một trong các cách phòng tránh lừa đảo qua ứng dụng: "),
        new ListQuestion("Một trong các dấu hiệu nhận biết Lừa Đảo qua Cuộc Gọi: ","Một trong các cách phòng tránh Lừa Đảo qua Cuộc Gọi: ")
    };

    // public randomItemPickup itemPickupRandom;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        checkCorrect = false;
        indexLevel = LevelSystemManager.Instance.CurrentLevel;

        arrayAnswers = GetListArrayAnswer()[indexLevel].arrayAnswers;
        randomIndex = UnityEngine.Random.Range(0, arrayAnswers.Length);

        arrayCheckAppeared = new int[arrayAnswers.Length];
        AnswerText.text = arrayAnswers[randomIndex].answer;
        // AnswerText.text = "";
        if (arrayAnswers[randomIndex].question == 1)
        {
            questionText.text = listQuestions[indexLevel].question1;

        }
        else
        {
            questionText.text = listQuestions[indexLevel].question2;

        }
        arrayCheckAppeared[randomIndex] = 1;

    }
    void Update()
    {
        if (checkAppear)
        {
            AppearAnswer();
            checkAppear = false;
            checkCorrect = false;
        }

    }
    private void Awake()
    {
        if (instance == null)                                               //if instance is null
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);                                       //set this as instance
        }
        else
        {
            Destroy(gameObject);                                            //else destroy it
        }
    }
    bool checkEndQuestion()
    {
        int result = Array.Find(arrayCheckAppeared, x => x == 0);
        if (result == 0) return true;
        else return false;

    }
    public void AppearAnswer()
    {

        randomIndex = UnityEngine.Random.Range(0, arrayAnswers.Length);
        AnswerText.text = arrayAnswers[randomIndex].answer;
        // AnswerText.text = "";
        if (arrayAnswers[randomIndex].question == 1)
        {
            questionText.text = listQuestions[indexLevel].question1;

        }
        else
        {
            questionText.text = listQuestions[indexLevel].question2;

        }
        arrayCheckAppeared[randomIndex] = 1;
    }
    public void Btn_Yes()
    {

        isCorrectAnswerText.text = "";
        AnswerText.text = "";
        questionText.text = "";
        if (arrayAnswers[randomIndex].isCorrect)
        {
            countCorrectAnswer++;
            FindObjectOfType<MovementController>().countCorrectAnswer++;

            isCorrectAnswerText.text = "Chính xác";
            isCorrectAnswerText.color = Color.blue;
            checkCorrect = true;
        }
        else
        {
            countWrongAnswer++;
            isCorrectAnswerText.text = "Sai";
            isCorrectAnswerText.color = Color.red;
            checkCorrect = false;

        }
        // Destroy(gameObjectChooseAnswer);
        StartCoroutine(CountdownOneCoroutine());

        // EnableGameObject();



    }

    public void Btn_No()
    {

        Debug.Log("Btn_No");
        // Destroy(gameObjectChooseAnswer);
        // FindAnyObjectByType<STEnemySpawner>().setTime();
        isCorrectAnswerText.text = "";
        AnswerText.text = "";
        questionText.text = "";
        if (!arrayAnswers[randomIndex].isCorrect)
        {
            Debug.Log("Answer: " + arrayAnswers[randomIndex].isCorrect);
            countCorrectAnswer++;
            FindObjectOfType<MovementController>().countCorrectAnswer++;

            isCorrectAnswerText.text = "Chính xác";
            isCorrectAnswerText.color = Color.blue;
            checkCorrect = true;
            // itemChoice.SetActive(true);

            // FindAnyObjectByType<ItemButtonScript>().InitializeUI();

            // FindAnyObjectByType<ItemPickup>().OnItemPickup();

        }
        else
        {
            countWrongAnswer++;
            isCorrectAnswerText.text = "Sai";
            isCorrectAnswerText.color = Color.red;
            checkCorrect = false;
        }
        // Destroy(gameObjectChooseAnswer);
        StartCoroutine(CountdownOneCoroutine());

        // EnableGameObject();


    }
    IEnumerator CountdownOneCoroutine()
    {
        yield return new WaitForSeconds(1f);


        isCorrectAnswerText.text = "";
        AnswerText.text = "";
        questionText.text = "";
        gameObject.SetActive(false);

        if (checkCorrect)
        {
            itemChoice.SetActive(true);
            FindAnyObjectByType<ItemButtonScript>().InitializeUI();
        }
        // else
        // {
        //     gameObject.isTriggered = false;
        // }
        FindAnyObjectByType<MovementController>().enabled = true;
        FindAnyObjectByType<STEnemySpawner>().enabled = true;
        if (FindAnyObjectByType<STEnemySpawner>().countChildrenEnemy > 0)
        {
            int count = FindAnyObjectByType<STEnemySpawner>().countChildrenEnemy;
            for (int i = 0; i < count; i++)
            {
                FindAnyObjectByType<EnemyBomber>().enabled = true;

            }
        }

    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {

    //     if (collision.gameObject.tag == "Player")
    //     {
    //         // Time.timeScale = 0;

    //         FindObjectOfType<MovementController>().enabled = false;
    //         // FindObjectOfType<BoEnemyShooter>().enabled = false;
    //         FindObjectOfType<STEnemySpawner>().enabled = false;
    //         // FindObjectOfType<PathFinderBomberman>().enabled = false;
    //         // FindObjectOfType<EnemyBomber>().enabled = false;
    //         gameObjectChooseAnswer.SetActive(true);
    //         // FindObjectOfType<CountDown>().enabled = true;
    //         // FindObjectOfType<CountDown>().StartCountdown();


    //         AppearAnswer();

    //         // Vector3 hitPosPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;
    //         // hitPosPlayer.x = Mathf.Round(hitPosPlayer.x);
    //         // hitPosPlayer.y = Mathf.Round(hitPosPlayer.y);
    //         // RemoveItemAnswer(hitPosPlayer, Vector2.up);
    //         // RemoveItemAnswer(hitPosPlayer, Vector2.down);
    //         // RemoveItemAnswer(hitPosPlayer, Vector2.left);
    //         // RemoveItemAnswer(hitPosPlayer, Vector2.right);


    //     }
    // }
    public void Btn_Choose_Chest()
    {
        Instantiate(itemChoice, transform.position, Quaternion.identity);
    }
    private void EnableGameObject()
    {
        FindObjectOfType<MovementController>().enabled = true;
        // FindObjectOfType<BoEnemyShooter>().enabled = true;
        FindObjectOfType<STEnemySpawner>().enabled = true;
        // FindObjectOfType<PathFinderBomberman>().enabled = true;
        // FindObjectOfType<EnemyBomber>().enabled = true;



    }
    public void DestroyObject()
    {
        EnableGameObject();
        // gameObjectChooseAnswer.SetActive(false);
    }
    private void RemoveItemAnswer(Vector3 position, Vector3 direction)
    {
        position += direction;
        ClearAnswerDestructible(position);

    }
    private void ClearAnswerDestructible(Vector2 position)
    {
        // Vector3Int cell = insertAnswerDestructibles.WorldToCell(position);
        // TileBase tile = insertAnswerDestructibles.GetTile(cell);

        // if (tile != null)
        // {

        //     insertAnswerDestructibles.SetTile(cell, null);

        // }
        // tilemapCollider.OverrideTilemapColliderGeometry(destructibleTiles);
    }

    public ListArrayAnswer[] GetListArrayAnswer()
    {
        ListArrayAnswer[] listArrayAnswers = new ListArrayAnswer[6];
        // lừa đảo qua trang website
        ArrayAnswer[] arrayAnswer1 = {
        new ArrayAnswer("Trang web không có nhiều thông tin ",true,1),
        new ArrayAnswer("Địa chỉ web không có khóa bảo mật",true,1),
        new ArrayAnswer("Trang web yêu cầu thông tin cá nhân quá mức",true,1),
        new ArrayAnswer("Thông báo giật gân và cảnh báo đột ngột",true,1),
        new ArrayAnswer("Kiểm tra tên miền",true,2),
        new ArrayAnswer("Kiểm tra URL trang web",true,2),
        new ArrayAnswer("Kiểm tra thông tin doanh nghiệp",true,2),
        new ArrayAnswer("Nhận biết trang web lừa đảo qua các thông báo trên web",true,2),
        new ArrayAnswer("Trang web không có địa chỉ liên hệ hoặc thông tin về công ty.",true),
        new ArrayAnswer("Giao diện và thiết kế đáng ngờ",true,2),
        new ArrayAnswer("Thời gian tải trang chậm",false, 1),
        new ArrayAnswer("Sử dụng ngôn ngữ khó hiểu",false, 1),
        new ArrayAnswer("Dựa vào thiết kế trang web",false,2),
        new ArrayAnswer("Phụ thuộc vào mức độ quảng cáo",false,2),
        };
        listArrayAnswers[0] = new ListArrayAnswer(0, arrayAnswer1);
        // lừa đảo qua mạng xã hội 
        ArrayAnswer[] arrayAnswer2 = {
            new ArrayAnswer("Bẫy tình trên mạng xã hội",true),
        new ArrayAnswer("Giả danh lãnh đạo",true),
        new ArrayAnswer("Yêu cầu cung cấp thông tin cá nhân",true),
        new ArrayAnswer("Lời mời tham gia các sàn giao dịch ảo",true),
        new ArrayAnswer("Thông báo giả mạo trúng thưởng",true),
        new ArrayAnswer("Thận trọng khi nhận được các đường link lạ qua Facebook, zalo,..",true),
        new ArrayAnswer("Thường xuyên đổi mật khẩu cho tài khoản mạng xã hội",true),
        new ArrayAnswer("Xem xét trước những tin tuyển dụng CTV việc nhẹ lương cao",true),
        new ArrayAnswer("Kiểm tra nguồn gốc thông tin",true),
        new ArrayAnswer("Kiểm tra tính chất đáng tin cậy của tài khoản",true),
        new ArrayAnswer("Tuyển cộng tác viên bán hàng",false),
        new ArrayAnswer("Phụ thuộc vào cảm giác cá nhân mà không có kiểm chứng",false),
        new ArrayAnswer("Chấp nhận mọi yêu cầu kết bạn hoặc tham gia cộng đồng",false),
        new ArrayAnswer("Chia sẻ thông tin cá nhân",false),
        };
        listArrayAnswers[1] = new ListArrayAnswer(0, arrayAnswer2);
        // Lừa đảo qua tin nhắn SMS 

        ArrayAnswer[] arrayAnswer3 = {
            new ArrayAnswer("Số điện thoại lạ lẫm",true),
        new ArrayAnswer("Tin nhắn cấp bách",true),
        new ArrayAnswer("Chứa liên kết đáng ngờ",true),
        new ArrayAnswer("Chính tả và ngữ pháp kém",true),
        new ArrayAnswer("Yêu cầu cung cấp thông tin cá nhân",true),
        new ArrayAnswer("Kiểm tra số điện thoại nguồn gốc",true),
        new ArrayAnswer("aKhông mở liên kết hoặc tải tệp đính kèm chưa xác minh",true),
        new ArrayAnswer("Không cung cấp thông tin cá nhân",true),
        new ArrayAnswer("Báo cáo tin nhắn lừa đảo",true),
        new ArrayAnswer("Thông báo cho bạn bè và người thân",true),
        new ArrayAnswer("Nhận biết dựa trên loại tin nhắn",false),
        new ArrayAnswer("Tin nhắn từ số điện thoại chính thức",false),
        new ArrayAnswer("Tự tin vào số điện thoại nguồn gốc",false),
        new ArrayAnswer("Phản ứng quá vội vàng",false),
        };
        listArrayAnswers[2] = new ListArrayAnswer(0, arrayAnswer3);
        // Lừa Đảo qua Email

        ArrayAnswer[] arrayAnswer4 = {
            new ArrayAnswer("Email từ địa chỉ lạ lẫm",true),
        new ArrayAnswer("Yêu cầu tiết lộ thông tin cá nhân",true),
        new ArrayAnswer("Tin nhắn cấp bách",true),
        new ArrayAnswer("Liên kết hoặc tệp đính kèm đáng ngờ",true),
        new ArrayAnswer("Lỗi chính tả và ngữ pháp",true),
        new ArrayAnswer("Kiểm tra kỹ địa chỉ email",true),
        new ArrayAnswer("Không tiết lộ thông tin cá nhân",true),
        new ArrayAnswer("Không nhấp vào liên kết",true),
        new ArrayAnswer("Báo cáo email giả mạo",true),
        new ArrayAnswer("Sử dụng phần mềm chống phishing",true),
        new ArrayAnswer("Nhận diện vào hình thức email",false),
        new ArrayAnswer("Phụ thuộc vào hình thức chữ ký số",false),
        new ArrayAnswer("Phản hồi email và hỏi họ xem họ là ai",false),
        new ArrayAnswer("Nhấp vào liên kết trong email",false),
        };
        listArrayAnswers[3] = new ListArrayAnswer(0, arrayAnswer4);
        //  lừa đảo qua ứng dụng

        ArrayAnswer[] arrayAnswer5 = {
            new ArrayAnswer("Yêu cầu thanh toán trước dịch vụ",true),
        new ArrayAnswer("đánh giá kém",true),
        new ArrayAnswer("Quy trình đăng ký phức tạp",true),
        new ArrayAnswer("Liên lạc không rõ ràng",true),
        new ArrayAnswer("Thông báo giả mạo hoặc lừa đảo",true),
        new ArrayAnswer("Tìm hiểu về ứng dụng",true),
        new ArrayAnswer("Sử dụng cửa hàng ứng dụng chính thức",true),
        new ArrayAnswer("Kiểm tra quyền ứng dụng",true),
        new ArrayAnswer("Cập nhật đều đặn",true),
        new ArrayAnswer("Đọc và hiểu điều khoản sử dụng",true),
        new ArrayAnswer("Phụ thuộc vào thiếu đánh giá",false),
        new ArrayAnswer("Dựa vào quá nhiều quảng cáo",false),
        new ArrayAnswer("Tự tin vào đánh giá ứng dụng",false),
        new ArrayAnswer("Chia sẻ thông tin cá nhân không cần thiết",false),
        };
        listArrayAnswers[4] = new ListArrayAnswer(0, arrayAnswer5);
        // Lừa Đảo qua Cuộc Gọi

        ArrayAnswer[] arrayAnswer6 = {
            new ArrayAnswer("Tạo tình huống cấp bách",true),
        new ArrayAnswer("Yêu cầu tiết lộ thông tin cá nhân hoặc tài chính",true),
        new ArrayAnswer("Giả danh là ai đó quen thuộc",true),
        new ArrayAnswer("Tone lời đe dọa hoặc áp lực",true),
        new ArrayAnswer("Thông báo về vấn đề pháp lý",true),
        new ArrayAnswer("Xác minh thông tin",true),
        new ArrayAnswer("Không chia sẻ thông tin cá nhân",true),
        new ArrayAnswer("Ghi âm cuộc gọi (nếu có thể)",true),
        new ArrayAnswer("Thận trọng với cuộc gọi đe dọa",true),
        new ArrayAnswer("Lắng nghe và cân nhắc",true),
        new ArrayAnswer("Thông tin số điện thoại hiển thị",false),
        new ArrayAnswer("Tổ chức được đề cập đến",false),
        new ArrayAnswer("Lập tức làm theo yêu cầu của đối phương.",false),
        new ArrayAnswer("Chia sẻ thông tin cá nhân",false),
        };
        listArrayAnswers[5] = new ListArrayAnswer(0, arrayAnswer6);


        return listArrayAnswers;
    }


}
class ListQuestion
{
    public string question1;
    public string question2;
    public ListQuestion(string question1, string question2)
    {
        this.question1 = question1;
        this.question2 = question2;
    }
}
