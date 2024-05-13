using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class EnemyBase : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private CharacterFactory _characterFactory;
    [Header("UI")]
    [SerializeField] private HealthPointsUI _healthPointsUI;
    [SerializeField] private WinLoseScreenUI _winLoseScreenUI;

    private Health _health;
    private EnemySpawnSettingsSO _enemySpawnSettingsSO;
    private int _currentWaveIndex = 0;

    private void Awake()
    {
        _health = GetComponent<Health>();

        _enemySpawnSettingsSO = GlobalData.Instance.CurrentLevel.LevelSO.EnemySpawnSettings;
        _health.SetStartingHealth(GlobalData.Instance.CurrentLevel.LevelSO.EnemyBaseHealth);
        _healthPointsUI.Initialize(_health);

        StartCoroutine(StartWavesLogic());
    }

    private void OnEnable()
    {
        _health.OnDestroy += Health_OnDestroy;
    }

    private void OnDisable()
    {
        _health.OnDestroy -= Health_OnDestroy;
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
            while (currentEnemyIndex < currentWave.EnemiesToSpawn.Count)
            {
                _characterFactory.SpawnEnemyCharacter(currentWave.EnemiesToSpawn[currentEnemyIndex]);

                var randomWaitSpawnTime = Random.Range(currentWave.minSpawnIntervalTime, currentWave.maxSpawnIntervalTime);
                yield return new WaitForSeconds(randomWaitSpawnTime);

                currentEnemyIndex++;
            }

            _currentWaveIndex++;
        }
    }

    private bool IsFinished()
    {
        if (_currentWaveIndex > _enemySpawnSettingsSO.Waves.Count - 1)
        {
            return true;
        }

        return false;
    }

    private void Health_OnDestroy(object sender)
    {
        GlobalData.Instance.CurrentLevel.Complete();
        _winLoseScreenUI.DispalayWin();

        _characterFactory.Deactivate();
    }
}