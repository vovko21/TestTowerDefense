using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemyCharacter")]
public class EnemyCharacterSO : CharacterSO
{
    [field: SerializeField] public int CoinsReward { get; private set; }
}
