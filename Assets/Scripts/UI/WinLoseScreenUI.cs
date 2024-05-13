using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreenUI : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TextMeshProUGUI _winLoseText;

    private void Start()
    {
        _panel.SetActive(false);
        
    }

    public void DispalayLose()
    {
        _winLoseText.text = "YOU LOSE!";
        _panel.SetActive(true);
    }

    public void DispalayWin()
    {
        _winLoseText.text = "YOU WIN!";
        _panel.SetActive(true);
    }

    public void RetrunToMenu()
    {
        SceneManager.LoadScene("LevelSelector");
    }
}