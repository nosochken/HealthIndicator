using System.Collections;
using UnityEngine;

public class MainHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    [SerializeField] private TextHealthIndicator _textHealthIndicator;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private SmoothHealthBar _smoothHealthBar;

    private void OnEnable()
    {
        _health.Increased += () => StartCoroutine(DisplayHealing());
        _health.Decreased += DisplayDamage;
    }

    private void Start()
    {
        _textHealthIndicator.Display(_health);
        _healthBar.DisplayOnStartup(_health);
        _smoothHealthBar.DisplayOnStartup(_health);
    }

    private void OnDisable()
    {
        _health.Increased -= () => StartCoroutine(DisplayHealing());
        _health.Decreased -= DisplayDamage;
    }

    private IEnumerator DisplayHealing()
    {
        _textHealthIndicator.Display(_health);
        yield return StartCoroutine(_smoothHealthBar.DisplaySmoothly(_health));
        _healthBar.Display(_health);

    }
    private void DisplayDamage()
    {
        _textHealthIndicator.Display(_health);
        _healthBar.Display(_health);
        StartCoroutine(_smoothHealthBar.DisplaySmoothly(_health));
    }
}