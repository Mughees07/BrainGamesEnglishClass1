using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : SingeltonBase<GameManager>
{


    public enum GameMode
    {
        CampaignMode,
        SurvivalMode
    }

    public enum GameState
    {
        INTRO,
        MAINMENU,
        CUTSCENE,
        GAMEPLAY,
        PAUSEMENU,
        SELECTIONMENU,
        LEVELSELECTION,
        PAUSED}

    ;

    public enum SoundState
    {
        HUMANKILLSOUND,
        BUTTONCLICKSOUND,
        MUTESOUND,
        UNMUTESOUND,
        MENUSOUND,
        LEVELCOMPLETIONSOUND,
        LEVELUPSOUND,
        LASTATTACKSOUND,
		TYPESOUND,
        STINGBOMBSOUND,
        PREYEATSOUND,
        PLAYERATTACKSOUND,
        DIGSOUND,
        PLAYERRUNSOUND,
        PLAYERDEATHSOUND,
        WATERSPLASHSOUND,
        PLAYERHEALTHDOWNSOUND,

        PREYATTACKSOUND,
        PREYDEATHSOUND,
        MUTEMUSIC,
        UNMUTEMUSIC,
        HITSOUND,
        UPGRADESOUND,
        THUNDERSOUND,
        RAINSOUND,
        NIGHTBGSOUND,
        GAMEPLAYSOUND,
        GUNSHOT,
        SCREAMSOUND,
        LEVELFAIL,
        GRABEATSOUND,
        PLAYEREATSOUND,
        PUNCHSOUND,
        STOMPSOUND,
        ROARSOUND,
        THUDSOUND,
        ALIENBULLET1,
        ALIENBULLET2,
        ALIENDEATH1,
        ALIENDEATH2,
        PLAYERHITSOUND,
        PLAYER_FIREBALL,
        ENEMY_FIREBALL,
        ROCKMAN_COMPLETION_SOUND,
        FIREGIRL_COMPLETION_SOUND,
        THUNDERMAN_COMPLETION_SOUND,
        FALLING_ROCK_SOUND,
        DOOR_OPENING_SOUND,

        NONE}

    ;

    private bool gameLaunch = true;
    private GameState previousGameState;
    private GameState currentGameState;

    public GameMode currentGameMode;

    private SoundState currentSoundState;
    private int RateUsCount = 0;

    public delegate void StateHandler(GameState state);

    public event StateHandler OnStateChange;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("GameManager").Length > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
	
    // Use this for initialization
    void Start()
    {	
//		UnityAdsHelper.Initialize ();
        UserPrefs.Load();

        if (!UserPrefs.firstTimeGameLaunch)
            UserPrefs.Save();

        Constants.AdsCounter = 0;

//		GAManager.Instance.LogDesignEvent("GameLaunch:Splash");		
		
        if (!UserPrefs.isSound)
        {
            SoundManager.Instance.MuteSound();
        }


        if (!UserPrefs.isMusic)
        {
            SoundManager.Instance.MuteMusic();
        }
    }

    #region StateHandler

    public GameState GetCurrentGameState()
    {
        return currentGameState;
    }

    public GameState GetPreviousGameState()
    {
        return previousGameState;
    }

    public SoundState GetSoundState()
    {
        return currentSoundState;
    }

    public  void SetGameState(GameState state)
    {
        previousGameState = currentGameState;
        currentGameState = state;
    }

    private void SetSoundState(SoundState state)
    {
        currentSoundState = state;
    }

    void InstRateUs()
    {
        Instantiate(Resources.Load("uGUIMenus/RateUsConfirmation"));
    }

    public void ChangeState(GameState state)
    {
		
        if (RateUsCount == 2 && state == GameState.MAINMENU && !UserPrefs.isRatesUS)
        {
            RateUsCount = 0;
        }
	
        switch (state)
        {
            case GameState.INTRO:
                LoadLoadingScreen(1);
                break;
            case GameState.MAINMENU:
                LoadLoadingScreen(1);
                break;
        }
    }

    public void ChangeState(SoundState soundState, GameState gameState)
    {
        ChangeState(gameState);
    }

    #endregion

	
    #region IAPs

    public void PurchasePackage(string package)
    {
        //Debug.LogError(package);
        /*StoreManager.Instance.PurchasePackage (package);
		GAManager.Instance.LogDesignEvent ("Store:IAP:Try:" + GetPackagePrice (package));*/
    }

    public void Restore()
    {
/*		StoreManager.Instance.RestoreCompletedTransactions ();
*/
    }

    #endregion

	
	

    #region Coins Collection

    public void AddCoins(int coins)
    {

        UserPrefs.totalGems += coins;
        UserPrefs.Save();
    }

    public void AddGems(int gems)
    {
        
        UserPrefs.Save();
    }

    public void SubtractCoins(int coins)
    {
        //Debug.LogError("Coins usb" +coins);
        UserPrefs.totalGems -= coins;
        UserPrefs.Save();
    }

    public void SubtractGems(int gems)
    {
        //Debug.LogError("Coins usb" +coins);
        UserPrefs.totalGems -= gems;
        UserPrefs.Save();
    }

    public void PurchaseProductResult(string package, bool result, string purchaseData, string signature)
    {
       
		
	
        
    }

    #endregion

    #region GameAnalatics

    private void LogGAEvent(string package, bool result, string purchaseData, string signature)
    {
		
        if (result)
        {
//			GAManager.Instance.LogBusinessEvent(package,"USD",GetPackagePrice(package));			
            GAManager.Instance.LogBusinessEvent(GetPackagePrice(package), Constants.CURRENCY_TYPE, Constants.ITEM_ID, purchaseData, signature);
			
			
        }
        else
        {
            GAManager.Instance.LogDesignEvent("Store:IAP:Fail:" + GetPackagePrice(package));
        }
    }

    private void LogResourceEvent(string packageID)
    {

        int purchasedGems = 0;
        int purchasedCoins = 0;
        if (packageID == Constants.PACKAGE_1)
        {
            purchasedGems = Constants.PACKAGE_1_GEMS_AMOUNT;
            purchasedCoins = Constants.PACKAGE_1_COINS_AMOUNT;
        }
        else if (packageID == Constants.PACKAGE_2)
        {
            purchasedGems = Constants.PACKAGE_2_GEMS_AMOUNT;
            purchasedCoins = Constants.PACKAGE_2_COINS_AMOUNT;
        }
        else if (packageID == Constants.PACKAGE_3)
        {
            purchasedGems = Constants.PACKAGE_3_GEMS_AMOUNT;
            purchasedCoins = Constants.PACKAGE_3_COINS_AMOUNT;
        }
        else if (packageID == Constants.PACKAGE_4)
        {
            purchasedGems = Constants.PACKAGE_4_GEMS_AMOUNT;
            purchasedCoins = Constants.PACKAGE_4_COINS_AMOUNT;
        }
        else if (packageID == Constants.PACKAGE_5)
        {
            purchasedGems = Constants.PACKAGE_5_GEMS_AMOUNT;
            purchasedCoins = Constants.PACKAGE_5_COINS_AMOUNT;

        }
        else if (packageID == Constants.PACKAGE_VGP)
        {
            purchasedGems = Constants.PACKAGE_VGP_GEMS_AMOUNT;
            purchasedCoins = Constants.PACKAGE_VGP_COINS_AMOUNT;

        }
    }

    private int GetPackagePrice(string package)
    {
		
        int price = 0;
		
        if (package == Constants.PACKAGE_1)
        {
            price = 99;
        }
        else if (package == Constants.PACKAGE_2)
        {
            price = 99;
        }
        else if (package == Constants.PACKAGE_3)
        {
            price = 299;
        }
        else if (package == Constants.PACKAGE_4)
        {
            price = 499;
        }
        else if (package == Constants.PACKAGE_5)
        {
            price = 999;
        }
        else if (package == Constants.PACKAGE_VGP)
        {
            price = 799;
        }
        return price;
    }

    #endregion

	
    public void AddTime(float time)
    {
        //Debug.Log("asdjfhasdjkfaksfhjkasdhf");
        GameObject.FindWithTag("Thumb").SendMessage("AddTime", time, SendMessageOptions.RequireReceiver);		
    }

    public void ShowTime(int price)
    {
        //Debug.Log("asdjfhasdjkfaksfhjkasdhf");
        GameObject.FindWithTag("TimerText").SendMessage("ScaledTimerText", price, SendMessageOptions.RequireReceiver);
		
    }

    public void LoadLoadingScreen(int LevelID)
    {
        if (GameManager.Instance.currentGameState == GameState.MAINMENU)
            GAManager.Instance.LogDesignEvent("GamePlay:Loading");

        if (UserPrefs.isSound)
        {
            SoundManager.Instance.MuteSound();
        }

        Instantiate(Resources.Load(Constants.LoadingUi));
        StartCoroutine(LoadLevel(LevelID));
    }

    IEnumerator LoadLevel(int ID)
    {
        //Application.LoadLevel(ID);
        AsyncOperation operation = SceneManager.LoadSceneAsync(ID);
        // AsyncOperation operation = Application.LoadLevelAsync(ID);
        GameObject.FindGameObjectWithTag("Loading").GetComponentInChildren<SpinnerController>().SetOperation(operation);
        yield return new WaitForSeconds(0.5f);
    }

    public void SaveNextLevel(int currentLevel)
    {
        if (currentLevel == UserPrefs.currentLevel)
        {
            UserPrefs.currentLevel += 1;
            UserPrefs.Save();
        }
    }

    public void LevelFail()
    {
        if (!GameObject.FindWithTag(Tags.LevelFail))
        {
            GAManager.Instance.LogDesignEvent("GamePlay:LevelFailed:" + (Constants.selectedLevel + 1));

            if (GameObject.FindWithTag(Tags.MenuBar))
                GameObject.FindWithTag(Tags.MenuBar).SetActive(false);
			
//            if (GameObject.FindWithTag(Tags.Joystick))
//                GameObject.FindWithTag(Tags.Joystick).SetActive(false);
            if ((Constants.selectedLevel + 1) % 3 == 2)
            {
                Variables.isLevelComplete = false;
//                AdsManager.Instance.ShowLevelEndOrCategoryAdOnFail();


            }
            else
                Instantiate(Resources.Load(Constants.LevelFail));
            Time.timeScale = 0;
        }
    }

    public void Revive()
    {
        if (!GameObject.FindWithTag(Tags.Revive))
        {
            GAManager.Instance.LogDesignEvent("GamePlay:Revive:" + (Constants.selectedLevel + 1));

//			if(GameObject.FindWithTag(Tags.MenuBar))
//				GameObject.FindWithTag(Tags.MenuBar).SetActive(false);
//			
//			if(GameObject.FindWithTag(Tags.Joystick))
//				GameObject.FindWithTag(Tags.Joystick).SetActive(false);

            Instantiate(Resources.Load(Constants.Revive));
            Time.timeScale = 0;
        }
    }

}

