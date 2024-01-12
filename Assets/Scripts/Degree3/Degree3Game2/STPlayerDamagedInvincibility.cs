
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STPlayerDamagedInvincibility : MonoBehaviour
{
    [SerializeField]
    private float _invincibilityDuration;

    private STInvincibilityController _invincibilityController;

    private void Awake()
    {
        _invincibilityController = GetComponent<STInvincibilityController>();
    }

    public void StartInvincibility()
    {
        _invincibilityController.StartInvincibility(_invincibilityDuration);
    }
}