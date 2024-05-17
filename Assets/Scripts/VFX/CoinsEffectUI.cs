using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsEffectUI : MonoBehaviour, IEventListener<EnemyDeathEvent>
{
    [Header("Setup settings")]
    [SerializeField] private GameObject _coinsPrefab;
    [SerializeField] private Transform _endCoinsPosition;

    [Header("Move settings")]
    [SerializeField] private float _duration;

    [Header("Spawn settings")]
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    private void OnEnable()
    {
        this.StartListeningEvent();
    }

    private void OnDisable()
    {
        this.StopListeningEvent();
    }

    public void OnEvent(EnemyDeathEvent eventParams)
    {
        if(eventParams.coinsReward > 0)
        {
            var position = RectTransformUtility.WorldToScreenPoint(Camera.main, eventParams.character.transform.position);
            StartCoroutine(CollectEffectCouroutine(eventParams.coinsReward, _coinsPrefab, position, _endCoinsPosition));
        }
    }

    private IEnumerator CollectEffectCouroutine(int amount, GameObject prefab, Vector2 spawnPosition, Transform endPosition)
    {
        var prefabsList = new List<GameObject>();

        var prefabsCount = CalculatePrefabCount(amount);

        for (int i = 0; i < prefabsCount; i++)
        {
            var spawnedPrefab = Instantiate(prefab, transform);
            float xPosition = spawnPosition.x + Random.Range(_minX, _maxX);
            float yPosition = spawnPosition.y + Random.Range(_minY, _maxY);
            spawnedPrefab.transform.position = new Vector3(xPosition, yPosition);
            spawnedPrefab.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            spawnedPrefab.transform.DOPunchPosition(new Vector3(0, 30, 0), Random.Range(0, 1f)).SetEase(Ease.InBack);
            prefabsList.Add(spawnedPrefab);
            yield return new WaitForSeconds(0.015f);
        }

        foreach (var prefabItem in prefabsList)
        {
            prefabItem.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f).SetEase(Ease.InSine);
            yield return new WaitForSeconds(0.05f);
        }

        foreach (var prefabItem in prefabsList)
        {
            prefabItem.transform.DOMove(endPosition.position, _duration).SetEase(Ease.InBack);
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(_duration);

        foreach (var item in prefabsList)
        {
            Destroy(item);
        }

        prefabsList.Clear();
    }

    private int CalculatePrefabCount(int amount)
    {
        return Mathf.Clamp(Mathf.RoundToInt(amount / 5f), 1, 10);
    }
}