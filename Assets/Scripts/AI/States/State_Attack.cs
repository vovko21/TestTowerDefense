using System.Collections;
using UnityEngine;

public class State_Attack : IState
{
    private Character _character;
    private Health _target;

    private IEnumerator _attackCoroutine;

    public State_Attack(Character character)
    {
        _character = character;
    }

    public void SetTarget(Health target) 
    {
        if (target == null) return;

        _target = target;
    }

    public void OnEnter()
    {
        if (_target == null) return;

        _attackCoroutine = AttackCoroutine();

        _character.StartCoroutine(_attackCoroutine);
    }

    public void OnExit()
    {
        if (_attackCoroutine != null)
            _character.StopCoroutine(_attackCoroutine);

        _character.CharacterAnimation.SetIdle();
    }

    public void Tick()
    {
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            var duration = _character.CharacterAnimation.SetAttack() - 0.1f;

            yield return new WaitForSeconds(duration);

            _target.TakeDamage(_character.CharacterSO.Damage, _character);

            if (_target.CurrentHealth <= 0)
            {
                _character.CurrentState = State.Walk;
            }

            yield return new WaitForSeconds(_character.CharacterSO.AttackSpeed - duration);
        }
    }

    public Color GetGizmosColor()
    {
        return Color.red;
    }
}