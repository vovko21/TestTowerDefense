using System;
using UnityEngine;

public enum State
{
    Idle = 0,
    Walk = 1,
    Attack = 2,
}

public class AIBrain : MonoBehaviour
{
    private Transform _mainDestination;

    private Character _character;
    private StateMachine _stateMachine;
    private State_Attack _attackState;
    private State_GoToDestination _goToDestinationState;

    public void Initialize(Character character, Transform mainDestination)
    {
        _character = character;
        _mainDestination = mainDestination;

        _character.Health.OnHealthChanged += Health_OnHealthChanged;

        //DEPENDENCIES
        _stateMachine = new StateMachine();

        //STATES
        _goToDestinationState = new State_GoToDestination(character, _mainDestination);
        _attackState = new State_Attack(character);

        //TRANSITIONS
        At(_goToDestinationState, _attackState, () => _character.CurrentState == State.Attack);
        At(_attackState, _goToDestinationState, () => _character.CurrentState == State.Walk);

        //START STATE
        _stateMachine.SetState(_goToDestinationState);

        //FUNCTIONS & CONDITIONALS
        void At(IState from, IState to, Func<bool> conditional) => _stateMachine.AddTransition(from, to, conditional);
        void Any(IState to, Func<bool> conditional) => _stateMachine.AddAnyTransition(to, conditional);
    }

    private void Update()
    {
        _stateMachine.Tick();
    }

    private void OnDisable()
    {
        _character.Health.OnHealthChanged -= Health_OnHealthChanged;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_character.CurrentState == State.Attack) return;
        if (collision.isTrigger) return;
        if (IsFriendlyTag(collision.tag)) return;

        var health = collision.GetComponent<Health>();

        if (health == null) return;

        _goToDestinationState.SetDestination(collision.transform);

        _character.CurrentState = State.Walk;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsFriendlyTag(collision.gameObject.tag)) return;

        var health = collision.gameObject.GetComponent<Health>();

        if (health == null) return;

        _attackState.SetTarget(health);
        health.OnDestroy += EnemyHealth_OnDestroy;
        _character.CurrentState = State.Attack;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (IsFriendlyTag(collision.gameObject.tag)) return;

        var health = collision.gameObject.GetComponent<Health>();

        if (health == null) return;

        health.OnDestroy -= EnemyHealth_OnDestroy;
        _goToDestinationState.SetDestination(_mainDestination);
        _character.CurrentState = State.Walk;
    }

    private void Health_OnHealthChanged(int valueChanged)
    {
        //if (_character.CurrentState == State.Attack) return;
        
        //if (valueChanged < 0)
        //{
        //    _character.CurrentState = State.Walk;
        //}
    }

    private void EnemyHealth_OnDestroy(object sender)
    {
        _goToDestinationState.SetDestination(_mainDestination);
        _character.CurrentState = State.Walk;
    }

    private bool IsFriendlyTag(string tag)
    {
        if (_character.tag == tag) return true;

        return false;
    }
}