using UnityEngine;

[RequireComponent(typeof(CharacterAnimation))]
[RequireComponent(typeof(AIBrain))]
[RequireComponent(typeof(Health))]
public class Character : MonoBehaviour
{
    private CharacterSO _characterSO;
    private CharacterAnimation _characterAnimation;
    private AIBrain _aiBrain;
    private Health _health;

    public State State { get; set; }
    public CharacterSO CharacterSO => _characterSO;
    public CharacterAnimation CharacterAnimation => _characterAnimation;

    private void Awake()
    {
        _characterAnimation = GetComponent<CharacterAnimation>();
        _aiBrain = GetComponent<AIBrain>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.OnHealthChanged += Health_OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.OnHealthChanged -= Health_OnHealthChanged;
    }

    public void Initialize(CharacterSO characterSO, Transform mainDestination)
    {
        _characterSO = characterSO;

        _health.SetStartingHealth(_characterSO.Health);
        _aiBrain.Initialize(this, mainDestination);
    }

    private void Health_OnHealthChanged(int value)
    {
        if (value > 0) return;

        _characterAnimation.SetDamaged();
    }
}