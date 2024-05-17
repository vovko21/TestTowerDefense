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
        _character.Animation.SetWalk();
    }

    public void OnExit()
    {
        _character.Agent.ResetPath();

        _character.Animation.SetIdle();
    }

    public void Tick()
    {
        if (_destination == null) return;

        if (Time.time >= _pathUpdateDeadline)
        {
            _character.Agent.SetDestination(_destination.position);
            _pathUpdateDeadline = Time.time + _pathUpdateDelay;
        }

        var direciton = _destination.position - _character.transform.position;

        if (direciton.x > 0)
        {
            _character.transform.localScale = new Vector3(Mathf.Abs(_character.transform.localScale.x), _character.transform.localScale.y, _character.transform.localScale.z);
        }
        else
        {
            _character.transform.localScale = new Vector3(-Mathf.Abs(_character.transform.localScale.x), _character.transform.localScale.y, _character.transform.localScale.z);
        }
    }

    public void SetDestination(Transform destination)
    {
        if (destination == null) return;

        _destination = destination;
    }

    public Color GetGizmosColor()
    {
        return Color.white;
    }
}