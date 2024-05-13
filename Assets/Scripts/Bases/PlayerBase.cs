using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerBase : MonoBehaviour
{
    [SerializeField] private ResourceController _resourceController;
    [SerializeField] private ResourceUI _resourceUI;
    [SerializeField] private CharacterFactory _characterFactory;
    [SerializeField] private HealthPointsUI _healthPointsUI;

    private PlayerBaseData _playerBaseData;
    private Wallet _burgersWallet;
    private Health _health;

    private void OnEnable()
    {
        CharacterButtonUI.OnSpawnCharacter += OnSpawnCharacter;
    }

    private void OnDisable()
    {
        CharacterButtonUI.OnSpawnCharacter -= OnSpawnCharacter;
    }

    private void Awake()
    {
        _burgersWallet = new Wallet(ResourceType.Burgers);
        _health = GetComponent<Health>();
        _playerBaseData = GlobalData.Instance.PlayerBaseData;

        _resourceController.Initiallize(_burgersWallet, _playerBaseData.productionSpeed);
        _resourceUI.Initizlize(_burgersWallet);
        _health.SetStartingHealth(_playerBaseData.baseHealth);
        _healthPointsUI.Initialize(_health);

        _burgersWallet.Add(_playerBaseData.startBonus);
    }

    private void OnSpawnCharacter(PlayerCharacterSO characterSO)
    {
        if(_burgersWallet.Spend(characterSO.Price))
        {
            _characterFactory.SpawnPlayerCharacter(characterSO);
        }
    }
}