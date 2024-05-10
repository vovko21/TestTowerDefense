using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

public enum State
{
    None = 0,
    Idle = 1,
    Walk = 2,
    Attack = 3,
}

public class AIBrain : MonoBehaviour
{
    [SerializeField] private Transform _destination;

    private Character _character;
    private StateMachine _stateMachine;
    private State_Attack _attackState;

    public void Initialize(Character character)
    {
        _character = character;

        //DEPENDENCIES
        _stateMachine = new StateMachine();

        //STATES
        var goToDestinationState = new State_GoToDestination(character, _destination);
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
        var health = collision.GetComponent<Health>();
        
        if (health == null) return;
        
        _attackState.SetTarget(health);

        _character.State = State.Attack;
    }
}