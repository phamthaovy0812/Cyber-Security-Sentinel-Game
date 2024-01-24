using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetItemStrong : MonoBehaviour
{
    [SerializeField] private static GetItemStrong instance;                             //instance variable
    public static GetItemStrong Instance { get => instance; }          //instance getter
    private Rigidbody2D rb;
    public Vector3Int location;
    public GameObject gameObjectChooseAnswer;
    public TextMeshProUGUI txtAnswer;
    private int randomIndex;
    private ListArrayAnswer listArrayAnswer;
    private ArrayAnswer[] arrayAnswers;

    private int[] arrayCheckAppeared;
    // private int countWrongAnswer;
    // public int countCorrectAnswer = 0;
    // public TextMeshProUGUI countCorrectAnswerText;
    public TextMeshProUGUI isCorrectAnswerText;
    private int indexTopic;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        indexTopic = 0; //LevelSystemManager.Instance.CurrentLevel;
        arrayAnswers = GetListArrayAnswer()[indexTopic].arrayAnswers;
        randomIndex = UnityEngine.Random.Range(0, arrayAnswers.Length);
        arrayCheckAppeared = new int[arrayAnswers.Length];
        // countWrongAnswer = 0;
        // countCorrectAnswerText.text = "0";

    }
    private void Awake()
    {
        if (instance == null)                                               //if instance is null
        {
            instance = this;                                                //set this as instance
        }
        else
        {
            Destroy(gameObject);                                            //else destroy it
        }
    }
    public void AppearAnswer()
    {
        // Time.timeScale = 0;
        while (arrayCheckAppeared[randomIndex] != 0)
        {
            randomIndex = UnityEngine.Random.Range(0, arrayAnswers.Length);

        }
        txtAnswer.text = arrayAnswers[randomIndex].answer;
        arrayCheckAppeared[randomIndex] = 1;
    }
    public void Btn_Yes()
    {

        txtAnswer.text = "";
        if (arrayAnswers[randomIndex].isCorrect)
        {
            Debug.Log("Answer: " + arrayAnswers[randomIndex].isCorrect);
            // countCorrectAnswer++;
            FindObjectOfType<MovementController>().countCorrectAnswer++;

            isCorrectAnswerText.text = "Chính xác";
            isCorrectAnswerText.color = Color.blue;
            // countCorrectAnswerText.text = countCorrectAnswer.ToString();
        }
        else
        {
            // countWrongAnswer++;
            isCorrectAnswerText.text = "Sai";
            isCorrectAnswerText.color = Color.red;
        }
        // Destroy(gameObjectChooseAnswer);
        StartCoroutine(CountdownOneCoroutine());

        // EnableGameObject();
        Time.timeScale = 1;


    }
    IEnumerator CountdownOneCoroutine()
    {
        yield return new WaitForSeconds(1f);
        isCorrectAnswerText.text = "";
        gameObjectChooseAnswer.SetActive(false);


    }
    public void Btn_No()
    {

        Debug.Log("Btn_No");
        // Destroy(gameObjectChooseAnswer);
        FindAnyObjectByType<STEnemySpawner>().setTime();
        gameObjectChooseAnswer.SetActive(false);

        // EnableGameObject();
        Time.timeScale = 1;



    }


    // private void OnCollisionEnter2D(Collision2D collision)
    // {

    //     if (collision.gameObject.tag == "Player")
    //     {
    //         // Time.timeScale = 0;

    //         // FindObjectOfType<MovementController>().enabled = false;
    //         // FindObjectOfType<BoEnemyShooter>().enabled = false;
    //         // FindObjectOfType<STEnemySpawner>().enabled = false;
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
        gameObjectChooseAnswer.SetActive(false);
    }

    public ListArrayAnswer[] GetListArrayAnswer()
    {
        ListArrayAnswer[] listArrayAnswers = new ListArrayAnswer[6];
        // lừa đảo qua trang website
        ArrayAnswer[] arrayAnswer1 = {
        new ArrayAnswer("Trang web không có nhiều thông tin ",true),
        new ArrayAnswer("Địa chỉ web không có khóa bảo mật",true),
        new ArrayAnswer("Trang web yêu cầu thông tin cá nhân quá mức",true),
        new ArrayAnswer("Thông báo giật gân và cảnh báo đột ngột",true),
        new ArrayAnswer("Kiểm tra tên miền",true),
        new ArrayAnswer("Kiểm tra URL trang web",true),
        new ArrayAnswer("Kiểm tra thông tin doanh nghiệp",true),
        new ArrayAnswer("Nhận biết trang web lừa đảo qua các thông báo trên web",true),
        new ArrayAnswer("Trang web không có địa chỉ liên hệ hoặc thông tin về công ty.",true),
        new ArrayAnswer("Giao diện và thiết kế đáng ngờ",true),
        new ArrayAnswer("Thời gian tải trang chậm",false),
        new ArrayAnswer("Sử dụng ngôn ngữ khó hiểu",false),
        new ArrayAnswer("Dựa vào thiết kế trang web",false),
        new ArrayAnswer("Phụ thuộc vào mức độ quảng cáo",false),
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
