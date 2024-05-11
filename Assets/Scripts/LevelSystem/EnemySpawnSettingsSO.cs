using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct WaveSettings
{
    public float minSpawnIntervalTime;
    public float maxSpawnIntervalTime;

    public List<EnemyCharacterSO> EnemiesToSpawn;
}

[CreateAssetMenu(menuName = "ScriptableObjects/EnemySpawnSettings")]
public class EnemySpawnSettingsSO : ScriptableObject
{
    [field: Header("Interaval")]
    [field: SerializeField] public float MinWaveIntervalTime { get; private set; }
    [field: SerializeField] public float MaxWaveIntervalTime { get; private set; }

    [field: SerializeField] public List<WaveSettings> Waves { get; private set; }
}