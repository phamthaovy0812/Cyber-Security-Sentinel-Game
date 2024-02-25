using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Extensions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTalking : MonoBehaviour
{
    public GameObject npc1;
    public GameObject npc2;
    public GameObject npc;
    public GameObject player1;
    public GameObject endRoom;
    public int id_Room;
    public int countCorrect;
    public TextMeshProUGUI endTextMesh;


    void Start()
    {
        countCorrect = 0;
    }

    public void Repply1()
    {
        npc1.SetActive(true);
        npc.SetActive(false);
    }
    public void Repply2()
    {
        npc1.SetActive(false);
        player1.SetActive(true);
    }
    public void Repply3()
    {
        player1.SetActive(false);
        npc2.SetActive(true);
    }
    public void gotoHome()
    {
        npc2.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomePage");
    }
    public void Btn_Again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Btn_Exit()
    {
        SceneManager.LoadScene("HomePage");
    }
    public void OpenEndRoom()
    {
        endRoom.SetActive(true);
        Debug.Log("Count Correct: " + countCorrect);
        LevelData levelData = APIUser.Instance.GetLevelData(4);
        int star = levelData.levelItemsArray[id_Room].starAchieved;

        if (id_Room < 5)
        {
            if (countCorrect < 3)
            {
                endTextMesh.text = " Bạn cần giải đáp đúng ít nhất 3/5 nội dung thắc mắc của người dân để được nhận điểm kinh nghiệm.";

            }
            else
            {
                if (star == 0)
                {
                    endTextMesh.text = "Chúc mừng bạn đã giải đáp thắc mắc của người dân " + countCorrect + "/5 câu hỏi. Bạn được cộng thêm " + (200 * countCorrect) + " kinh nghiệm.";
                    APIUser.Instance.UpdateExperiences(200 * countCorrect);
                    if (countCorrect == 3)
                    {
                        levelData.levelItemsArray[id_Room].starAchieved = 1;
                    }
                    else if (countCorrect == 4)
                    {
                        levelData.levelItemsArray[id_Room].starAchieved = 2;
                    }
                    else levelData.levelItemsArray[id_Room].starAchieved = 3;
                }
                else if (star == 1)
                {
                    if (countCorrect > 3)
                    {
                        endTextMesh.text = "Chúc mừng bạn đã giải đáp thắc mắc cho người dân tại căn phòng này tốt hơn lần trước bạn thực hiện nhiệm vụ ở đây. Bạn được cộng thêm " + (200 * (countCorrect - 3)) + " kinh nghiệm.";
                        APIUser.Instance.UpdateExperiences(200 * (countCorrect - 3));

                    }
                    else
                    {
                        endTextMesh.text = "Bạn đã giải đáp thắc mắc cho người dân tại phòng này ít hơn so với lần thực hiện giải đáp tại phòng này gần nhất. Bạn sẽ không được cộng thêm điểm kinh nghiệm. Hãy luyện tập thêm và quay lại thực hiện nhiệm vụ tốt hơn nhé";
                    }
                    if (countCorrect == 4)
                    {
                        levelData.levelItemsArray[id_Room].starAchieved = 2;
                    }
                    else if (countCorrect == 5)
                    {
                        levelData.levelItemsArray[id_Room].starAchieved = 3;
                    }
                }
                else if (star == 2)
                {
                    if (countCorrect > 4)
                    {
                        endTextMesh.text = "Chúc mừng bạn đã giải đáp thắc mắc cho người dân tại căn phòng này tốt hơn lần trước bạn thực hiện nhiệm vụ ở đây. Bạn được cộng thêm " + (200 * (countCorrect - 4)) + " kinh nghiệm.";
                        APIUser.Instance.UpdateExperiences(200 * (countCorrect - 4));

                        levelData.levelItemsArray[id_Room].starAchieved = 3;
                    }
                    else
                    {
                        endTextMesh.text = " Bạn đã giải đáp thắc mắc cho người dân tại phòng này ít hơn so với lần thực hiện giải đáp tại phòng này gần nhất. Bạn sẽ không được cộng thêm điểm kinh nghiệm. Hãy luyện tập thêm và quay lại thực hiện nhiệm vụ tốt hơn nhé";
                    }
                }
                else
                {
                    if (countCorrect < 5)
                    {
                        endTextMesh.text = " Bạn đã giải đáp thắc mắc cho người dân tại phòng này ít hơn so với lần thực hiện giải đáp tại phòng này gần nhất. Bạn sẽ không được cộng thêm điểm kinh nghiệm. Hãy luyện tập thêm và quay lại thực hiện nhiệm vụ tốt hơn nhé";
                    }
                    else
                    {
                        endTextMesh.text = " Chúc mừng bạn đã hoàn thành xuất sắc giải đáp 5/5 câu hỏi thắc mắc của người dân tại phòng này. Hãy quay về trang chủ để thực hiện các nhiệm vụ khác nhé.";
                    }

                }
            }
        }
        else
        {
            if (star == 0)
            {
                if (countCorrect == 1)
                {
                    endTextMesh.text = "Chúc mừng bạn đã trả lời đúng câu hỏi phụ này. Bạn được cộng 200 điểm kinh nghiệm. Hãy quay lại trang chủ để nhận thêm nhiệm vụ mới nhé";
                    APIUser.Instance.UpdateExperiences(200);
                    levelData.levelItemsArray[id_Room].starAchieved = 3;
                }
                else
                {
                    endTextMesh.text = "Rất tiếc bạn đã không trả lời đúng câu hỏi phụ này. Hãy quay lại trang chủ để nhận thực hiện nhiệm vụ khác nhé ";
                }
                levelData.levelItemsArray[id_Room].unlocked = true;
            }

        }
        APIUser.Instance.SetLevelDataDegree4(levelData);
        string levelDataString = JsonUtility.ToJson(levelData);

        // update firebase
        try
        {
            //save the string as json 
            DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
            // string json = JsonUtility.ToJson(degree);
            reference.Child("ScoreDegree").Child(APIUser.Instance.GetUser().id_user).Child(APIUser.Instance.GetUser().id_level.ToString()).SetRawJsonValueAsync(levelDataString);

        }
        catch (System.Exception e)
        {
            //if we get any error debug it
            Debug.Log("Error Saving Data:" + e);
            throw;
        }
    }


}