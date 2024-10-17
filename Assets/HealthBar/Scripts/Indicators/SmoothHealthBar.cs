using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBar : HealthBar
{
    protected override void DisplaySliderOf(Health health, Slider slider)
    {
        StartCoroutine(ChangeSmoothly(health, slider));
    }

    private IEnumerator ChangeSmoothly(Health health, Slider slider)
    {
        float speed = 10f;

        while (slider.value != health.CurrentValue)
        {
            slider.value = Mathf.MoveTowards(slider.value, health.CurrentValue, speed * Time.deltaTime);
            yield return null;
        }
    }
}