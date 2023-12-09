using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;
using System;
using Unity.VisualScripting.Dependencies.Sqlite;
using Firebase.Database;




[FirestoreData]

public class Degree
{

    [FirestoreProperty]
    public int id { get; set; }
    [FirestoreProperty]
    public string nameLevel { get; set; }
    [FirestoreProperty]
    public List<Topic> topics { get; set; }

    public Degree(int id, string name, List<Topic> topics)
    {
        this.id = id;
        this.nameLevel = name;
        this.topics = topics;
    }
}
[FirestoreData]
public class Question
{
    [FirestoreProperty]
    public int id_question { get; set; }
    [FirestoreProperty]
    public string question { get; set; }
    [FirestoreProperty]
    public string answerA { get; set; }
    [FirestoreProperty]
    public string answerB { get; set; }
    [FirestoreProperty]
    public string answerC { get; set; }
    [FirestoreProperty]
    public string answerD { get; set; }
    [FirestoreProperty]
    public string correctAnswer { get; set; }

    public Question(int id, string question, string answerA, string answerB, string answerC, string answerD, string correctAnswer)
    {

        this.id_question = id;
        this.question = question;
        this.answerA = answerA;
        this.answerB = answerB;
        this.answerC = answerC;
        this.answerD = answerD;
        this.correctAnswer = correctAnswer;

    }

}

[FirestoreData]
public class Topic
{
    [FirestoreProperty]
    public int id_topic { get; set; }
    [FirestoreProperty]
    public List<Question> questions { get; set; }
    [FirestoreProperty]
    public string name_topic { get; set; }

    public Topic(int id, string name, List<Question> questions)
    {
        this.id_topic = id;
        this.name_topic = name;
        this.questions = questions;
    }
}


public class CreateDatabase : MonoBehaviour
{
    public FirebaseFirestore database;
    ListenerRegistration listenerRegistration;
    private string[] nameLevel = { "Cấp tập sự", "Cấp thực tập sinh", "Cấp cảnh sát", "Cấp CS cừ cựu" };

    public class User1
    {
        public string username;
        public string email;

        public User1()
        {
        }

        public User1(string username, string email)
        {
            this.username = username;
            this.email = email;
        }
    }
    public void writeNewUser(string userId, string name, string email)
    {
        DatabaseReference mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        User1 user = new User1(name, email);
        string json = JsonUtility.ToJson(user);

        mDatabaseRef.Child("Test").Child(userId).SetRawJsonValueAsync(json);
    }
    // Start is called before the first frame update
    void Start()
    {
        writeNewUser("1", "test", "email");
        // database = FirebaseFirestore.DefaultInstance;

        // List<Question> questionDatas = new List<Question>();

        // for (int i = 0; i < 10; i++)
        // {
        //     Question question = new Question(i + 1, "", "", "", "", "", "");
        //     questionDatas.Add(question);
        // }
        // List<Topic> listTopic = new List<Topic>();

        // for (int i = 0; i < 10; i++)
        // {
        //     Topic topic = new Topic(i + 1, "", questionDatas);
        //     listTopic.Add(topic);
        // }
        // for (int i = 1; i <= 4; i++)
        // {
        //     Degree degree = new Degree(i, nameLevel[i - 1], listTopic);

        //     // DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        //     // new_degree.SetAsync(degree).ContinueWithOnMainThread(task =>
        //     // {
        //     //     Debug.Log("Successfully");
        //     // });
        // }
        // string json = JsonUtility.ToJson(questionDatas);
        // try
        // {
        //     //save the string as json 
        //     System.IO.File.WriteAllText(Application.persistentDataPath + "/test.json", json);
        //     Debug.Log("Data Saved");

        // }
        // catch (System.Exception e)
        // {
        //     //if we get any error debug it
        //     Debug.Log("Error Saving Data:" + e);
        //     throw;
        // }
        // DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        // reference.Child("Test").Child("1").SetRawJsonValueAsync(json);

    }


}
