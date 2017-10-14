using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{

    // For Setting Panel
    public bool isSettingPanel;
    public GameObject Music, Sound;
    public Sprite MusicEnable, MusicDisable, SoundEnable, SoundDisable;
    // End Setting Panel


    void Start()
    {
        if (gameObject.CompareTag(Tags.LevelComplete))
        {
            GameObject.FindGameObjectWithTag(Tags.LevelManager).GetComponent<StarsManager>().ShowStars();
        }

        if (isSettingPanel)
        {
            if (!UserPrefs.isSound)
            {
                Sound.GetComponent<Image>().sprite = SoundDisable;
                SoundManager.Instance.MuteSound();
            }
            else
            {
                Sound.GetComponent<Image>().sprite = SoundEnable;
                SoundManager.Instance.UnMuteSound();
            }

            if (!UserPrefs.isMusic)
            {
                Music.GetComponent<Image>().sprite = MusicDisable;
                SoundManager.Instance.MuteMusic();
            }
            else
            {
                Music.GetComponent<Image>().sprite = MusicEnable;
                SoundManager.Instance.UnMuteMusic();
            }
        }
        else
        {
            if (UserPrefs.isMusic)
            {
                SoundManager.Instance.muteMusicExceptEffectSource();
            }

            if (tag.Equals(Tags.LevelComplete) && Constants.selectedLevel.Equals(23))
            {
                transform.FindChild("BG/btn_Next").gameObject.SetActive(false);
                transform.FindChild("BG/btn_Home").GetComponent<RectTransform>().anchoredPosition = new Vector3(-175f, -159f, 0);
                transform.FindChild("BG/btn_Retry").GetComponent<RectTransform>().anchoredPosition = new Vector3(175f, -159f, 0);
            }
        }

        if (gameObject.CompareTag(Tags.LevelExit))
        {
            if (UserPrefs.isMusic)
            {
                SoundManager.Instance.muteMusicExceptEffectSource();
            }

        }


    }

    public void InappPurchaseText(int Amount)
    {
		
    }

    public void OnButtonPress(string ID)
    {
        SoundManager.Instance.PlaySound(GameManager.SoundState.BUTTONCLICKSOUND);
        switch (ID)
        {	
            case "Restart":

                Time.timeScale = 1f;

                //AdsManager.Instance.ShowAdOnLevelEnd();

//                GameObject.FindObjectOfType<UnityStandardAssets.CrossPlatformInput.Joystick>().OnDisable();

                GameManager.Instance.LoadLoadingScreen(Constants.GamePlay);

                if (UserPrefs.isMusic)
                {
                    SoundManager.Instance.UnMuteMusic();
                }

                if (UserPrefs.isSound)
                {
                    SoundManager.Instance.UnMuteSound();
                }
				
                break;
            case "Resume":
                Time.timeScale = 1f;
                GameObject.FindGameObjectWithTag("MenuBar").GetComponent<CanvasGroup>().alpha = 1;
                GameObject.FindGameObjectWithTag("MenuBar").GetComponent<CanvasGroup>().interactable = true;
//                GameObject.FindGameObjectWithTag(Tags.Joystick).transform.GetChild(0).gameObject.GetComponent<CanvasGroup>().alpha = 1;
             
                if (UserPrefs.isMusic)
                {
                    SoundManager.Instance.UnMuteMusic();
                }

                if (UserPrefs.isSound)
                {
                    SoundManager.Instance.UnMuteSound();
                }

                Destroy(gameObject);
                break;
            case "Next":
               // AdsManager.Instance.ShowAdOnLevelEnd();
                Constants.selectedLevel += 1;

//			if (GameManager.Instance.currentGameMode == GameManager.GameMode.CampaignMode) {
//				if ((Constants.selectedLevel >= 0 && Constants.selectedLevel < 4) ||
//				    (Constants.selectedLevel >= 8 && Constants.selectedLevel < 12) ||
//				    (Constants.selectedLevel >= 16 && Constants.selectedLevel < 20)) {
//					GameManager.Instance.LoadLoadingScreen (Constants.GamePlay);
//				} else {
//					GameManager.Instance.LoadLoadingScreen (Constants.secondEnvironment);
//				}
//			} else {
                GameManager.Instance.LoadLoadingScreen(Constants.GamePlay);
			//}



                if (UserPrefs.isMusic)
                {
                    SoundManager.Instance.UnMuteMusic();
                }

                if (UserPrefs.isSound)
                {
                    SoundManager.Instance.UnMuteSound();
                }
                break;
            case "Home":
               // AdsManager.Instance.ShowAdOnLevelEnd();
                Constants.selectedLevel = 0;

                Time.timeScale = 1f;


                if (UserPrefs.isMusic)
                {
                    SoundManager.Instance.UnMuteMusic();
                }

                if (UserPrefs.isSound)
                {
                    SoundManager.Instance.UnMuteSound();
                }
                GameManager.Instance.LoadLoadingScreen(Constants.MainMenu);
                break;
            case "HomeRevive":
			
                Destroy(gameObject);
                break;
            case "Sound": 
                if (UserPrefs.isSound)
                {
                    UserPrefs.isSound = false;
                    UserPrefs.Save();
                    Sound.GetComponent<Image>().sprite = SoundDisable;
                    SoundManager.Instance.MuteSound();
                }
                else if (!UserPrefs.isSound)
                {
                    UserPrefs.isSound = true;
                    UserPrefs.Save();
                    Sound.GetComponent<Image>().sprite = SoundEnable;
                    SoundManager.Instance.UnMuteSound();
                }
                break;
            case "Music": 
                if (UserPrefs.isMusic)
                {
                    UserPrefs.isMusic = false;
                    UserPrefs.Save();
                    Music.GetComponent<Image>().sprite = MusicDisable;
                    SoundManager.Instance.MuteMusic();
                }
                else if (!UserPrefs.isMusic)
                {
                    UserPrefs.isMusic = true;
                    UserPrefs.Save();
                    Music.GetComponent<Image>().sprite = MusicEnable;
                    SoundManager.Instance.UnMuteMusic();
                }
                break;
            case "Close":
                Destroy(gameObject);

                if (UserPrefs.isMusic)
                {
                    SoundManager.Instance.UnMuteMusic();
                }

                if (UserPrefs.isSound)
                {
                    SoundManager.Instance.UnMuteSound();
                }

                break;

            case "Enjoying":
                Instantiate(Resources.Load(Constants.RateUs));
                Destroy(gameObject);
                break;
            case "EnjoyingClose":
                ShowLevelCompletePopup();
                Destroy(gameObject);
                break;

            case "WatchVideo":
//			UnityAdsHelper.ShowAd (Constants.REWARDED_ADS_ID_ANDROID);

                //AdsManager.Instance.ShowRewardedVideo();
              
                GAManager.Instance.LogDesignEvent("LevelSelection:RewardedVideo");
                Destroy(gameObject);
                break;
            case "WatchVideoSurvival":
                UserPrefs.UnlockSurvivalMode = true;
//			UnityAdsHelper.ShowAd (Constants.REWARDED_ADS_ID_ANDROID);
               // AdsManager.Instance.ShowRewardedVideo();
                GAManager.Instance.LogDesignEvent("SurvivalMode:RewardedVideo");
                Destroy(gameObject);
//			UserPrefs.UnlockSurvivalMode = false;
//			UserPrefs.IsSurvivalModeUnlocked = true;
//			UserPrefs.Save ();
//			GameObject.FindGameObjectWithTag (Tags.ModeSelectionMenu).GetComponent <ModeSelectionManager> ().Start ();
                break;
            case "RevivePlayer":
                UserPrefs.RevivePlayer = true;
//			UnityAdsHelper.ShowAd (Constants.REWARDED_ADS_ID_ANDROID);
                //AdsManager.Instance.ShowRewardedVideo();

                GAManager.Instance.LogDesignEvent("GamePlayRevive:RewardedVideo");
                RevivePlayer();
                Destroy(gameObject);
                break;
            case "Policy":
                Application.OpenURL("https://docs.google.com/document/d/1e8PUHClO1cruy9XjFNUfCr2PrGl8KaRGc57Ur9KevXw/pub");
                break;
        }
		
    }



    void ShowLevelCompletePopup()
    {
        if (!GameObject.FindWithTag(Tags.LevelExit))
            Time.timeScale = 1;

        GAManager.Instance.LogDesignEvent("GamePlay:LevelComplete:" + (Constants.selectedLevel + 1));

        if ((Constants.selectedLevel + 1) % 3 == 2)
        {
           // AdsManager.Instance.ShowLevelEndOrCategoryAd();

        }
        else
            Instantiate(Resources.Load(Constants.LevelComplete));
    }

    public void BackButton()
    {
        if (GameObject.FindWithTag(Tags.LevelExit))
        {
            OnButtonPress("Resume");
        }

        if (GameObject.FindWithTag(Tags.Enjoying))
        {
            OnButtonPress("Close");
            ShowLevelCompletePopup();
        }

        if (GameObject.FindWithTag(Tags.LevelSettings))
        {
            OnButtonPress("Close");
        }

        if (GameObject.FindWithTag(Tags.LockedLevelScriptCoinVideo))
        {
            OnButtonPress("Close");
        }

        if (GameObject.FindWithTag(Tags.NoMoreAd))
        {
            OnButtonPress("Close");
        }



    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            BackButton();
        }
    }

    void RevivePlayer()
    {
        //   GameObject.FindObjectOfType<PlayerControl>().RevivePlayer();
    }

}
