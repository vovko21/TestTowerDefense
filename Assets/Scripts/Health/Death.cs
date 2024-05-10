using UnityEngine;

public struct EnemyDeathEvent
{
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
        if(this.CompareTag("EnemyCharacter"))
        {
            var characterSO = GetComponent<Character>().CharacterSO as EnemyCharacterSO;

            if(characterSO != null)
            {
                EventManager.TriggerEvent(new EnemyDeathEvent() { coinsReward = characterSO.CoinsReward });
            }
        }

        Destroy(gameObject);
    }
}