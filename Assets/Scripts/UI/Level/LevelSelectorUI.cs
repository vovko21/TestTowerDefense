using DG.Tweening;
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

        _levelPreview.transform.localScale = Vector2.zero;
        _levelPreview.transform.DOScale(Vector2.one, 0.2f);
    }

    public void HideLevelPreview()
    {
        _levelPreview.transform.DOScale(Vector2.zero, 0.2f).SetEase(Ease.InBack).OnComplete(
            () =>
            {
                _levelPreview.gameObject.SetActive(false);
            }
        );
    }
}