using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : HealthIndicator
{
    private Slider _slider;

    protected virtual void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    protected override void DisplayOnStartup(Health health)
    {
        _slider.maxValue = health.MaxValue;
        _slider.value = health.CurrentValue;
    }

    protected override void Display(Health health)
    {
        DisplaySliderOf(health, _slider);
    }

    protected virtual void DisplaySliderOf(Health health, Slider slider)
    {
        slider.value = health.CurrentValue;
    }
}