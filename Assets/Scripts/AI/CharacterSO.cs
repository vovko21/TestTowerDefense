using UnityEngine;

public abstract class CharacterSO : ScriptableObject
{
    [field: Header("Main settings")]
    [field: SerializeField] public GameObject Prefab { get; private set; }

    [field: Header("Parameters")]
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public float AttackSpeed { get; private set; }
    [field: SerializeField] public float MovementSpeed { get; private set; }
}