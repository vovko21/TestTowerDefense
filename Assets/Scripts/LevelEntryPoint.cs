using UnityEngine;

public class LevelEntryPoint : MonoBehaviour
{
    [SerializeField] private ResourceController _resourceController;
    [SerializeField] private ResourceUI _resourceUI;

    private void Awake()
    {
        var burgersWallet = new Wallet(ResourceType.Burgers);

        _resourceController.Initiallize(burgersWallet);
        _resourceUI.Initizlize(burgersWallet);
    }
}