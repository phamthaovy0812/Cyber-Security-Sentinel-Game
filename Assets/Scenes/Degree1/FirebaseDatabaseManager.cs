using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class question
{
    public string id_question { get; set; }
    public string name { get; set; }
    public string answerA { get; set; }
    public string answerB { get; set; }
    public string answerC { get; set; }
    public string answerD { get; set; }
    public string correctAnswer { get; set; }

    public question(string id_question, string name, string answerA, string answerB, string answerC, string answerD, string correctAnswer)
    {
        this.id_question = id_question;
        this.name = name;
        this.answerA = answerA;
        this.answerB = answerB;
        this.answerC = answerC;
        this.answerD = answerD;
        this.correctAnswer = correctAnswer;
    }

}
public class topic
{
    public string id_topic { get; set; }
    public string nameTopic { get; set; }
    public List<question> list_question { get; set; }

    public topic(string id_topic, string nameTopic, List<question> list_question)
    {
        this.id_topic = id_topic;
        this.nameTopic = nameTopic;
        this.list_question = list_question;

    }

}
public class degree
{
    public string name_degree { get; set; }
    public string id { get; set; }
    public List<topic> list_topic { get; set; }
    public degree(string id, string name_degree, List<topic> list_topic)
    {
        this.name_degree = name_degree;
        this.id = id;
        this.list_topic = list_topic;
    }
}

public class FirebaseDatabaseManager : MonoBehaviour
{
    string degreeId;
    string topicId;
    string questionId;
    public TextMeshProUGUI test;

    DatabaseReference reference;

    void Start()
    {
        // degreeId = "4";
        // topicId = SystemInfo.deviceUniqueIdentifier;
        // questionId = SystemInfo.deviceUniqueIdentifier;
        // List<question> list_questions = new List<question>();
        // for (int i = 0; i < 4; i++)
        // {
        //     question qs = new question(questionId, "cau hoi " + i + 1, "dap an A", "dap an B", "dap an C", "dap an D", "a");

        //     list_questions.Add(qs);
        // }
        // List<topic> list_topic = new List<topic>();
        // for (int i = 0; i < 4; i++)
        // {
        //     topic tp = new topic(topicId, "topic " + i + 1, list_questions);

        //     list_topic.Add(tp);
        // }

        // degree degree = new degree(degreeId, "Cap tap su", list_topic);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        ReadDatabase();
        // CreateNewUser(degree);
        
    }

    public void ReadDatabase()
    {
        
        reference.Child("Degree")
                 .Child("1")
                 .Child("Topics")
                 .GetValueAsync().ContinueWithOnMainThread(task => {
                    if (task.IsFaulted)
                        {
                             Debug.Log(task.Exception.Message);
                        }
                        else if (task.IsCompleted)
                        {
                            DataSnapshot snapshot = task.Result;
                            
                            Debug.Log("object" + snapshot.Value);
                        }
                   });
    }
    public void CreateNewUser(degree degree)
    {

        reference.Child("Degree")
            .Child(degreeId)
            .Child("id_degree")
            .SetValueAsync(degree.id);

        reference.Child("Degree")
            .Child(degreeId)
            .Child("name_degree")
            .SetValueAsync(degree.name_degree);
        for (int i = 0; i < degree.list_topic.Count; i++)
        {
            reference.Child("Degree")
            .Child(degreeId)
            .Child("Topics")
            .Child(degree.list_topic[i].id_topic)
            .Child("id_topic")
            .SetValueAsync(degree.list_topic[i].id_topic);

            reference.Child("Degree")
            .Child(degreeId)
            .Child("Topics")
            .Child(degree.list_topic[i].id_topic)
            .Child("name_topic")
            .SetValueAsync(degree.list_topic[i].nameTopic);
            for (int j = 0; j < degree.list_topic[i].list_question.Count; j++)
            {
                reference.Child("Degree")
                        .Child(degreeId)
                        .Child("Topics")
                        .Child(degree.list_topic[i].id_topic)
                        .Child("Questions")
                        .Child(degree.list_topic[i].list_question[j].id_question)
                        .Child("id_question")
                        .SetValueAsync(degree.list_topic[i].list_question[j].id_question);
                reference.Child("Degree")
                        .Child(degreeId)
                        .Child("Topics")
                        .Child(degree.list_topic[i].id_topic)
                        .Child("Questions")
                        .Child(degree.list_topic[i].list_question[j].id_question)

                        .Child("Question")
                        .SetValueAsync(degree.list_topic[i].list_question[j].name);
                reference.Child("Degree")
                        .Child(degreeId)
                        .Child("Topics")
                        .Child(degree.list_topic[i].id_topic)
                        .Child("Questions")
                        .Child(degree.list_topic[i].list_question[j].id_question)

                        .Child("answerA")
                        .SetValueAsync(degree.list_topic[i].list_question[j].answerA);
                reference.Child("Degree")
                        .Child(degreeId)
                        .Child("Topics")
                        .Child(degree.list_topic[i].id_topic)
                        .Child("Questions")
                        .Child(degree.list_topic[i].list_question[j].id_question)

                        .Child("answerA")
                        .SetValueAsync(degree.list_topic[i].list_question[j].answerA);
                reference.Child("Degree")
                        .Child(degreeId)
                        .Child("Topics")
                        .Child(degree.list_topic[i].id_topic)
                        .Child("Questions")
                        .Child(degree.list_topic[i].list_question[j].id_question)

                        .Child("answerB")
                        .SetValueAsync(degree.list_topic[i].list_question[j].answerB);
                reference.Child("Degree")
                        .Child(degreeId)
                        .Child("Topics")
                        .Child(degree.list_topic[i].id_topic)
                        .Child("Questions")
                        .Child(degree.list_topic[i].list_question[j].id_question)

                        .Child("answerC")
                        .SetValueAsync(degree.list_topic[i].list_question[j].answerC);
                reference.Child("Degree")
                        .Child(degreeId)
                        .Child("Topics")
                        .Child(degree.list_topic[i].id_topic)
                        .Child("Questions")
                        .Child(degree.list_topic[i].list_question[j].id_question)

                        .Child("answerD")
                        .SetValueAsync(degree.list_topic[i].list_question[j].answerD);
                reference.Child("Degree")
                        .Child(degreeId)
                        .Child("Topics")
                        .Child(degree.list_topic[i].id_topic)
                        .Child("Questions")
                        .Child(degree.list_topic[i].list_question[j].id_question)

                        .Child("correctAnswer")
                        .SetValueAsync(degree.list_topic[i].list_question[j].correctAnswer);
            }
        }
        // reference.Child("Degree")
        //     .Child(degreeId)
        //     .Child(topicId)
        //     .SetValueAsync(degree.list_topic);

        // reference.Child("users")
        //     .Child(userId)
        //     .Child("score")
        //     .SetValueAsync(100);

        Debug.Log("New User Created");
    }
}