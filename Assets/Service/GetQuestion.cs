using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class GetQuestion : MonoBehaviour
{
	[SerializeField] private static GetQuestion instance;
	public static GetQuestion Instance { get => instance; }
	private List<Topic> listTopics = new List<Topic>();
	private List<Question> listQuestion = new List<Question>();
	private Topic topic1;


	public Topic getTopic()
	{
		return this.topic1;
	}
	public List<Question> getListQuestionTopicOfDegree1()
	{
		return this.listQuestion;
	}
	public async void GetQuestionTopic1()
	{
		topic1 = new Topic();
		DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
		await FirebaseDatabase.DefaultInstance
 		 .GetReference("Degree").Child("3").Child("topics")
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
				  if (snapshot.ChildrenCount > 0)
				  {
					  foreach (DataSnapshot dataSnapshot in snapshot.Children)
					  {
						  Topic topic = JsonUtility.FromJson<Topic>(dataSnapshot.GetRawJsonValue());
						  for (int i = 0; i < topic.listQuestions.Length; i++)
						  {
							  listQuestion.Add(topic.listQuestions[i]);

						  }

					  }
					  Debug.Log("count listTopics: " + listQuestion.Count);
					  //   topic1.id_topic = listTopics[0].id_topic;
					  //   topic1.name_topic = listTopics[0].name_topic;
					  //   topic1.listQuestions = listTopics[0].listQuestions;


					  //   Debug.Log("listTopics: " + JsonUtility.ToJson(listTopics..listQuestions));
				  }

				  // Do something with snapshot...
			  }
		  });

		// return listTopics;
	}
	public async void GetQuestionTopic3()
	{
		topic1 = new Topic();
		DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
		await FirebaseDatabase.DefaultInstance
 		 .GetReference("Degree").Child("1").Child("topics")
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
				  if (snapshot.ChildrenCount > 0)
				  {
					  foreach (DataSnapshot dataSnapshot in snapshot.Children)
					  {
						  Topic topic = JsonUtility.FromJson<Topic>(dataSnapshot.GetRawJsonValue());
						  for (int i = 0; i < topic.listQuestions.Length; i++)
						  {
							  listQuestion.Add(topic.listQuestions[i]);

						  }

					  }
					  Debug.Log("count listTopics: " + listQuestion.Count);
					  //   topic1.id_topic = listTopics[0].id_topic;
					  //   topic1.name_topic = listTopics[0].name_topic;
					  //   topic1.listQuestions = listTopics[0].listQuestions;


					  //   Debug.Log("listTopics: " + JsonUtility.ToJson(listTopics..listQuestions));
				  }

				  // Do something with snapshot...
			  }
		  });

		// return listTopics;
	}
	private void Awake()
	{
		if (instance == null)                                               //if instance is null
		{
			instance = this;                                                //set this as instance
																			// DontDestroyOnLoad(gameObject);                                  //make it DontDestroyOnLoad
		}
		else
		{
			Destroy(gameObject);                                            //else destroy it
		}
	}
	public void Start()
	{
		GetQuestionTopic1();

	}
}
