using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPreviewUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _closeButton;

    private LevelData _levelData;

    public event Action OnLevelPreviewCloseClicked;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayClicked);
        _closeButton.onClick.AddListener(OnCloseClicked);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayClicked);
        _closeButton.onClick.RemoveListener(OnCloseClicked);
    }

    public void Initialize(LevelData levelData)
    {
        _levelData = levelData;

        _nameText.text = _levelData.LevelSO.Name;
        _descriptionText.text = _levelData.LevelSO.Description;
    }

    private void OnPlayClicked()
    {
        GlobalData.Instance.SetCurrentLevel(_levelData);
        SceneManager.LoadScene(_levelData.LevelSO.SceneName);
    }

    private void OnCloseClicked()
    {
        OnLevelPreviewCloseClicked?.Invoke();
    }
}