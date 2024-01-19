using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    [SerializeField]
    private int _damageAmount;

    public int _currentHealth;

    public int _maximumHealth = 100;
    public STHealthBarUI healthBar;

    void Start()
    {
        _currentHealth = _maximumHealth;
        healthBar.SetMaxHealth(_maximumHealth);
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        healthBar.SetHealth(_currentHealth);

    }
}
