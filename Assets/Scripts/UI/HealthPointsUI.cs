using TMPro;
using UnityEngine;

public class HealthPointsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private Health _health;

    public void Initialize(Health health)
    {
        _health = health;
        _textMeshPro.text = _health.TotalHealth.ToString();

        _health.OnHealthChanged += OnHealthChanged;
        _health.OnDestroy += Health_OnDestroy;
    }

    private void OnDisable()
    {
        _health.OnHealthChanged -= OnHealthChanged;
        _health.OnDestroy -= Health_OnDestroy;
    }

    private void OnHealthChanged(int valueChanged)
    {
        _textMeshPro.text = _health.CurrentHealth.ToString();
    }

    private void Health_OnDestroy(object sender)
    {
        _textMeshPro.text = "0";
    }
}