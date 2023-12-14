using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Extensions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class APIUser : MonoBehaviour
{
	private static APIUser instance;                             //instance variable
	public static APIUser Instance { get => instance; }

	private User _user;
	public DataSnapshot snapshot;
	private LevelData levelData;

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
	public User GetUser() { return _user; }

	public LevelData GetLevelData()
	{
		GetDataDegreeOfUser();
		return levelData;
	}
	public void getConnectedUserByUId(string email)
	{

		_user = new User();
		// DatabaseReference databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
		FirebaseDatabase database = FirebaseDatabase.DefaultInstance;
		DatabaseReference reference = database.GetReference("Users");

		Task<DataSnapshot> task = reference.GetValueAsync();
		task.ContinueWith((Task<DataSnapshot> t) =>
		{
			if (t.IsFaulted)
			{
				// Xử lý lỗi
				Debug.Log("error read desk data");
			}
			else if (t.IsCompleted)
			{
				DataSnapshot snapshot = t.Result;
				// Xử lý dữ liệu snapshot

				if (snapshot.ChildrenCount > 0)
				{

					foreach (DataSnapshot dataSnapshot in snapshot.Children)
					{

						if (dataSnapshot.Child("email").GetValue(true).ToString().Equals(email))
						{
							_user.id_user = dataSnapshot.Child("id_user").GetValue(true).ToString();
							_user.id_level = dataSnapshot.Child("id_level").GetValue(true).ToString();
							_user.username = dataSnapshot.Child("username").GetValue(true).ToString();
							_user.password = dataSnapshot.Child("password").GetValue(true).ToString();
							_user.email = dataSnapshot.Child("email").GetValue(true).ToString();
							_user.experience = Int32.Parse(dataSnapshot.Child("experience").GetValue(true).ToString());

							Debug.Log("findUser: " + _user.username);

							break;
							// return true;

						}

					}

				}


			}
		});

	}
	//instance getter
	public void UpdateExperiences(int experience)
	{
		FirebaseDatabase database = FirebaseDatabase.DefaultInstance;
		DatabaseReference reference = database.GetReference("Users");
		_user.experience += experience;
		reference.Child(_user.id_user).Child("experiences").SetValueAsync(_user.experience);

		Debug.Log("Updated successfully");
	}
	public async void GetDataDegreeOfUser()
	{
		DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
		await FirebaseDatabase.DefaultInstance
 		 .GetReference("ScoreDegree").Child(APIUser.Instance.GetUser().id_user)
		  .GetValueAsync().ContinueWithOnMainThread(task =>
  		{
			  if (task.IsFaulted)
			  {
				  Debug.Log("No read data from database");
			  }
			  else if (task.IsCompleted)
			  {
				  DataSnapshot snapshot = task.Result;
				  if (snapshot.ChildrenCount > 0)
				  {
					  foreach (DataSnapshot dataSnapshot in snapshot.Children)
					  {
						  levelData = JsonUtility.FromJson<LevelData>(dataSnapshot.GetRawJsonValue());


					  }
				  }

				  // Do something with snapshot...
			  }
		  });
	}

}