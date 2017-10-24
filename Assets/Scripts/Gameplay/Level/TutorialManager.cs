using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{

	public GameObject raceButton;
    public enum TutorialState
    {
        StoryStart,  
        RaceButton,       
        BoostAttack,
		HealthBar,
        SwitchToCar,
		SwitchToRickshaw,
        StoryEnd,
	};

    public TutorialState _currentTutorialState;  
    public Text TutorialTxt;
    public int Number = 0;
    public GameObject[] TutorialPanels;
	public Text storyPopUp;

	public float delay = 0.5f;
	public string fullText;

	public GameObject TyreFlat;
	public GameObject FeulEnd;
	public GameObject MrsShahid;
	public GameObject Sister;
    void Start()
    {
        //UserPrefs.Load();

		ShowTutorial (TutorialState.StoryStart);
		Debug.Log("tutorial status : " + UserPrefs.isTutorialFinished);
    }

    public void HideTutorialPanels()
    {
		foreach (GameObject g in TutorialPanels)
			g.SetActive(false);

		MrsShahid.SetActive(false);
		FeulEnd.SetActive(false);
		TyreFlat.SetActive(false);
		Sister.SetActive(false);


    }

	public void showCutScene()
	{
		GameManager.Instance.LoadLoadingScreen(Constants.CutScene);
	}
	public void showControls()
	{
		References.Instance.raceButton.SetActive (true);
		References.Instance.boostButton.SetActive (true);
	}


	IEnumerator ShowText(string desc)
	{
		Debug.Log ("StateShowText:" + _currentTutorialState);
		
		for(int i = 0; i <=desc.Length ; i++)
		{ 
			TutorialTxt.text = desc.Substring (0,i);
			yield return new WaitForSeconds(delay);
			if(i%3==0)
				SoundManager.Instance.PlaySound(GameManager.SoundState.TYPESOUND);
		}
		yield return new WaitForSeconds(2f);



		if (_currentTutorialState == TutorialState.StoryStart ||
			_currentTutorialState == TutorialState.StoryEnd ||
			_currentTutorialState == TutorialState.SwitchToCar ||
			_currentTutorialState == TutorialState.SwitchToRickshaw)
			References.Instance.imageFade.enabled = true;

		yield return new WaitForSeconds(1f);
		HideTutorialPanels ();
		if (Number == 0) {
			showControls ();
			References.Instance.vehicleSelector.SelectBus ();
		}
		//else
			

		if (_currentTutorialState == TutorialState.StoryStart) {
			References.Instance.boostButton.SetActive (false);
			NextTutorial (_currentTutorialState);
			ShowTutorial (_currentTutorialState);
		}
		else if (_currentTutorialState == TutorialState.SwitchToCar) {
			References.Instance.vehicleSelector.SelectCar ();
			NextTutorial (_currentTutorialState);
		}else 	if (_currentTutorialState == TutorialState.SwitchToRickshaw) {
				References.Instance.vehicleSelector.SelectRickshaw ();
				NextTutorial (_currentTutorialState);
		}else 	if (_currentTutorialState == TutorialState.StoryEnd)
		{
			References.Instance.player.GetComponent<PlayerCollisionManager> ().ShowLevelCompletePopup ();

			//yield return new WaitForSeconds (1f);			
			//if (_currentTutorialState == TutorialState.StoryStart)
			//	ShowTutorial (TutorialState.RaceButton);
		}
	}

	int tutorialCount;
    void showText()
    {
		Debug.Log ("StateShow:" + _currentTutorialState);
        foreach (GameObject g in TutorialPanels)
            g.SetActive(false);

		if (_currentTutorialState.Equals (TutorialState.HealthBar))
			Number = 3;
		else if (_currentTutorialState.Equals (TutorialState.BoostAttack))
			Number = 2;
		else if (_currentTutorialState.Equals (TutorialState.RaceButton))
			Number = 1;
		else {
			Number = 0;
			References.Instance.raceButton.SetActive (false);
			References.Instance.boostButton.SetActive (false);

		}

        TutorialPanels[Number].SetActive(true);
        TutorialTxt = TutorialPanels[Number].GetComponentInChildren<Text>();
		if (_currentTutorialState == TutorialState.RaceButton) {			
			TutorialTxt.text = Constants.TutorialText[tutorialCount++];
			NextTutorial (_currentTutorialState);
		}
		else if (_currentTutorialState == TutorialState.BoostAttack )
			TutorialTxt.text = Constants.TutorialText[tutorialCount++];
		else
			StartCoroutine (ShowText (Constants.TutorialText[tutorialCount++]));
		
        GAManager.Instance.LogDesignEvent("Tutorial:Step:" + Number);

//        switch (_currentTutorialState)
//      {
//        case TutorialState.StoryStart:
//                TutorialTxt.text = Constants.TutorialText[0];
//                break;
//		case TutorialState.RaceButton:
//                TutorialTxt.text = Constants.TutorialText[1];
//                break;
//		case TutorialState.BoostAttack:
//                TutorialTxt.text = Constants.TutorialText[2];               
//                break;
//		case TutorialState.HealthBar:
//                TutorialTxt.text = Constants.TutorialText[3];
//                break;
//		case TutorialState.SwitchToCar:
//                TutorialTxt.text = Constants.TutorialText[4];
//                break;
//		case TutorialState.SwitchToRickshaw:
//                TutorialTxt.text = Constants.TutorialText[5];               
//                break;
//		case TutorialState.StoryEnd:
//				TutorialTxt.text = Constants.TutorialText[6];
//				break;
//        }


    }


	public void NextTutorial(TutorialState _current)
	{
		Debug.Log ("State:" + _currentTutorialState);
		switch (_current)
		{

		case TutorialState.StoryStart: 
			_currentTutorialState = TutorialState.RaceButton;
			break;

		case TutorialState.RaceButton:  
			_currentTutorialState = TutorialState.BoostAttack;		
			break;

		case TutorialState.BoostAttack: 
			_currentTutorialState = TutorialState.SwitchToCar;
			break;		

		case TutorialState.SwitchToCar:
			_currentTutorialState = TutorialState.SwitchToRickshaw;
			break;

		case TutorialState.SwitchToRickshaw:
			_currentTutorialState = TutorialState.StoryEnd;	        
			break;

		case TutorialState.StoryEnd:
			_currentTutorialState = TutorialState.StoryStart;
			break;
		}
	}

    public void ShowTutorial(TutorialState _current)
    {
		Debug.Log ("State:" + _currentTutorialState);
        switch (_current)
        {

		case TutorialState.StoryStart: 
			MrsShahid.SetActive(true);
			showText();
            break;
          
		case TutorialState.RaceButton:  
			showText();
            break;

		case TutorialState.BoostAttack: 			
			showText();
            break;	

		case TutorialState.SwitchToCar:
			TyreFlat.SetActive(true);
			showText();
			break;

		case TutorialState.SwitchToRickshaw:
			FeulEnd.SetActive(true);
			showText();			        
			break;

		case TutorialState.StoryEnd:
			Sister.SetActive(true);
			showText();
			break;
        }
    }
}
