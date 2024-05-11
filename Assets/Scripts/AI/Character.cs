using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CharacterAnimation))]
[RequireComponent(typeof(AIBrain))]
[RequireComponent(typeof(Health))]
public class Character : MonoBehaviour
{
    private NavMeshAgent _agent;
    private CharacterSO _characterSO;
    private CharacterAnimation _characterAnimation;
    private AIBrain _aiBrain;
    private Health _health;

    public State CurrentState { get; set; }
    public CharacterSO CharacterSO => _characterSO;
    public NavMeshAgent Agent => _agent;
    public CharacterAnimation CharacterAnimation => _characterAnimation;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
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
        _agent.speed = _characterSO.MovementSpeed;
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Health_OnHealthChanged(int value)
    {
        if (value > 0) return;

        _characterAnimation.SetDamaged();
    }
}