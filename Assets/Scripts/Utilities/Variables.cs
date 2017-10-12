using UnityEngine;
using System.Collections;

public class Variables
{
	public static int points = 0;
	// Player Status
	public static bool inFight = false;
	public static bool isAttack = false;
	public static bool isGrabed = false;

	// Player Outfit Selection
	public static int currSelectionIndex = 0;
	public static int totalCats = 3;
	public static int totalHats = 5;
	public static int totalGlasses = 5;
	public static int totalShoes = 5;
	
	public static bool questSuccessful = true;

	public static bool RestorePurchases;
	public static bool EnableRestore;
	
	public static bool isAttackButtonPressed = false;

	// Outfit Related Status
	public static bool isHatOn = false;
	public static bool isGlassesOn = false;
	public static bool isShoesOn = false;
	
	// Collectible Related
	public static int bronzeCoinsCollected = 0;
	public static int goldCoinsCollected = 0;
	public static int platinumCoinsCollected = 0;
	public static int gemsCollected = 0;
	
	// Challenge Manager Status
	public static int areaID = 0;
	public static int currentChallengeArea = 0;
	// indicates the current challenge's location

	public static bool isChallengeOn = false;
	// indicates if challenge is active or not
	public static bool isChallenge1On = false;
	// indicates if challenge of Location 1 is active or not
	public static bool isChallenge2On = false;
	// indicates if challenge of Location 2 is active or not
	public static bool isChallenge3On = false;
	// indicates if challenge of Location 3 is active or not
	public static bool isChallenge4On = false;
	// indicates if challenge of Location 4 is active or not
	public static bool isChallenge5On = false;
	// indicates if challenge of Boy is active or not
	public static bool isChallenge6On = false;
	// indicates if challenge of Dolphin is active or not
	public static bool isTutorialOn = false;
	// indicates if tutorial is active or not

	public static bool isPaused = false;
	public static bool hintActive = false;
	public static bool hasPlayerMoved = false;

	// Camera Parameters During Gameplay
	public static float cameraDistance = 4.5f;
	public static float cameraHeight = 0;

	// Sub Menus Status
	public static bool isBtnRestoreSource = false;

	// Gameplay Specific Status
	public static bool isEnemyHealthBarShowing = false;
	public static bool isPlayerHealthBarShowing = false;

	public static int currentMissionCount = 0;

	// Game Manager Status
	public static int currentPackageCoins = 0;
	public static int currentPackageGems = 0;
	public static int rateCount = 0;
	public static bool neverRateUs = false;
	public static bool isRatesUS = false;
	public static bool challengeState = false;
	public static bool timeOut = false;
	public static bool isLevelComplete = false;
	public static bool isLevelFail = false;
	public static bool isLevelEnd = false;
	// regardless the level completes or fails
	public static bool isCoinReward = false;
	public static bool isPlayerUnlock = false;
	public static bool playerUnlock = false;
	public static bool unlockLevelByVideo = false;
	// Twitter Integration
	public static string tweetText = string.Empty;
	public static bool tutorialEnd = false;
	// Ads Related Status
	public static bool isAdShowing = false;
	public static int selectedChallengeID = 0;
	
	// Integration Related
	public static bool loggedInGPG = false;
	
	public static int repetition = 0;
	public static int repetitionFire = 0;


	#region Tapdaq

	public static bool isRewardedVideoLoaded;
	public static bool isVideoLoaded;

	#endregion

	public static void Reset ()
	{

		//Umar:Player Data

		//	playerID = 0;
		currSelectionIndex = 0;
		totalCats = 3;
		totalHats = 5;
		totalGlasses = 5;
		totalShoes = 5;

		questSuccessful = true;

		// Outfit Related Status
		isHatOn = false;
		isGlassesOn = false;
		isShoesOn = false;

		// Collectible Related
		bronzeCoinsCollected = 0;
		goldCoinsCollected = 0;
		platinumCoinsCollected = 0;
		gemsCollected = 0;

		// Challenge Manager Status
		areaID = 0;
		currentChallengeArea = 0;		// indicates the current challenge's location

		isChallengeOn = false;		// indicates if challenge is active or not
		isChallenge1On = false;		// indicates if challenge on Location 1 is active or not
		isChallenge2On = false;		// indicates if challenge on Location 2 is active or not
		isChallenge3On = false;		// indicates if challenge on Location 3 is active or not
		isChallenge4On = false;		// indicates if challenge on Location 4 is active or not
		isChallenge5On = false;		// indicates if challenge of Puppty is active or not
		isChallenge6On = false;		// indicates if challenge of Kitten is active or not

		isPaused = false;
		hintActive = false;

		// Camera Parameters During Gameplay
		cameraDistance = 4.5f;
		cameraHeight = 0; 

		// Game Manager Status
		currentPackageCoins = 0;
		currentPackageGems = 0;
		rateCount = 0;
		neverRateUs = false;
		isRatesUS = false;
		challengeState = false;
		timeOut = false;
		
		// Twitter Integration
		tweetText = string.Empty;

		// Ads Related Status
		isAdShowing = false;
		selectedChallengeID = 0;

		// Integration Related
		loggedInGPG = false;
	}
}