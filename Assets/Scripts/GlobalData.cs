using UnityEngine;

public class GlobalData : SingletonMonobehaviour<GlobalData>
{
    [SerializeField] private LevelSO _currentLevelForTest;

    private PlayerBaseData _playerBaseData;
    private LevelData _currentLevel;
    private Wallet _coinsWallet;

    public PlayerBaseData PlayerBaseData => _playerBaseData;
    public LevelData CurrentLevel => _currentLevel;
    public Wallet CoinsWallet => _coinsWallet;

    protected override void Awake()
    {
        base.Awake();

        _playerBaseData = new PlayerBaseData()
        {
            baseHealth = 25,
            productionSpeed = 2f,
            startBonus = 0,
        };

        //TESTCODE
        if(_currentLevelForTest != null)
            _currentLevel = new LevelData(_currentLevelForTest);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _coinsWallet = new Wallet(ResourceType.Coins);
    }

    public void SetCurrentLevel(LevelData levelData)
    {
        if (levelData == null) return;

        _currentLevel = levelData;
    }
}