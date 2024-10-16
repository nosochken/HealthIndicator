using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
	private Slider _slider;
	
	private void Awake()
	{
		_slider = GetComponent<Slider>();
	}
	
	public void DisplayOnStartup(Health health)
	{
		_slider.maxValue = health.MaxValue;
		_slider.value = health.CurrentValue;
	}
	
	public void Display(Health health)
	{
		_slider.value = health.CurrentValue;
	}
}