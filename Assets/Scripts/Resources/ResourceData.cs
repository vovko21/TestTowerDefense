public enum ResourceType
{
    None = 0,
    Burgers = 1,
    Coins = 2,
}

public struct ResourceData
{
    public ResourceType type;
    public int value;
}