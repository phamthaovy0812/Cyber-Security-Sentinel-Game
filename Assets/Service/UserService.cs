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
	public User GetUser() { return _user; }
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


		// databaseReference.Child("Users").GetValueAsync().ContinueWithOnMainThread((task) =>
		// {
		// 	if (task.IsFaulted)
		// 	{
		// 		Debug.Log("error read desk data");

		// 	}
		// 	else if (task.IsCompleted)
		// 	{
		// 		snapshot = task.Result;
		// 		Debug.Log("Count user: " + snapshot.ChildrenCount);
		// 	}

		// });


	}
	//instance getter

}