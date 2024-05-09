using UnityEngine;

public class LevelSelectorUI : MonoBehaviour
{
    [SerializeField] private LevelPreviewUI _levelPreview;

    private void Awake()
    {
        HideLevelPreview();
    }

    private void OnEnable()
    {
        LevelUI.OnLevelSelected += LevelUI_OnLevelSelected;
        _levelPreview.OnLevelPreviewCloseClicked += HideLevelPreview;
    }

    private void OnDisable()
    {
        LevelUI.OnLevelSelected -= LevelUI_OnLevelSelected;
        _levelPreview.OnLevelPreviewCloseClicked -= HideLevelPreview;
    }

    private void LevelUI_OnLevelSelected(LevelData levelData)
    {
        ShowLevelPreview(levelData);
    }

    public void ShowLevelPreview(LevelData levelData)
    {
        _levelPreview.Initialize(levelData);
        _levelPreview.gameObject.SetActive(true);
    }

    public void HideLevelPreview()
    {
        _levelPreview.gameObject.SetActive(false);
    }
}