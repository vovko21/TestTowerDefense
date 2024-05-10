using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string WALK_PARAMETR_NAME = "IsWalking";
    private const string ATTACK_PARAMETR_NAME = "Attack";
    private const string DAMAGE_PARAMETR_NAME = "Damage";

    public void SetIdle()
    {
        _animator.SetBool(WALK_PARAMETR_NAME, false);
    }

    public void SetWalk()
    {
        _animator.SetBool(WALK_PARAMETR_NAME, true);
    }

    public float SetAttack()
    {
        var data = _animator.GetCurrentAnimatorClipInfo(0);
        _animator.SetTrigger(ATTACK_PARAMETR_NAME);
        return data[0].clip.averageDuration;
    }

    public void SetDamaged()
    {
        _animator.SetTrigger(DAMAGE_PARAMETR_NAME);
    }
}