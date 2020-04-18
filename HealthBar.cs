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
        int minHealth = 0;
        int maxHealth = 100;

        _targetHealth = Mathf.Clamp(_targetHealth + deltaHealth, minHealth, maxHealth);
        Debug.Log(_targetHealth);
        if (_smoothChangeIsOn)
        {
            StopCoroutine(_smoothChangeofHealth);
        }
        _smoothChangeIsOn = true;
        _smoothChangeofHealth = StartCoroutine(SmoothChangeHealth(deltaHealth));
    }

    private IEnumerator SmoothChangeHealth(float deltaHealth)
    {
        float timeout = 0.05F;
        float normalizedSpeedChange=0.1F;

        if (_targetHealth != 0)
        {
            normalizedSpeedChange = Mathf.Abs(1 - (_currentHealth.value / _targetHealth));
        }
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
