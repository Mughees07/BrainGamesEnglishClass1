using UnityEngine;
using System.Collections;
using System;

public class Constants
{
	
    public const string INAPP_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtqvaxZ1Z2hAEompwpBgNA4Pc3ASF4/4ANMc2Fqsi5KiguXD8rmnIJN2XN0iDX0haCeFFlEowc/p1oN2FM0QYkI23Zhj0Q9+YPFyogPWyhLNo3ddRbTaCZM6pRdIUd0MnxikwQj+Zi4pNTC/KPM8xOr+jDMtrNVE9ck1g//hM4DMlDJPcA+SF4ZrcREg3w6g746IFcJe/NKe7K3Mw8jBzQxhNW7I9uIVVutRUHC9vPnOB2irtxfvjsPfS8VYsa7yPoJa+9Yijz5Akya7nBr4Mq5lm/Ut0lDjkCG4eowsy0W+5/kzCVJvIdEr+lQnni2zVgegwZ+LRulfUQRAAyxduAwIDAQAB";
		
		
    // Consumable In-apps. GN stand for Game Name
	
    public const string INAPP_CURRENCY = "USD";
    public const string CURRENCY_TYPE = "Coin";
    public const string CURRENCY_TYPE_COIN = "COINS";
    public const string CURRENCY_TYPE_GEMS = "GEMS";
	
    public const string ITEM_ID = "Coin";
	
    public const string PACKAGE_1 = "android.test.purchased";
    public const string PACKAGE_2 = "com.tapinator.mermaid.coins2500gems8";
    //"com.tapinator.hsj.coins2500";
    public const string PACKAGE_3 = "com.tapinator.mermaid.coins6500";
    public const string PACKAGE_4 = "com.tapinator.mermaid.gems35";
    public const string PACKAGE_5 = "com.tapinator.mermaid.coins7500gems45";
    public const string PACKAGE_VGP = "com.tapinator.mermaid.vgpseatreasure";

    public const string PACKAGE_UNLOCK_ALL_PLAYERS = /*"android.test.purchased";*/	 "com.tapinator.ultimate.monster.unlockall";


    public const int PACKAGE_1_COINS_AMOUNT = 2000;
    public const int PACKAGE_2_COINS_AMOUNT = 2500;
    public const int PACKAGE_3_COINS_AMOUNT = 6000;
    public const int PACKAGE_4_COINS_AMOUNT = 0;
    public const int PACKAGE_5_COINS_AMOUNT = 7500;
    public const int PACKAGE_VGP_COINS_AMOUNT = 7500;

    public const int PACKAGE_1_GEMS_AMOUNT = 0;
    public const int PACKAGE_2_GEMS_AMOUNT = 8;
    public const int PACKAGE_3_GEMS_AMOUNT = 0;
    public const int PACKAGE_4_GEMS_AMOUNT = 35;
    public const int PACKAGE_5_GEMS_AMOUNT = 45;
    public const int PACKAGE_VGP_GEMS_AMOUNT = 45;


    #region AdNetworks

    public const string INTERSTITIAL_ID_ANDROID = "480ad52e94f646e2b66e34a77317c849";
    // Mobup ID
    public const string VIDEO_ID_ANDROID = "5f55cc84545445c8a880537adbea3af4";
    //Video ads key
    public const string REWARDED_VIDEO_KEY_ANDROID = "5f55cc84545445c8a880537adbea3af4";
    public const string CROSSPROMOTION_ID_ANDROID = "ca-app-pub-8370919864033934/7299661207";

    public const string INTERSTITIAL_ID_IOS = "975c6d9bc2584ca69006b9871a51f9c1";
    // Mobup ID
    public const string VIDEO_ID_IOS = "14b2aed234734aabb74c91ce3af08f3c";
    public const string CROSSPROMOTION_ID_IOS = "ca-app-pub-8370919864033934/5683327206";

	

    public const string BANNER_ID_IOS = "";
    // BANNER AD
    public const string BANNER_ID_ANDROID = "";
    // BANNER AD

    public const string REWARDED_ADS_ID_ANDROID = "rewardedVideo";
	
    public const string REWARDED_ADS_ID_IOS = "rewardedVideo";

    #endregion

    // menus Constants
    public const string twitter_consumer_key = "pqZQU7ASRJMQ55TbdAY4tY9N4";
    public const string twitter_secret_key = "B1Dt3dUkwJsvlNQPGASX6PKRNpgL7XnMR3IIDhtZnwVhSLhsyq";
	public const string	GAME_BUNDLE_ID = "com.toptap.grand.robotfighting";

	public const string FACEBOOK_LINK = "https://www.facebook.com/Top-TAP-Games-1884789665074780/";
	public const string TWITTER_LINK = "https://twitter.com/TopTapGames";
    public const string MoreGames_LINK = "https://play.google.com/store/apps/developer?id=Tapinator,+Inc.+(Ticker:+TAPM)&hl=en";

    public const string AMAZON_RATEUS_LINK = "amzn://apps/android?p=com.tapinator.furiousmom";
    public const string iOS7AppStoreURLFormat = "itms-apps://itunes.apple.com/app/id992026901?at=10l6dK";
    public const string iOSAppStoreURLFormat = "itms-apps://ax.itunes.apple.com/WebObjects/MZStore.woa/wa/viewContentsUserReviews?type=Purple+Software&id=992026901";
	public const string ANDROID_RATEUS_LINK = "market://details?id="+GAME_BUNDLE_ID;

    public const int COINS_TO_SKIP_LEVEL = 200;
    // 50 coins to skip level.
    public const int COINS_BONUS_TO_WATCH_AD = 200;
    public const int LEVEL_COMPLETE_REWARD = 50;
    // 30 coins
    public const string SCENE_PLUGINS = "Plugins";
    public const string SCENE_MENU = "MenuScene";
    //DinoMenuScene
    public const int levelsPerEpisode = 24;
		
    public const string PUBLISHER_ID = "6bd06b98f1a55b1b2f4df12b50869820";

    public const string ANDROID_APP_TOKEN_PLAY_HAVEN = "e7a124642d7e4c72a992b44aabb3a223";
    public const string ANDROID_APP_SECRET_PLAY_HAVEN = "dcffaf4460044ef7b792d521ef826b33";
    public const string IOS_APP_TOKEN_PLAY_HAVEN = "1c30f81d871d4f42a61cc5fe7a2a8f89";
    public const string IOS_APP_SECRET_PLAY_HAVEN = "3c99f298ac1e44fa8fbc0081ab4b9117";

    /*************************PLAYER RELATED CONSTANTS*************************/
    // Player IDs
    public const int T_REX_ID = 0;
    public const int VELOCIRAPTOR_ID = 1;
    public const int SPINOSAURUS_ID = 2;

    // Player Related Objects
    public const string EMPTY_BODY = "EmptyBody";
    public const string SPELL_CAST_BODY = "SpellCastBody";
    public const string CAMERA_COLLIDER = "CameraCollider";

    //Player Attributes
    public const int PLAYER_TOTAL_HEALTH = 20;
    /**************************************************************************/

    // Ads Check;
    public static int AdsCounter;

    // Enemy Related Parameters
    public const int VISIBLE_RANGE = 60;
    public const int DETECTION_RANGE = 40;
    public const int ATTACK_RANGE = 20;
	

    // Environment Related Objects
    public const string DEFAULT_SPAWN_POS = "DefaultPosition";

    //ResourcesPath
    public const string MainPlayer = "Player/MainPlayer";
    public const string rippleEffectBlue = "Effects/RippleWallBlue";
    public const string rippleEffectBrown = "Effects/RippleWallBrown";
    public const string rippleEffectGrey = "Effects/RippleWallGrey";
    public const string exitWallEffect = "Effects/ExitHitEffect";
	public const string exitWallLevelEndEffect = "Effects/SparkFenceEffect";
    //	public const string[] MainPlayers = {""}

    //Resources Menu Referance
    public const string LevelComplete = "uGUIMenus/LevelComplete";
    public const string LevelFail = "uGUIMenus/LevelFail";
    public const string LoadingUi = "uGUIMenus/Loading";
    public const string PlayerSelectionMenu = "uGUIMenus/PlayerSelectionMenu";
    public const string LevelSelectionMenu = "uGUIMenus/LevelSelectionMenu";
    public const string ModeSelectionMenu = "uGUIMenus/ModeSelectionMenu";
    public const string LevelSettings = "uGUIMenus/LevelSettings";
    public const string PauseMenu = "uGUIMenus/PauseMenu";
    public const string MainMenuUI = "uGUIMenus/MainMenu";
    public const string LockedLevelSkipCoinVideo = "uGUIMenus/LockedLevelSkipCoinVideo";
    public const string LockedPlayer = "uGUIMenus/LockedPlayer";
    public const string LockedSurvivalMode = "uGUIMenus/LockedSurvivalMode";
    public const string Enjoying = "uGUIMenus/Enjoying";
    public const string RateUs = "uGUIMenus/LevelRateUs";
    public const string SucessfullyUnlocked = "uGUIMenus/SucessfullyUnlocked";
    public const string Revive = "uGUIMenus/Revive";

    // Menu IDs
    public const int Intro = 0;
    public const int MainMenu = 1;
    public const int CutScene = 2;
    public const int GamePlay = 2;
    public const int secondEnvironment = 4;


    public static int selectedLevel = 0;
    public static bool isLevelComplete = false;

    public static string[] MissionBriefing = new string[]
    {"Fight and kill this guard to explore first island.", //Level 1
        "You need a shelter. Kill the guards and take the cottage.",//Level 2
        "Cross the Skeldergate bridge and enter the Wutong village, Beware of the Shortage dwarves guarding the bridge.", //Level 3
        "Caracul forces have occupied the village. Teach them a lesson.", //Level 4
        "Explore the map. Find new powerful Dracolatus sword and kill dwarves!", //Level 5
        "Kill these three Knights to reach to the next Island!",//Level6
        "Clear this wooden farm house from Orcs to take shelter for the night!", //Level7
        "Leo is hungry. Find food in this farm house to gain energy. Be safe from the dwarves!",//Level8
        "Continue your journey and kill these gatekeepers to enter into the next Island.",//Level9
        "Kill Dwarves and Goblins to capture both farm houses for shelter and water!",//Level10
        "Move towards Goodram Gate and kill Stoneshield Skulls coming on your way.", //Level11
        "Fight and kill these guards to cross Goodram Gate, then you will be entered into next island.",//Level12
        "Enemies are increasing in number. You need to increase your weapon power. Save yourself from Knights and find a Halberd to kill them.",//Level13
        "Forts of St.George are captured by Silverbeard Wizards. Clear the area by killing these Wizards and spend the night in fort.",//Level14
        "Cross Bishops Bridge that connects the two Islands and kill enemies coming on the way.",//Level15
        "Going good! You have cleared five islands. Find food, do some rest and get ready for the next battles.",//Level16
        "Clear your area by killing Stoneshield dwarves army. They are tiny but powerful.",//Level17
        "Make your path towards Red tower by fighting with Knights army. Cross the gate to enter into next island.",//Level18
        "You are near to your destination. Kill Orcs, Goblins and Skulls coming in your way.",//Level19
        "Littledigger dwarves are protecting this zone. Fight and kill them to move forward.",//Level20
        "You have to cross this last bridge to enter into final island. Fight with this Knights army to clear your way.",//Level21
        "You have entered into your final zone. Fight with gateguards to make your way towards gate of the castle.",//Level22
        "Congratulations! You have entered into castle. Fight with troops of wizards and clear the castle.",//Level23
        "Princess is captured inside this castle. Fight with these gaint Bosses patrolling on door."//Level24
    };
    public static string[] TutorialText = new string[]
    {"Use the Joystick to move",
        "Swipe left/right to move the Camera",
        "Use Combo and Mega Attack buttons to execute different combinations of attacks",
        "Go near emeny and use Attack button to attack",
        "Press and Hold Block button to defend against the attacks",
        "Use Combo Attack to kill your enemies in one shot.",
        "Keep an eye on your health.",
        "Use Pause button to pause the game"
    };
    public static string[] StoryLine = new string[]
    {
        "Tony Accardo is tired of his crooked life and has decided to start a new, honest life. He is trying to escape but his gang members have surrounded him from all sides. Now he has to fight with them in order to start a new life !",
        "Swipe left right to move Camera",
        "Use Sprint Button to run fast",
        "Use Jump Button to jump",
        "Use Attack Button to attack your enemy",
        "Use Defend Button to block attack",
        "Use Power Button to Power attack on enemy",
        "You have entered into final zone.Brace yourself for huge wars. "
    };

    public static String[] PlayerNames = { "Cristie", "Britni", "Lina", "Anna", "Jenifer", "Angela" };

    public static string _playerName = "";
}