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

    private LevelSO _levelSO;

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

    public void Initialize(LevelSO levelSO)
    {
        _levelSO = levelSO;

        _nameText.text = _levelSO.Name;
        _descriptionText.text = _levelSO.Description;
    }

    private void OnPlayClicked()
    {
        GlobalData.Instance.SetCurrentLevel(_levelSO);
        SceneManager.LoadScene(_levelSO.SceneName);
    }

    private void OnCloseClicked()
    {
        OnLevelPreviewCloseClicked?.Invoke();
    }
}