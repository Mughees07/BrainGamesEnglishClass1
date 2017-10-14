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

		NextTutorial (TutorialState.StoryStart);



		Debug.Log("tutorial status : " + UserPrefs.isTutorialFinished);
    }

    public void HideTutorialPanel()
    {
    }

	IEnumerator ShowText(string desc)
	{
		for(int i = 0; i <=desc.Length ; i++)
		{ 
			TutorialTxt.text = desc.Substring (0,i);
			yield return new WaitForSeconds(delay);
		}
		yield return new WaitForSeconds (2f);
		if (_currentTutorialState == TutorialState.StoryStart ||
			_currentTutorialState == TutorialState.StoryEnd ||
			_currentTutorialState == TutorialState.SwitchToCar ||
			_currentTutorialState == TutorialState.SwitchToRickshaw)
			References.Instance.imageFade.FadeIn ();
		
		if (Number == 0) {
			TutorialPanels [Number].SetActive (false);

			yield return new WaitForSeconds (1f);


			
			if (_currentTutorialState == TutorialState.StoryStart)
				NextTutorial (TutorialState.StoryStart);
		}
	}


    void showText()
    {
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
		StartCoroutine (ShowText (Constants.TutorialText[Number]));
		//TutorialTxt.text = Constants.TutorialText[Number];

        

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
        switch (_current)
        {

		case TutorialState.StoryStart: 
             
			showText();
			_currentTutorialState = TutorialState.RaceButton; 

                break;
          
		case TutorialState.RaceButton:  				
			UserPrefs.isTutorialFinished = false;
			_currentTutorialState = TutorialState.BoostAttack;
			showText();
             break;

		case TutorialState.BoostAttack: 
  	

			_currentTutorialState = TutorialState.HealthBar;
			showText();
                break;

		case TutorialState.HealthBar: 


			_currentTutorialState = TutorialState.SwitchToCar;
			showText();
                break;

		case TutorialState.SwitchToCar:

			showText();
			_currentTutorialState = TutorialState.SwitchToRickshaw;
			break;

		case TutorialState.SwitchToRickshaw:

			showText();
			_currentTutorialState = TutorialState.StoryEnd;           
			break;

		case TutorialState.StoryEnd:

			showText();
			_currentTutorialState = TutorialState.StoryStart;
			break;
        }
    }
}
