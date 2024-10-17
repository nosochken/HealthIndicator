using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue = 100f;

    private float _minValue = 0f;
    private float _currentValue;

    public event Action Changed;

    public float CurrentValue => _currentValue;
    public float MaxValue => _maxValue;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    public void Decrease(float value)
    {
        if (value <= 0)
            return;

        _currentValue -= value;

        TryIncreaseToMinimumValue();

        Changed?.Invoke();
    }

    public void Increase(float value)
    {
        if (value <= 0)
            return;

        _currentValue += value;

        TryReduceToMaxValue();

        Changed?.Invoke();
    }

    private void TryIncreaseToMinimumValue()
    {
        if (_currentValue < _minValue)
            _currentValue = _minValue;
    }

    private void TryReduceToMaxValue()
    {
        if (_currentValue > _maxValue)
            _currentValue = _maxValue;
    }
}