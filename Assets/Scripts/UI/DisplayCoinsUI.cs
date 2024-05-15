using TMPro;
using UnityEngine;

public class DisplayCoinsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private void OnEnable()
    {
        GlobalData.Instance.CoinsWallet.OnValueChanged += CoinsWallet_OnValueChanged;
    }

    private void OnDisable()
    {
        GlobalData.Instance.CoinsWallet.OnValueChanged -= CoinsWallet_OnValueChanged;
    }

    private void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        _textMeshPro.text = GlobalData.Instance.CoinsWallet.ResourceData.value.ToString();
    }

    private void CoinsWallet_OnValueChanged(int valueChanged)
    {
        UpdateText();
    }
}