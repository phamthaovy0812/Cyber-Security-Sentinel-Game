using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;
using System;
using Unity.VisualScripting.Dependencies.Sqlite;




[FirestoreData]

public struct Degree
{

    [FirestoreProperty]
    public string id { get; set; }
    [FirestoreProperty]
    public string nameLevel { get; set; }
    [FirestoreProperty]
    public string id_topic { get; set; }
}
[FirestoreData]
public struct Question
{
    [FirestoreProperty]
    public int id_question { get; set; }
    [FirestoreProperty]
    public int id_topic { get; set; }
    [FirestoreProperty]
    public string question { get; set;}
    [FirestoreProperty]
    public string answerA { get; set;}
    [FirestoreProperty]
    public string answerB { get; set;}
    [FirestoreProperty]
    public string answerC { get;set;}
    [FirestoreProperty]
    public string answerD { get;set;}
    [FirestoreProperty]
    public string correctAnswer { get; set;}

}

[FirestoreData]
public struct Topic{
    [FirestoreProperty]
    public int id_topic { get; set;}
    [FirestoreProperty]
    public int id_level { get; set;}
    [FirestoreProperty]
    public string name_topic { get; set;}
    
}
public class CreateDatabase : MonoBehaviour
{
    public FirebaseFirestore database;
    ListenerRegistration listenerRegistration;
    private string[] nameLevel = { "Cấp tập sự", "Cấp thực tập sinh", "Cấp cảnh sát", "Cấp CS cừ cựu" };

    // Start is called before the first frame update
    void Start()
    {
        database = FirebaseFirestore.DefaultInstance;
        
        
        for (int i = 1; i <= 6; i++)
        {
            Topic question = new Topic
            {
                
                id_topic = i,
                name_topic = "",
                id_level = 1,

            };
            DocumentReference new_degree = database.Collection("Topics").Document();
            new_degree.SetAsync(question).ContinueWithOnMainThread(task =>
            {
                Debug.Log("Successfully");
            });
        }
    }
    

}
