using UnityEngine;

public class State_GoToDestination : IState
{
    private Transform _destination;
    private Character _character;

    private float _pathUpdateDelay = 0.5f;
    private float _pathUpdateDeadline;

    public State_GoToDestination(Character character, Transform destination)
    {
        _destination = destination;
        _character = character;
    }

    public void OnEnter()
    {
        _character.Agent.isStopped = false;

        _character.CharacterAnimation.SetWalk();
    }

    public void OnExit()
    {
        _character.Agent.isStopped = true;

        _character.CharacterAnimation.SetIdle();
    }

    public void Tick()
    {
        if (Time.time >= _pathUpdateDeadline)
        {
            _character.Agent.SetDestination(_destination.position);
            _pathUpdateDeadline = Time.time + _pathUpdateDelay;
        }
    }

    public void SetDestination(Transform destination)
    {
        _destination = destination;
    }

    public Color GetGizmosColor()
    {
        return Color.white;
    }
}