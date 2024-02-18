using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;
using System;
using Firebase.Database;



public class CreateDatabase : MonoBehaviour
{

    ListenerRegistration listenerRegistration;
    private string[] nameLevel = { "Cấp tập sự", "Cấp thực tập sinh", "Cấp cảnh sát", "Cấp CS cừ cựu" };




    public void QuestionDataBase(string idTopic, string name_topic)
    {
        // DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        // for (int i = 1; i <= 10; i++)
        // {

        //     Question question = new Question(i.ToString(), "", "", "", "", "", "");
        //     string json = JsonUtility.ToJson(question);
        //     reference.Child("Degree").Child("1").Child("Topics").Child(idTopic).Child("Question").Child(i.ToString()).SetRawJsonValueAsync(json);
        //     reference.Child("Degree").Child("1").Child("Topics").Child(idTopic).Child("id_topic").SetValueAsync(idTopic);
        //     reference.Child("Degree").Child("1").Child("Topics").Child(idTopic).Child("name_topic").SetValueAsync(name_topic);
        //     // questionDatas.Add(question);
        // }
        // string json = JsonUtility.ToJson(questionDatas);
        // reference.Child("Test").Child("1").SetRawJsonValueAsync(json);

    }
    public void TopicData()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        for (int k = 1; k < 5; k++)
        {
            Degree degree = new Degree();
            degree.topics = new Topic[6];
            degree.id = k.ToString();
            degree.nameLevel = nameLevel[k - 1];
            for (int j = 1; j < 7; j++)
            {
                int n = 10;
                Topic topic = new Topic();
                topic.listQuestions = new Question[n];
                topic.id_topic = j.ToString();
                topic.name_topic = "";
                for (int i = 1; i <= 10; i++)
                {
                    // Question question = new Question(i.ToString(), "", "", "", "", "", "");
                    topic.listQuestions[i - 1] = new Question(i.ToString(), "", "", "", "", "", "");
                }
                degree.topics[j - 1] = topic;
            }
            string json = JsonUtility.ToJson(degree);
            reference.Child("Degree").Child(degree.id).SetRawJsonValueAsync(json);


        }


        // string json = JsonUtility.ToJson(questionDatas);
        // reference.Child("Test").Child("1").SetRawJsonValueAsync(json);

    }
    public void GetDataQuestion()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseDatabase.DefaultInstance
  .GetReference("test")
  .GetValueAsync().ContinueWithOnMainThread(task =>
  {
      if (task.IsFaulted)
      {
          Debug.Log("No read data from database");
      }
      else if (task.IsCompleted)
      {
          DataSnapshot snapshot = task.Result;
          string data = JsonUtility.ToJson(snapshot);
          Debug.Log("count data snapshot: " + snapshot.ChildrenCount);
          Debug.Log("data snapshot: " + data);
          if (snapshot.ChildrenCount > 0)
          {
              foreach (DataSnapshot dataSnapshot in snapshot.Children)
              {
                  Topic topic = JsonUtility.FromJson<Topic>(dataSnapshot.GetRawJsonValue());
                  string t = JsonUtility.ToJson(topic);
                  Debug.Log("json: " + t);
              }
          }

          // Do something with snapshot...
      }
  });
    }
    // Start is called before the first frame update
    void Start()
    {
        TopicData();

    }


}
