using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPreviewUI : MonoBehaviour
{
    [Header("Level deteils")]
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _closeButton;

    [Header("Other")]
    [SerializeField] private string _sceneName;

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
        _nameText.text = levelData.LevelSO.Name;
        _descriptionText.text = levelData.LevelSO.Description;
    }

    private void OnPlayClicked()
    {
        SceneManager.LoadScene(_sceneName);
    }

    private void OnCloseClicked()
    {
        OnLevelPreviewCloseClicked?.Invoke();
    }
}