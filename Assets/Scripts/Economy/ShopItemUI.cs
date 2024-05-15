using TMPro;
using UnityEngine;

public class ShopItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dataText;
    [SerializeField] private TextMeshProUGUI _priceText;

    private int _currentPrice;

    public int CurrentPrice => _currentPrice;

    public void Initialize(int startPrice)
    {
        _currentPrice = startPrice;

        UpdatePriceText();
    }

    public void UpdatePrice()
    {
        _currentPrice = (int)(_currentPrice * 1.3f);

        UpdatePriceText();
    }

    private void UpdatePriceText()
    {
        _priceText.text = _currentPrice.ToString();
    }

    public void UpdateDataText(float data)
    {
        _dataText.text = data.ToString();
    }
}