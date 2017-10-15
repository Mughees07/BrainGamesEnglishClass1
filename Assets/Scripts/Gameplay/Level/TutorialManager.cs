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

	public float delay = 0.01f;
	public string fullText;

    void Start()
    {
        UserPrefs.Load();

		ShowTutorial (TutorialState.StoryStart);
		Debug.Log("tutorial status : " + UserPrefs.isTutorialFinished);
    }

    public void HideTutorialPanels()
    {
		foreach (GameObject g in TutorialPanels)
			g.SetActive(false);
    }

	IEnumerator ShowText(string desc)
	{
		Debug.Log ("StateShowText:" + _currentTutorialState);
		
		for(int i = 0; i <=desc.Length ; i++)
		{ 
			TutorialTxt.text = desc.Substring (0,i);
			yield return new WaitForSeconds(delay);
		}
		yield return new WaitForSeconds(2f);



		if (_currentTutorialState == TutorialState.StoryStart ||
			_currentTutorialState == TutorialState.StoryEnd ||
			_currentTutorialState == TutorialState.SwitchToCar ||
			_currentTutorialState == TutorialState.SwitchToRickshaw)
			References.Instance.imageFade.enabled = true;

		yield return new WaitForSeconds(1f);

		if (Number == 0) {
			{
				TutorialPanels [Number].SetActive (false);
				References.Instance.vehicleSelector.SelectBus ();
			}

		if (_currentTutorialState == TutorialState.StoryStart) {
			NextTutorial (_currentTutorialState);
			ShowTutorial (_currentTutorialState);
		}
		if (_currentTutorialState == TutorialState.RaceButton) {
				NextTutorial (_currentTutorialState);
			} 		

		else if (_currentTutorialState == TutorialState.SwitchToCar) {
			References.Instance.vehicleSelector.SelectCar ();
			NextTutorial (_currentTutorialState);
		}else 	if (_currentTutorialState == TutorialState.SwitchToRickshaw) {
				References.Instance.vehicleSelector.SelectRickshaw ();
				NextTutorial (_currentTutorialState);
		}else 	if (_currentTutorialState == TutorialState.StoryEnd)
			References.Instance.player.GetComponent<PlayerCollisionManager> ().ShowLevelCompletePopup ();

			yield return new WaitForSeconds (1f);			
			if (_currentTutorialState == TutorialState.StoryStart)
				ShowTutorial (TutorialState.RaceButton);
		}
	}

	int tutorialCount;
    void showText()
    {
		Debug.Log ("StateShow:" + _currentTutorialState);
        foreach (GameObject g in TutorialPanels)
            g.SetActive(false);

		if (_currentTutorialState.Equals(TutorialState.HealthBar))
			Number=3;		
		else if (_currentTutorialState.Equals(TutorialState.BoostAttack))
			Number=2;		
		else if (_currentTutorialState.Equals(TutorialState.RaceButton))
			Number=1;		
		else 
			Number=0;

        TutorialPanels[Number].SetActive(true);
        TutorialTxt = TutorialPanels[Number].GetComponentInChildren<Text>();

		if (_currentTutorialState == TutorialState.BoostAttack)
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
			showText();
            break;
          
		case TutorialState.RaceButton:  
			showText();
			UserPrefs.isTutorialFinished = false;
            break;

		case TutorialState.BoostAttack: 
				showText();
                break;

	

		case TutorialState.SwitchToCar:
			showText();
			break;

		case TutorialState.SwitchToRickshaw:
			showText();			        
			break;

		case TutorialState.StoryEnd:
			showText();
			break;
        }
    }
}
