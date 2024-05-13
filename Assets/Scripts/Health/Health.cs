using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    protected int _totalHealth;
    protected int _currentHealth;

    public int TotalHealth => _totalHealth;
    public int CurrentHealth => _currentHealth;

    public event Action<int> OnHealthChanged;
    public event Action<object> OnDestroy;

    public virtual void TakeDamage(int damageAmount, object sender)
    {
        if (_currentHealth - damageAmount <= 0)
        {
            _currentHealth = 0;

            OnDestroy?.Invoke(sender);

            return;
        }

        _currentHealth -= damageAmount;

        OnHealthChanged?.Invoke(-damageAmount);
    }

    public void SetStartingHealth(int startingHealth)
    {
        _totalHealth = startingHealth;
        _currentHealth = startingHealth;
    }

    public void Heal(int amount)
    {
        if (_currentHealth + amount < _totalHealth)
        {
            _currentHealth += amount;
        }
        else
        {
            _currentHealth = _totalHealth;
        }

        OnHealthChanged?.Invoke(amount);
    }

    public void AddTotalHealth(int amount)
    {
        _totalHealth += amount;
    }
}