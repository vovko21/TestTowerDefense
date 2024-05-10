using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerCharacter")]
public class PlayerCharacterSO : CharacterSO
{
    [field: SerializeField] public int Price { get; private set; }
}
