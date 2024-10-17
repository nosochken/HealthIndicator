using UnityEngine;

public abstract class HealthIndicator : MonoBehaviour
{
    [SerializeField] private Health _health;
	
	private void OnEnable()
	{
		_health.Changed += () => Display(_health);
	}
	
	private void Start()
	{	
		DisplayOnStartup(_health);
	}
	
	private void OnDisable()
	{
		_health.Changed -= () => Display(_health);
	}
	
	protected abstract void DisplayOnStartup(Health health);
	
	protected abstract void Display(Health health);
}