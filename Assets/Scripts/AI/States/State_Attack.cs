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
        if (_character.debug) Debug.Log("Enter Attack state");

        if (_target == null) return;

        if(_attackCoroutine != null)
        {
            _character.StopCoroutine(_attackCoroutine);
            _attackCoroutine = null;
        }

        _attackCoroutine = AttackCoroutine();

        _character.StartCoroutine(_attackCoroutine);
    }

    public void OnExit()
    {
        if (_attackCoroutine != null)
        {
            _character.StopCoroutine(_attackCoroutine);
            _attackCoroutine = null;
        }

        _character.Animation.SetIdle();
    }

    public void Tick()
    {
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            var duration = _character.Animation.SetAttack() - 0.1f;
            if(_character.debug)
                Debug.Log("ATTACK");
            _character.SoundEffects.PlayAttack();

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