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

        var direciton = _destination.position - _character.transform.position;

        if(direciton.x > 0)
        {
            _character.transform.localScale = new Vector3(1,1,1);
        }
        else
        {
            _character.transform.localScale = new Vector3(-1, 1, 1);
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