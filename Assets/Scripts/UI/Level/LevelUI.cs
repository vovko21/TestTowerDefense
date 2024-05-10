using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class LevelUI : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _completedSprite;

    private Image _sourceImage;
    private Button _sourceButton;

    public LevelData LevelData => _levelData;

    public static event Action<LevelData> OnLevelSelected;

    private void Awake()
    {
        _sourceImage = GetComponent<Image>();
        _sourceButton = GetComponent<Button>();

        SetSprite(_levelData.IsCompleted);
    }

    private void OnEnable()
    {
        _sourceButton.onClick.AddListener(OnLevelClicked);
    }

    private void OnDisable()
    {
        _sourceButton.onClick.RemoveListener(OnLevelClicked);
    }

    private void SetSprite(bool completed)
    {
        if (completed == true)
        {
            _sourceImage.sprite = _completedSprite;
        }
        else
        {
            _sourceImage.sprite = _defaultSprite;
        }
    }

    private void OnLevelClicked()
    {
        OnLevelSelected?.Invoke(_levelData);
    }
}