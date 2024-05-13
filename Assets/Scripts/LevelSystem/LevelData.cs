using System;
using UnityEngine;

[Serializable]
public class LevelData
{
    [SerializeField] private LevelSO _levelSO;

    private bool _isCompleted;

    public LevelSO LevelSO => _levelSO;
    public bool IsCompleted => _isCompleted;

    public LevelData(LevelSO levelSO)
    {
        _levelSO = levelSO;
        _isCompleted = false;
    }

    public void Complete()
    {
        if (_isCompleted != true)
        {
            _isCompleted = true;
        }
        else
        {
            Debug.LogError("Trying to complete already completed level!");
        }
    }
}