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

    private void LevelUI_OnLevelSelected(LevelSO levelSO)
    {
        ShowLevelPreview(levelSO);
    }

    public void ShowLevelPreview(LevelSO levelSO)
    {
        _levelPreview.Initialize(levelSO);
        _levelPreview.gameObject.SetActive(true);
    }

    public void HideLevelPreview()
    {
        _levelPreview.gameObject.SetActive(false);
    }
}