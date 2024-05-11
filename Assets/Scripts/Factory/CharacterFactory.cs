using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : MonoBehaviour
{
    [Header("Main settings")]
    [SerializeField] public List<Transform> _playerSpawnPoint;
    [SerializeField] public List<Transform> _enemySpawnPoint;
    [SerializeField] private GameObject _playerCharacterPrefab;
    [SerializeField] private GameObject _enemyCharacterPrefab;

    [Header("Goals")]
    [SerializeField] private Transform _playerBase;
    [SerializeField] private Transform _enemyBase;

    private List<GameObject> _instantiatedPlayerCharacters;
    private List<GameObject> _instantiatedEnemyCharacters;

    private void Awake()
    {
        _instantiatedPlayerCharacters = new List<GameObject>();
        _instantiatedEnemyCharacters = new List<GameObject>();
    }

    public void SpawnPlayerCharacter(CharacterSO characterSO)
    {
        Vector2 randomPosition = GetRandomSpawnPoint(_playerSpawnPoint).position;

        var instantitedObject = Instantiate(_playerCharacterPrefab, randomPosition, Quaternion.identity, transform);

        var character = instantitedObject.GetComponent<Character>();

        character.Initialize(characterSO, _enemyBase);
    }

    private Transform GetRandomSpawnPoint(List<Transform> spawnPoints)
    {
        return spawnPoints[Random.Range(0, spawnPoints.Count)];
    }
}