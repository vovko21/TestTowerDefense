using TMPro;
using UnityEngine;

public class ResourceUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dataText;

    private Wallet _burgerWallet;

    public void Initizlize(Wallet burgerWallet)
    {
        _burgerWallet = burgerWallet;

        _burgerWallet.OnValueChanged += BurgerWallet_OnValueChanged;
    }

    private void OnDisable()
    {
        _burgerWallet.OnValueChanged -= BurgerWallet_OnValueChanged;
    }

    private void BurgerWallet_OnValueChanged(int value)
    {
        _dataText.text = _burgerWallet.ResourceData.value.ToString();
    }
}