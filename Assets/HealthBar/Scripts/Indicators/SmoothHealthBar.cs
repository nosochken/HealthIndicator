using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBar : MonoBehaviour
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

    public IEnumerator DisplaySmoothly(Health health)
    {
        float speed = 10f;

        while (_slider.value != health.CurrentValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health.CurrentValue, speed * Time.deltaTime);
            yield return null;
        }
    }
}