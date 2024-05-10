using UnityEngine;

public class State_GoToDestination : IState
{
    private Transform _destination;
    private Character _character;

    public State_GoToDestination(Character character, Transform destination)
    {
        _destination = destination;
        _character = character;
    }

    public void OnEnter()
    {
        _character.CharacterAnimation.SetWalk();
    }

    public void OnExit()
    {
        _character.CharacterAnimation.SetIdle();
    }

    public void Tick()
    {
        var direciton = _destination.position - _character.transform.position;
        direciton.Normalize();
        float angle = Mathf.Atan2(direciton.y, direciton.x) * Mathf.Rad2Deg;

        _character.transform.position = Vector2.MoveTowards(_character.transform.position, _destination.position, _character.CharacterSO.MovementSpeed * Time.deltaTime);
        _character.transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    public Color GetGizmosColor()
    {
        return Color.white;
    }
}