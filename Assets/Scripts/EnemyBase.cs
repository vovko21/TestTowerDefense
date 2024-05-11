using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private CharacterFactory _characterFactory;

    private EnemySpawnSettingsSO _enemySpawnSettingsSO;
    private int _currentWaveIndex;

    private void Start()
    {
        _enemySpawnSettingsSO = GlobalData.Instance.CurrentLevel.LevelSO.EnemySpawnSettings;
        
        StartCoroutine(StartWavesLogic());
    }

    private IEnumerator StartWavesLogic()
    {
        while (!IsFinished())
        {
            var randomWaitInterval = Random.Range(_enemySpawnSettingsSO.MinWaveIntervalTime, _enemySpawnSettingsSO.MaxWaveIntervalTime);
            yield return new WaitForSeconds(randomWaitInterval);

            //Start Wave
            var currentWave = _enemySpawnSettingsSO.Waves[_currentWaveIndex];

            var currentEnemyIndex = 0;
            while (currentEnemyIndex != currentWave.EnemiesToSpawn.Count - 1)
            {
                var randomWaitSpawnTime = Random.Range(currentWave.minSpawnIntervalTime, currentWave.maxSpawnIntervalTime);
                yield return new WaitForSeconds(randomWaitSpawnTime);

                _characterFactory.SpawnEnemyCharacter(currentWave.EnemiesToSpawn[currentEnemyIndex]);

                currentEnemyIndex++;
            }

            _currentWaveIndex++;
        }
    }

    private bool IsFinished()
    {
        if ( _currentWaveIndex > _enemySpawnSettingsSO.Waves.Count - 1)
        {
            return true;
        }

        return false;
    }
}