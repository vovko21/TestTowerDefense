using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class LevelUI : MonoBehaviour
{
    [SerializeField] private LevelSO _levelSO;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _completedSprite;

    private Image _sourceImage;
    private Button _sourceButton;

    public LevelSO LevelSO => _levelSO;

    public static event Action<LevelSO> OnLevelSelected;

    private void Awake()
    {
        _sourceImage = GetComponent<Image>();
        _sourceButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _sourceButton.onClick.AddListener(OnLevelClicked);
    }

    private void OnDisable()
    {
        _sourceButton.onClick.RemoveListener(OnLevelClicked);
    }

    public void SetSprite(bool completed)
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
        OnLevelSelected?.Invoke(_levelSO);
    }
}