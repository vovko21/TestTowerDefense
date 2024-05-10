public class GlobalData : SingletonMonobehaviour<GlobalData>
{
    private LevelData _currentLevel;
    private Wallet _coinsWallet;

    public LevelData LevelData => _currentLevel;
    public Wallet CoinsWallet => _coinsWallet;

    protected override void Awake()
    {
        base.Awake();

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