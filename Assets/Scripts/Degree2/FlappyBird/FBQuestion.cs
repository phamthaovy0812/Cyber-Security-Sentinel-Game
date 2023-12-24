using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FBQuestion : MonoBehaviour
{
    //     private string[] question = {
    //         "1.Mật khẩu mạnh bao gồm những yếu tố nào?",
    //         "2.Thủ thuật nào được đề xuất để tạo một mật khẩu mạnh?",
    //         "3.Phương pháp 'mật khẩu theo vần điệu' dựa trên gì?",
    //         "4.Sử dụng mật khẩu lấy từ một câu trong bài hát hoặc tên bộ phim bạn yêu thích có gì đặc biệt?",
    //         "5.Một phương pháp tạo mật khẩu mạnh là sử dụng các thuật ngữ chuyên môn trong ngành nghề của bạn. Điều này đảm bảo gì?",
    //         "6.Tại sao nên tránh sử dụng ngày sinh nhật làm mật khẩu?",
    //         "7.Phương pháp tạo mật khẩu bằng sơ đồ bàn phím dựa trên gì?",
    //         "8.Tại sao việc chia mật khẩu thành nhiều phần có lợi ích?",
    //         "9.Định nghĩa của 2FA là gì?",
    //         "10.Ưu điểm của 2FA bao gồm gì?",
    //     };
    //     private string[,] answer = {
    //         {"A) Chữ hoa và chữ thường","B) Số và ký hiệu đặc biệt","C) Ít nhất 12 ký tự","D) Tất cả các phương án trên"},
    //         {"A) Sử dụng ngày sinh nhật","B) Lựa chọn mật khẩu có ít ký tự","C) Kết hợp chữ hoa và chữ thường","D) Sử dụng mật khẩu thô sơ"},
    //         {"A) Câu thơ hoặc câu văn ưa thích","B) Ngày đặc biệt của bạn","C) Sơ đồ bàn phím","D) Mật khẩu thô sơ và chia thành nhiều phần"},
    //         {"A) Nó là mật khẩu dễ nhớ","B) Nó dựa trên ngày sinh nhật","C) Nó là mật khẩu mạnh","D) Nó không an toàn"},
    //         {"A) Mật khẩu dễ nhớ","B) Mật khẩu an toàn","C) Mật khẩu dựa trên ngày sinh nhật","D) Mật khẩu ngắn"},
    //         {"A) Vì nó là mật khẩu dễ nhớ","B) Vì người khác có thể biết ngày sinh nhật của bạn","C) Vì nó là mật khẩu mạnh","D) Vì nó tạo ra mật khẩu theo vần điệu"},
    //         {"A) Sử dụng ngày tháng ghi sự kiện đặc biệt với bạn","B) Sử dụng mật khẩu thô sơ và chia thành nhiều phần","C) Sử dụng mật khẩu lấy từ bộ phim yêu thích","D) Dựa vào mô hình bàn phím"},
    //         {"A) Giúp mật khẩu dễ dàng đoán biết","B) Tạo mật khẩu ngắn","C) Giúp bảo vệ mật khẩu khi một phần bị tiết lộ","D) Không có lợi ích gì"},
    //         {"A) Mật khẩu bảo mật hai lớp","B) Mật khẩu mạnh","C) Mật khẩu dễ nhớ","D) Mật khẩu ngắn"},
    //         {"A) Tăng cường bảo mật","B) Tạo mật khẩu mạnh","C) Tích hợp dễ dàng","D) Mất thời gian trong quá trình đăng nhập"},
    //     };
    //     private string[] rightAns = {
    //         "D",
    //         "C",
    //         "A",
    //         "A",
    //         "B",
    //         "B",
    //         "D",
    //         "C",
    //         "A",
    //         "A",
    //     };
    //     [SerializeField] public Button ansA;
    //     [SerializeField] public Button ansB;
    //     [SerializeField] public Button ansC;
    //     [SerializeField] public Button ansD;
    //     [SerializeField] public TMP_Text ques;

    //     [SerializeField] public GameObject UIques;
    //     [SerializeField] public GameObject UIres;
    //     private int check = 10;
    public void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            //     if (check > 0)
            //     {
            //         UIques.SetActive(true);

            //         ques.text = question[check - 1];
            //         ansA.GetComponentInChildren<Text>().text = answer[check - 1, 0];
            //         ansB.GetComponentInChildren<Text>().text = answer[check - 1, 1];
            //         ansC.GetComponentInChildren<Text>().text = answer[check - 1, 2];
            //         ansD.GetComponentInChildren<Text>().text = answer[check - 1, 3];

            //         check--;

            //     }

            //     new WaitForSecondsRealtime(2);
            //     Time.timeScale = 1;
            //     UIques.SetActive(false);

            FBScore.instance.UpdateScore();
            Destroy(gameObject);
            // }
        }
    }
}

