public class PlayerBaseData
{
    public UpgradeItem<float> productionSpeed;
    public UpgradeItem<int> baseHealth;
    public UpgradeItem<int> startBonus;

    public PlayerBaseData()
    {
        productionSpeed = new UpgradeItem<float>() { Value = 1f };
        baseHealth = new UpgradeItem<int>() { Value = 25 };
        startBonus = new UpgradeItem<int>() { Value = 0 };
    }
}