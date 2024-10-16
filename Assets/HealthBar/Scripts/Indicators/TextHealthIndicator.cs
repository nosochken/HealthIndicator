using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextHealthIndicator : MonoBehaviour
{
	private TextMeshProUGUI _text;
	
	private void Awake()
	{
		_text = GetComponent<TextMeshProUGUI>();
	}
	
	public void Display(Health health)
	{
		_text.text = $"{health.CurrentValue} / {health.MaxValue}";
	}
}