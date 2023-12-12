using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class GetQuestion : MonoBehaviour
{
	[SerializeField] private static GetQuestion instance;
	public static GetQuestion Instance { get => instance; }
	List<Topic> listTopics = new List<Topic>();
	private Topic topic1;


	public Topic getTopic()
	{
		return this.topic1;
	}
	public async void GetQuestionTopic1()
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
				  Debug.Log("count data snapshot: " + snapshot.ChildrenCount);
				  Debug.Log("data snapshot: " + data);
				  if (snapshot.ChildrenCount > 0)
				  {
					  foreach (DataSnapshot dataSnapshot in snapshot.Children)
					  {
						  Topic topic = JsonUtility.FromJson<Topic>(dataSnapshot.GetRawJsonValue());
						  listTopics.Add(topic);

					  }
					  Debug.Log("count listTopics: " + listTopics.Count);
					  topic1.id_topic = listTopics[0].id_topic;
					  topic1.name_topic = listTopics[0].name_topic;
					  topic1.listQuestions = listTopics[0].listQuestions;


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
			DontDestroyOnLoad(gameObject);                                  //make it DontDestroyOnLoad
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
