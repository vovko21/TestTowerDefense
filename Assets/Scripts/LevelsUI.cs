using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelsUI : MonoBehaviour
{
    [SerializeField] private List<LevelUI> _levelsUI;

    private void Start()
    {
        GlobalData.Instance.InitializeLevels(_levelsUI.Select(x => x.LevelSO).ToList());

        foreach (var levelUI in _levelsUI)
        {
            var levelData = GlobalData.Instance.GetLevelById(levelUI.LevelSO.Id);

            levelUI.SetSprite(levelData.IsCompleted);
        }
    }
}