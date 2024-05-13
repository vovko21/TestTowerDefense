using System.Collections.Generic;
using Unity.VisualScripting;
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
    private List<GameObject> _instantiatedPlayerCharacters;
    private List<GameObject> _instantiatedEnemyCharacters;

    private void Awake()
    {
        _isActive = true;
        _instantiatedPlayerCharacters = new List<GameObject>();
        _instantiatedEnemyCharacters = new List<GameObject>();
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

    private GameObject SpawnCharacter(CharacterSO characterSO, List<Transform> spawnPoints, Transform mainDestination)
    {
        Vector2 randomPosition = GetRandomSpawnPoint(spawnPoints).position;

        var instantitedObject = Instantiate(characterSO.Prefab, randomPosition, Quaternion.identity, transform);

        var character = instantitedObject.GetComponent<Character>();

        character.Initialize(characterSO, mainDestination);

        return instantitedObject;
    }

    private Transform GetRandomSpawnPoint(List<Transform> spawnPoints)
    {
        return spawnPoints[Random.Range(0, spawnPoints.Count)];
    }
}