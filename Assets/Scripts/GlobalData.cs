using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GlobalData : SingletonMonobehaviour<GlobalData>
{
    [SerializeField] private LevelSO _currentLevelForTest;
    [SerializeField] private bool _debug;

    private List<LevelData> _allLevels;
    private PlayerBaseData _playerBaseData;
    private LevelData _currentLevel;
    private Wallet _coinsWallet;

    public PlayerBaseData PlayerBaseData => _playerBaseData;
    public LevelData CurrentLevel => _currentLevel;
    public Wallet CoinsWallet => _coinsWallet;

    protected override void Awake()
    {
        base.Awake();

        _playerBaseData = new PlayerBaseData();
        _allLevels = new List<LevelData>();
        _coinsWallet = new Wallet(ResourceType.Coins);

        //CODE FOR TESTING
        if(_debug)
            _currentLevel = new LevelData(_currentLevelForTest);

        DontDestroyOnLoad(gameObject);
    }

    public void InitializeLevels(List<LevelSO> levelsSO)
    {
        foreach (var levelSO in levelsSO)
        {
            _allLevels.Add(new LevelData(levelSO));
        }
    }

    public LevelData GetLevelById(string id)
    {
        return _allLevels.FirstOrDefault(x => x.LevelSO.Id == id);
    }

    public void SetCurrentLevel(LevelSO levelSO)
    {
        if (levelSO == null) return;

        var level = GetLevelById(levelSO.Id);

        if (level == null) return;

        _currentLevel = level;
    }
}