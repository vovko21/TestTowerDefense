using System;

public class Wallet
{
    private ResourceData _resourceData;

    public ResourceData ResourceData => _resourceData;

    public event Action<int> OnValueChanged;

    public Wallet(ResourceData resourceData)
    {
        _resourceData = resourceData;
    }

    public Wallet(ResourceType resourceType)
    {
        _resourceData = new ResourceData() { type = resourceType };
    }

    public void Add(int value)
    {
        _resourceData.value += value;

        OnValueChanged?.Invoke(value);
    }

    public bool Spend(int value)
    {
        if (_resourceData.value - value < 0)
        {
            return false;
        }

        _resourceData.value -= value;

        OnValueChanged?.Invoke(-value);

        return true;
    }
}