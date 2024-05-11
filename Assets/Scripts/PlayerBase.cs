using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private ResourceController _resourceController;
    [SerializeField] private ResourceUI _resourceUI;
    [SerializeField] private CharacterFactory _characterFactory;

    private Wallet _burgersWallet;

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

        _resourceController.Initiallize(_burgersWallet);
        _resourceUI.Initizlize(_burgersWallet);
    }

    private void OnSpawnCharacter(PlayerCharacterSO characterSO)
    {
        if(_burgersWallet.Spend(characterSO.Price))
        {
            _characterFactory.SpawnPlayerCharacter(characterSO);
        }
    }
}