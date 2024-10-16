using System;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] private float _maxValue = 100f;

	private float _minValue = 0f;
	private float _currentValue;
	private bool _isDead;
	
	public event Action Increased;
	public event Action Decreased;
	public event Action Died;

	public float CurrentValue => _currentValue;
	public float MaxValue => _maxValue;
	public bool IsDead => _isDead;
	
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

		TryDie();
		
		Decreased?.Invoke();
	}
	
	public void Increase(float value)
	{
		if (value <= 0)
			return;

		_currentValue += value;

		TryReduceToMaxValue();
		
		Increased?.Invoke();
	}

	private void TryDie()
	{
		if (_currentValue <= _minValue)
		{
			_isDead = true;
			Died?.Invoke();
		}
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