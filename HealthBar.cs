using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Coroutine _smoothChangeofHealth;
    private Slider _currentHealth;
    private float _targetHealth;
    private bool _smoothChangeIsOn = false;

    private void Start()
    {
        _currentHealth = GetComponent<Slider>();
        _targetHealth = _currentHealth.value;
    }

    public void HealthChange(float deltaHealth)
    {
        if (_targetHealth + deltaHealth >= 0 && _targetHealth + deltaHealth <= 100)
        {
            _targetHealth += +deltaHealth;
            if (_smoothChangeIsOn)
            {
                StopCoroutine(_smoothChangeofHealth);
            }
            _smoothChangeIsOn = true;
            _smoothChangeofHealth = StartCoroutine(SmoothChangeHealth(deltaHealth));
        }
    }

    private IEnumerator SmoothChangeHealth(float deltaHealth)
    {
        float timeout = 0.1F;        
        float normalizedSpeedChange = Mathf.Abs(1- (_currentHealth.value/_targetHealth));
        var waitForSecond = new WaitForSeconds(timeout);

        while (_smoothChangeIsOn)
        {
            _currentHealth.value += deltaHealth * normalizedSpeedChange;
            if ((deltaHealth > 0 && _currentHealth.value >= _targetHealth) ||
                (deltaHealth < 0 && _currentHealth.value <= _targetHealth))
            {
                _currentHealth.value = _targetHealth;
                _smoothChangeIsOn = false;
            }
            yield return waitForSecond;
        }
    }
}
