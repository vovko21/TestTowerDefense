using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Level")]
public class LevelSO : ScriptableObject
{
    [field: Header("Main settings")]
    [field: SerializeField] public string Id { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public string SceneName { get; private set; }

    [field: Header("Enemy settings")]
    [field: SerializeField] public int EnemyBaseHealth { get; private set; }
    [field: SerializeField] public EnemySpawnSettingsSO EnemySpawnSettings { get; private set; }
}