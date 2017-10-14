using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{

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

    void Start()
    {
        UserPrefs.Load();
		Debug.Log("tutorial status : " + UserPrefs.isTutorialFinished);
    }

 

    public void HideTutorialPanel()
    {
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

        if (_currentTutorialState.Equals(TutorialState.HealthBar))
        {
            Number++;
        }

        GAManager.Instance.LogDesignEvent("Tutorial:Step:" + Number);
		     

       

        switch (_currentTutorialState)
        {


        case TutorialState.StoryStart:
                TutorialTxt.text = Constants.TutorialText[0];
                break;
		case TutorialState.RaceButton:
                TutorialTxt.text = Constants.TutorialText[1];
                break;
		case TutorialState.BoostAttack:
                TutorialTxt.text = Constants.TutorialText[2];               
                break;
		case TutorialState.HealthBar:
                TutorialTxt.text = Constants.TutorialText[3];
                break;
		case TutorialState.SwitchToCar:
                TutorialTxt.text = Constants.TutorialText[4];
                break;
		case TutorialState.SwitchToRickshaw:
                TutorialTxt.text = Constants.TutorialText[5];               
                break;
		case TutorialState.StoryEnd:
				TutorialTxt.text = Constants.TutorialText[6];
				break;
        }


    }

 

  



  

    public void NextTutorial(TutorialState _current)
    {

        switch (_current)
        {
		case TutorialState.StoryStart: 
                if (Number == 1)
                {
				_currentTutorialState = TutorialState.RaceButton;
                    showText();
                }
                break;
          
		case TutorialState.RaceButton: 
                if (Number == 2)
                {
				_currentTutorialState = TutorialState.BoostAttack;
                    showText();
                }
                break;
		case TutorialState.BoostAttack: 
                if (Number == 3)
                {
				_currentTutorialState = TutorialState.HealthBar;
                   showText();
                }
                break;
		case TutorialState.HealthBar: 
                if (Number == 4)
                {
                    _currentTutorialState = TutorialState.HealthBar;
                    showText();
                }
                break;
		case TutorialState.SwitchToCar:
			TutorialTxt.text = Constants.TutorialText[4];
			break;
		case TutorialState.SwitchToRickshaw:
			TutorialTxt.text = Constants.TutorialText[6];               
			break;
		case TutorialState.StoryEnd:
			TutorialTxt.text = Constants.TutorialText[6];
			break;
        }
    }
}
