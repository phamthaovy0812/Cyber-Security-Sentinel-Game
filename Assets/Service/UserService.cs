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
	private LevelData levelDataDegree1;
	private LevelData levelDataDegree2;
	private LevelData levelDataDegree3;
	private LevelData levelDataDegree4;

	private void Awake()
	{
		if (instance == null)                                               //if instance is null
		{
			instance = this;                                                //set this as instance
																			// DontDestroyOnLoad(gameObject);                                                          // DontDestroyOnLoad(gameObject);                                  //make it DontDestroyOnLoad
		}
		else
		{
			Destroy(gameObject);                                            //else destroy it
		}
	}
	public User GetUser() { return _user; }

	public LevelData GetLevelData(int idGame)
	{
		Debug.Log("idGame API: " + idGame);
		if (idGame == 1)
		{

			return levelDataDegree1;

		}
		else if (idGame == 2) return levelDataDegree2;
		else if (idGame == 3) return levelDataDegree3;
		else if (idGame == 4) return levelDataDegree4;
		else return null;
	}
	public void UpdatedLevelData(LevelData levelData)
	{

	}
	public void SetLevelDataDegree1(LevelData levelData)
	{
		this.levelDataDegree1 = levelData;
	}
	public void SetLevelDataDegree3(LevelData levelData)
	{
		this.levelDataDegree3 = levelData;
	}
	public void SetLevelDataDegree4(LevelData levelData)
	{
		this.levelDataDegree4 = levelData;
	}


	public void getConnectedUserByUId(string email, string password)
	{


		_user = new User();
		DatabaseReference databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
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

						if (dataSnapshot.Child("email").GetValue(true).ToString().Equals(email) && dataSnapshot.Child("password").GetValue(true).ToString().Equals(password))
						{
							Debug.Log("getConnectedUserByUId");

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

							Debug.Log("findUser: " + _user.id_user);
							Debug.Log("findUser user name: " + _user.username);
							GetDataDegreeOfUser();
							FindAnyObjectByType<firebaseController>().isExitUser = true;


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
					  levelDataDegree1 = JsonUtility.FromJson<LevelData>(snapshot.Child("1").GetRawJsonValue());
					  levelDataDegree2 = JsonUtility.FromJson<LevelData>(snapshot.Child("2").GetRawJsonValue());
					  levelDataDegree3 = JsonUtility.FromJson<LevelData>(snapshot.Child("3").GetRawJsonValue());
					  levelDataDegree4 = JsonUtility.FromJson<LevelData>(snapshot.Child("4").GetRawJsonValue());
					  Debug.Log("loadLevel successfully loaded");
				  }

				  // Do something with snapshot...
			  }
		  });
	}

}