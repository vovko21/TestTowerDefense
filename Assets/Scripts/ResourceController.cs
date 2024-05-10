using System.Collections;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    [Header("Resource settings")]
    [SerializeField] private int _cycleTime;
    [SerializeField] private int _increaseBy;

    private Wallet _burgerWallet;

    public void Initiallize(Wallet burgerWallet)
    {
        _burgerWallet = burgerWallet;

        StartCoroutine(ResourceCounter());
    }

    private IEnumerator ResourceCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(_cycleTime);

            _burgerWallet.Add(_increaseBy);
        }
    }
}