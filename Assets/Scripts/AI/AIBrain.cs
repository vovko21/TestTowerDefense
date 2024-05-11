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

    public void Initialize(Character character, Transform mainDestination)
    {
        _character = character;
        _mainDestination = mainDestination;

        //DEPENDENCIES
        _stateMachine = new StateMachine();

        //STATES
        var goToDestinationState = new State_GoToDestination(character, _mainDestination);
        _attackState = new State_Attack(character);

        //TRANSITIONS
        At(goToDestinationState, _attackState, () => _character.State == State.Attack);
        At(_attackState, goToDestinationState, () => _character.State == State.Walk);

        //START STATE
        _stateMachine.SetState(goToDestinationState);

        //FUNCTIONS & CONDITIONALS
        void At(IState from, IState to, Func<bool> conditional) => _stateMachine.AddTransition(from, to, conditional);
        void Any(IState to, Func<bool> conditional) => _stateMachine.AddAnyTransition(to, conditional);
    }

    private void Update()
    {
        _stateMachine.Tick();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsEnemyTag(collision.tag)) return;

        var health = collision.GetComponent<Health>();

        if (health == null) return;
        
        _attackState.SetTarget(health);

        _character.State = State.Attack;
    }

    private bool IsEnemyTag(string tag)
    {
        if (_character.tag == tag) return false;

        return true;
    }
}