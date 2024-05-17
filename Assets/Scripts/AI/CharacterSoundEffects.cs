using UnityEngine;

public class CharacterSoundEffects : MonoBehaviour
{
    [SerializeField] private AudioSource _attackSound;
    [SerializeField] private AudioSource _hurtSound;

    public void PlayAttack()
    {
        _attackSound.Play();
    }

    public void PlayHurt()
    {
        _hurtSound.Play();
    }
}