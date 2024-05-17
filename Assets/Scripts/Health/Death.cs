using System.Collections;
using UnityEngine;

public struct EnemyDeathEvent
{
    public Character character;
    public int coinsReward;
}

[RequireComponent(typeof(Health))]
public class Death : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.OnDestroy += Health_OnDestroy;
    }

    private void OnDisable()
    {
        _health.OnDestroy -= Health_OnDestroy;
    }

    private void Health_OnDestroy(object sender)
    {
        StartCoroutine(DieCoroutine());
    }

    private IEnumerator DieCoroutine()
    {
        var character = GetComponent<Character>();
        var characterSO = character.CharacterSO as EnemyCharacterSO;

        if (characterSO != null)
        {
            GlobalData.Instance.CoinsWallet.Add(characterSO.CoinsReward);
            EventManager.TriggerEvent(new EnemyDeathEvent() { character = character, coinsReward = characterSO.CoinsReward });
        }

        var time = character.Animation.SetDying();

        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}