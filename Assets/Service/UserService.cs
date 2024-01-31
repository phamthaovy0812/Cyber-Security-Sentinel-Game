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
			DontDestroyOnLoad(gameObject);                                                          // DontDestroyOnLoad(gameObject);                                  //make it DontDestroyOnLoad
		}
		else
		{
			Destroy(gameObject);                                            //else destroy it
		}
	}
	public User GetUser() { return _user; }

	public LevelData GetLevelData()
	{
		return levelData;
	}
	public void UpdatedLevelData(LevelData levelData)
	{

	}
	public void SetLevelData(LevelData levelData)
	{
		this.levelData = levelData;
	}
	public void getConnectedUserByUId(string email)
	{
		Debug.Log("getConnectedUserByUId");
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
				Debug.Log("Email input: " + email);
				if (snapshot.ChildrenCount > 0)
				{

					foreach (DataSnapshot dataSnapshot in snapshot.Children)
					{
						Debug.Log("Email dataSnapshot: " + dataSnapshot.GetRawJsonValue());

						if (dataSnapshot.Child("email").GetValue(true).ToString().Equals(email))
						{
							Debug.Log("Email: " + dataSnapshot.Child("email").GetValue(true).ToString());
							// _user = JsonUtility.FromJson<User>(dataSnapshot.GetRawJsonValue());
							// Debug.Log("dataSnapshot: " + dataSnapshot.GetRawJsonValue());
							_user.id_user = dataSnapshot.Child("id_user").GetValue(true).ToString();
							_user.id_level = Int32.Parse(dataSnapshot.Child("id_level").GetValue(true).ToString());
							_user.username = dataSnapshot.Child("username").GetValue(true).ToString();
							_user.password = dataSnapshot.Child("password").GetValue(true).ToString();
							_user.email = dataSnapshot.Child("email").GetValue(true).ToString();
							_user.experience = Int32.Parse(dataSnapshot.Child("experience").GetValue(true).ToString());
							_user.isOpenStartGame = bool.Parse(dataSnapshot.Child("isOpenStartGame").GetValue(true).ToString());
							_user.isOpenDegree1 = bool.Parse(dataSnapshot.Child("isOpenDegree1").GetValue(true).ToString());
							_user.isOpenDegree2 = bool.Parse(dataSnapshot.Child("isOpenDegree2").GetValue(true).ToString());
							_user.isOpenDegree3 = bool.Parse(dataSnapshot.Child("isOpenDegree3").GetValue(true).ToString());
							_user.isOpenDegree4 = bool.Parse(dataSnapshot.Child("isOpenDegree4").GetValue(true).ToString());
							Debug.Log("findUser: " + _user.id_level);

							break;
							// return true;

						}

					}
					GetDataDegreeOfUser();

				}


			}
		});


	}
	//instance getter
	public void UpdateExperiences(int experience)
	{
		Debug.Log("experiences user: " + _user.experience);
		FirebaseDatabase database = FirebaseDatabase.DefaultInstance;
		DatabaseReference reference = database.GetReference("Users");
		_user.experience += experience;
		reference.Child(_user.id_user).Child("experience").SetValueAsync(_user.experience);

		Debug.Log("Updated successfully");
	}
	public void UpdateIdLevel(int id_level)
	{
		FirebaseDatabase database = FirebaseDatabase.DefaultInstance;
		DatabaseReference reference = database.GetReference("Users");
		_user.id_level = id_level;
		reference.Child(_user.id_user).Child("id_level").SetValueAsync(_user.id_level);

		Debug.Log("Updated id_level successfully");
	}
	public void UpdateIsOpenDegree1(bool isOpenDegree1)
	{
		FirebaseDatabase database = FirebaseDatabase.DefaultInstance;
		DatabaseReference reference = database.GetReference("Users");
		_user.isOpenDegree1 = isOpenDegree1;
		reference.Child(_user.id_user).Child("isOpenDegree1").SetValueAsync(_user.isOpenDegree1);

		Debug.Log("Updated isOpenDegree1 successfully");
	}
	public void UpdateIsOpenDegree2(bool isOpenDegree2)
	{
		FirebaseDatabase database = FirebaseDatabase.DefaultInstance;
		DatabaseReference reference = database.GetReference("Users");
		_user.isOpenDegree2 = isOpenDegree2;
		reference.Child(_user.id_user).Child("isOpenDegree2").SetValueAsync(_user.isOpenDegree2);

		Debug.Log("Updated isOpenDegree2 successfully");
	}
	public void UpdateIsOpenDegree3(bool isOpenDegree3)
	{
		FirebaseDatabase database = FirebaseDatabase.DefaultInstance;
		DatabaseReference reference = database.GetReference("Users");
		_user.isOpenDegree3 = isOpenDegree3;
		reference.Child(_user.id_user).Child("isOpenDegree3").SetValueAsync(_user.isOpenDegree3);

		Debug.Log("Updated isOpenDegree3 successfully");
	}
	public void UpdateIsOpenDegree4(bool isOpenDegree4)
	{
		FirebaseDatabase database = FirebaseDatabase.DefaultInstance;
		DatabaseReference reference = database.GetReference("Users");
		_user.isOpenDegree4 = isOpenDegree4;
		reference.Child(_user.id_user).Child("isOpenDegree4").SetValueAsync(_user.isOpenDegree4);

		Debug.Log("Updated isOpenDegree4 successfully");
	}
	public void UpdateIsOpenStartGame(bool isOpenStartGame)
	{
		FirebaseDatabase database = FirebaseDatabase.DefaultInstance;
		DatabaseReference reference = database.GetReference("Users");
		_user.isOpenStartGame = isOpenStartGame;
		reference.Child(_user.id_user).Child("isOpenStartGame").SetValueAsync(isOpenStartGame);

		Debug.Log("Updated isOpenStartGame successfully");
	}
	public async void GetDataDegreeOfUser()
	{
		DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
		await FirebaseDatabase.DefaultInstance
 		 .GetReference("ScoreDegree").Child(_user.id_user)
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
						  Debug.Log("Finale");
					  }
				  }

				  // Do something with snapshot...
			  }
		  });
	}

}