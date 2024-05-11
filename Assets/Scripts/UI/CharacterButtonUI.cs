using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CharacterButtonUI : MonoBehaviour
{
    [SerializeField] private PlayerCharacterSO _characterSO;
    [SerializeField] private TextMeshProUGUI _dataText;

    private Button _button;

    public static event Action<PlayerCharacterSO> OnSpawnCharacter;

    private void Awake()
    {
        _button = GetComponent<Button>();

        _dataText.text = _characterSO.Price.ToString();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        OnSpawnCharacter?.Invoke(_characterSO);
    }
}