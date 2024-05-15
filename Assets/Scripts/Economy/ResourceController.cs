using System.Collections;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    [Header("Resource settings")]
    [SerializeField] private float _cycleTime;
    [SerializeField] private int _increaseBy;

    private Wallet _burgerWallet;

    public void Initiallize(Wallet burgerWallet, float cycleTime)
    {
        _burgerWallet = burgerWallet;
        _cycleTime = cycleTime;

        StartCoroutine(ResourceCounter());
    }

    public void Deinitialize()
    {
        StopAllCoroutines();
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