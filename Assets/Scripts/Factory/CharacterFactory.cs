using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : MonoBehaviour
{
    [Header("Main settings")]
    [SerializeField] public List<Transform> _playerSpawnPoint;
    [SerializeField] public List<Transform> _enemySpawnPoint;

    [Header("Goals")]
    [SerializeField] private Transform _playerBase;
    [SerializeField] private Transform _enemyBase;

    private bool _isActive;

    private void Awake()
    {
        Activate();
    }

    public void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    public void SpawnPlayerCharacter(CharacterSO characterSO)
    {
        if (!_isActive) return;

        SpawnCharacter(characterSO, _playerSpawnPoint, _enemyBase);
    }

    public void SpawnEnemyCharacter(CharacterSO characterSO)
    {
        if (!_isActive) return;

        SpawnCharacter(characterSO, _enemySpawnPoint, _playerBase);
    }

    private Character SpawnCharacter(CharacterSO characterSO, List<Transform> spawnPoints, Transform mainDestination)
    {
        Vector2 randomPosition = GetRandomSpawnPoint(spawnPoints).position;

        var instantitedObject = Instantiate(characterSO.Prefab, randomPosition, Quaternion.identity, transform);

        var character = instantitedObject.GetComponent<Character>();

        character.Initialize(characterSO, mainDestination);

        return character;
    }

    private void OnDestroyPlayerCharacter(object sender)
    {

    }

    private void OnDestroyEnemyCharacter(object sender)
    {

    }

    private Transform GetRandomSpawnPoint(List<Transform> spawnPoints)
    {
        return spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)];
    }
}