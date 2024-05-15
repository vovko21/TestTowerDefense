using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private ShopItemUI _productionSpeedItem;
    [SerializeField] private ShopItemUI _baseHealthItem;
    [SerializeField] private ShopItemUI _startBonusItem;

    private void Start()
    {
        HidePanel();

        _productionSpeedItem.Initialize(25);
        _baseHealthItem.Initialize(20);
        _startBonusItem.Initialize(50);

        for (int i = 0; i < GlobalData.Instance.PlayerBaseData.productionSpeed.UpgradedIndex; i++)
        {
            _productionSpeedItem.UpdatePrice();
        }
        _productionSpeedItem.UpdateDataText(GlobalData.Instance.PlayerBaseData.productionSpeed.Value - 0.02f);

        for (int i = 0; i < GlobalData.Instance.PlayerBaseData.baseHealth.UpgradedIndex; i++)
        {
            _baseHealthItem.UpdatePrice();
        }
        _baseHealthItem.UpdateDataText(GlobalData.Instance.PlayerBaseData.baseHealth.Value + 5);

        for (int i = 0; i < GlobalData.Instance.PlayerBaseData.startBonus.UpgradedIndex; i++)
        {
            _startBonusItem.UpdatePrice();
        }
        _startBonusItem.UpdateDataText(GlobalData.Instance.PlayerBaseData.startBonus.Value + 1);
    }

    public void ShowPanel()
    {
        _panel.SetActive(true);
    }

    public void HidePanel()
    {
        _panel.SetActive(false);
    }

    public void UpgradeProducctionSpeed()
    {
        if (GlobalData.Instance.PlayerBaseData.productionSpeed.Value <= 0) return;

        if (GlobalData.Instance.CoinsWallet.Spend(_productionSpeedItem.CurrentPrice))
        {
            GlobalData.Instance.PlayerBaseData.productionSpeed.Value -= 0.02f;
            GlobalData.Instance.PlayerBaseData.productionSpeed.UpgradedIndex += 1;

            _productionSpeedItem.UpdatePrice();
            _productionSpeedItem.UpdateDataText(GlobalData.Instance.PlayerBaseData.productionSpeed.Value - 0.02f);
        }
    }

    public void UpgradeBaseHealth()
    {
        if (GlobalData.Instance.CoinsWallet.Spend(_baseHealthItem.CurrentPrice))
        {
            GlobalData.Instance.PlayerBaseData.baseHealth.Value += 5;
            GlobalData.Instance.PlayerBaseData.baseHealth.UpgradedIndex += 1;

            _baseHealthItem.UpdatePrice();
            _baseHealthItem.UpdateDataText(GlobalData.Instance.PlayerBaseData.baseHealth.Value + 5);
        }
    }

    public void UpgradeStartBonus()
    {
        if (GlobalData.Instance.CoinsWallet.Spend(_startBonusItem.CurrentPrice))
        {
            GlobalData.Instance.PlayerBaseData.startBonus.Value += 1;
            GlobalData.Instance.PlayerBaseData.startBonus.UpgradedIndex += 1;

            _startBonusItem.UpdatePrice();
            _startBonusItem.UpdateDataText(GlobalData.Instance.PlayerBaseData.startBonus.Value + 1);
        }
    }
}