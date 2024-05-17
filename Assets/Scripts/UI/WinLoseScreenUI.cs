using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class WinLoseScreenUI : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private CanvasGroup _background;
    [SerializeField] private TextMeshProUGUI _winLoseText;

    private void Start()
    {
        _panel.SetActive(false);
        _background.blocksRaycasts = false;
        _background.alpha = 0f;
    }

    public void DispalayLose()
    {
        _winLoseText.text = "YOU LOSE!";
        ShowPanel();
    }

    public void DispalayWin()
    {
        _winLoseText.text = "YOU WIN!";
        ShowPanel();
    }

    private void ShowPanel()
    {
        _background.alpha = 0f;
        _background.DOFade(0.5f, 0.5f);
        _background.blocksRaycasts = true;

        _panel.SetActive(true);

        _panel.transform.localPosition = new Vector2(0, -Screen.height);
        _panel.transform.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutExpo).SetDelay(0.1f);
    }

    public void RetrunToMenu()
    {
        SceneManager.LoadScene("LevelSelector");
    }
}