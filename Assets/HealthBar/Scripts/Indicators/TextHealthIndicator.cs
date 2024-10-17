using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextHealthIndicator : HealthIndicator
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    protected override void Display(Health health)
    {
        DisplayOnStartup(health);
    }

    protected override void DisplayOnStartup(Health health)
    {
        _text.text = $"{health.CurrentValue} / {health.MaxValue}";
    }
}