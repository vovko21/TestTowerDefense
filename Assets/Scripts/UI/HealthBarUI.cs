using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();

        _slider.maxValue = _health.TotalHealth;
        _slider.value = _health.CurrentHealth;
    }

    private void OnEnable()
    {
        _health.OnHealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.OnHealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int valueChanged)
    {
        _slider.value = _health.CurrentHealth;
    }
}