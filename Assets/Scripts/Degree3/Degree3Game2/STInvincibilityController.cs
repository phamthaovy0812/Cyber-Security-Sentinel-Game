using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STInvincibilityController : MonoBehaviour
{
    private STHealthController _healthController;

    private void Awake()
    {
        _healthController = GetComponent<STHealthController>();
    }

    public void StartInvincibility(float invincibilityDuration)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration)
    {
        _healthController.IsInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        _healthController.IsInvincible = false;
    }
}
