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

    private List<GameObject> _instantiatedPlayerCharacters;
    private List<GameObject> _instantiatedEnemyCharacters;

    private void Awake()
    {
        _instantiatedPlayerCharacters = new List<GameObject>();
        _instantiatedEnemyCharacters = new List<GameObject>();
    }

    public void SpawnPlayerCharacter(CharacterSO characterSO)
    {
        SpawnCharacter(characterSO, _playerSpawnPoint, _enemyBase);
    }

    public void SpawnEnemyCharacter(CharacterSO characterSO)
    {
        SpawnCharacter(characterSO, _enemySpawnPoint, _playerBase);
    }

    private void SpawnCharacter(CharacterSO characterSO, List<Transform> spawnPoints, Transform mainDestination)
    {
        Vector2 randomPosition = GetRandomSpawnPoint(spawnPoints).position;

        var instantitedObject = Instantiate(characterSO.Prefab, randomPosition, Quaternion.identity, transform);

        var character = instantitedObject.GetComponent<Character>();

        character.Initialize(characterSO, mainDestination);
    }

    private Transform GetRandomSpawnPoint(List<Transform> spawnPoints)
    {
        return spawnPoints[Random.Range(0, spawnPoints.Count)];
    }
}