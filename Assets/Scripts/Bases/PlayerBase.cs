using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerBase : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private ResourceController _resourceController;
    [SerializeField] private CharacterFactory _characterFactory;
    [Header("UI")]
    [SerializeField] private ResourceUI _resourceUI;
    [SerializeField] private HealthPointsUI _healthPointsUI;
    [SerializeField] private WinLoseScreenUI _winLoseScreenUI;

    private PlayerBaseData _playerBaseData;
    private Wallet _burgersWallet;
    private Health _health;

    private void Awake()
    {
        _burgersWallet = new Wallet(ResourceType.Burgers);
        _health = GetComponent<Health>();
        _playerBaseData = GlobalData.Instance.PlayerBaseData;

        _resourceController.Initiallize(_burgersWallet, _playerBaseData.productionSpeed.Value);
        _resourceUI.Initizlize(_burgersWallet);
        _health.SetStartingHealth(_playerBaseData.baseHealth.Value);
        _healthPointsUI.Initialize(_health);

        _burgersWallet.Add(_playerBaseData.startBonus.Value);
    }

    private void OnEnable()
    {
        CharacterButtonUI.OnSpawnCharacter += OnSpawnCharacter;
        _health.OnDestroy += Health_OnDestroy;
    }

    private void OnDisable()
    {
        CharacterButtonUI.OnSpawnCharacter -= OnSpawnCharacter;
        _health.OnDestroy -= Health_OnDestroy;
    }

    private void OnSpawnCharacter(PlayerCharacterSO characterSO)
    {
        if(_burgersWallet.Spend(characterSO.Price))
        {
            _characterFactory.SpawnPlayerCharacter(characterSO);
        }
    }

    private void Health_OnDestroy(object sender)
    {
        _winLoseScreenUI.DispalayLose();

        _resourceController.Deinitialize();
        _characterFactory.Deactivate();
    }
}