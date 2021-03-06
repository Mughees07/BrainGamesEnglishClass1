﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ModeSelectionManager : MonoBehaviour
{

    // Use this for initialization
    public GameObject SurvivalModeLocked;

    public void Start()
    {
        if (UserPrefs.IsSurvivalModeUnlocked)
        {
            SurvivalModeLocked.SetActive(false);
        }
    }

    public void OnCampaignModeClick()
    {

        GAManager.Instance.LogDesignEvent("ModeSelection:CareerMode");
        SoundManager.Instance.PlaySound(GameManager.SoundState.BUTTONCLICKSOUND);
        GameManager.Instance.currentGameMode = GameManager.GameMode.CampaignMode;
        LoadLevelSelection();

    }

    public void OnSurvivalModeClick()
    {
        GAManager.Instance.LogDesignEvent("ModeSelection:SurvivalMode");
        SoundManager.Instance.PlaySound(GameManager.SoundState.BUTTONCLICKSOUND);
        if (UserPrefs.IsSurvivalModeUnlocked)
        {
            GameManager.Instance.currentGameMode = GameManager.GameMode.SurvivalMode;
            Constants.selectedLevel = 24;
            GameManager.Instance.LoadLoadingScreen(Constants.GamePlay);
        }
        else
        {
            Instantiate(Resources.Load(Constants.LockedSurvivalMode));
        }
    }

    void LoadLevelSelection()
    {
        Instantiate(Resources.Load(Constants.LevelSelectionMenu));
        Destroy(gameObject);
    }

    public void OnButtonPress(string ID)
    {
        SoundManager.Instance.PlaySound(GameManager.SoundState.BUTTONCLICKSOUND);
        switch (ID)
        {
            case "Back": 
                
                Instantiate(Resources.Load(Constants.MainMenuUI));

                Destroy(gameObject);
                break;
        }		

    }

    public void BackButton()
    {

        if (GameObject.FindWithTag(Tags.ModeSelectionMenu) && !GameObject.FindWithTag(Tags.LockedLevelScriptCoinVideo) && !GameObject.FindWithTag(Tags.NoMoreAd))
        {
            OnButtonPress("Back");
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            BackButton();
        }
    }
}
