using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.Events;

public class STHealthController : MonoBehaviour
{
    [SerializeField]
    private int _currentHealth;

    [SerializeField]
    private int _maximumHealth;
    public HealthBar healthBar;

    void Start()
    {
        _currentHealth = _maximumHealth;
        healthBar.SetMaxHealth(_maximumHealth);
    }

    public void TakeDamage(int damageAmount)
    {
        if (_currentHealth == _maximumHealth)
        {
            return;
        }
        _currentHealth -= damageAmount;
        healthBar.SetHealth(_currentHealth);
    }

}
