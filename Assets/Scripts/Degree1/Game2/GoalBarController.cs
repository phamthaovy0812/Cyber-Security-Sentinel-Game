// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class GoalBarController : MonoBehaviour
// {
// 	public float _currentHealth;

// 	public float _maximumHealth;
// 	public float RemainingHealthPercentage;
// 	public bool IsInvincible { get; set; }
// 	// Start is called before the first frame update
// 	void Start()
// 	{
// 		RemainingHealthPercentage = _currentHealth / _maximumHealth;
// 	}
// 	public void AddGoal(float amountToAdd)
// 	{
// 		if (_currentHealth == _maximumHealth)
// 		{
// 			return;
// 		}

// 		_currentHealth += amountToAdd;

// 		if (_currentHealth > _maximumHealth)
// 		{
// 			_currentHealth = _maximumHealth;
// 		}
// 	}
// }
