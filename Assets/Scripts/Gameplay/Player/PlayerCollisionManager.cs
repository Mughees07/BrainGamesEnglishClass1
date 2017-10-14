using UnityEngine;
using System.Collections;

public class PlayerCollisionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag.Equals (Tags.carTrigger)) {


			References.Instance.vehicleSelector.SelectCar ();

			Debug.Log ("Car Trigger");
			

		} else if (other.gameObject.tag.Equals (Tags.RickshawTrigger)) {
		
			References.Instance.vehicleSelector.SelectRickshaw ();
			Debug.Log ("Rickshaw Trigger");
		
		} else if (other.gameObject.tag.Equals (Tags.LevelEndTrigger)) {

			ShowLevelCompletePopup ();	
		} else if (other.gameObject.tag.Equals (Tags.HurdleTrigger)) {
			
			References.Instance.boostButton.SetActive (true);

		}	else if (other.gameObject.tag.Equals (Tags.Hurdle)) {

			if (Variables.boost) {


			} else {
				Variables.currentHealth -= 20f;
				if (Variables.currentHealth <= 0)
					ShowLevelFailPopup ();
			}
			Variables.boost = false;
			References.Instance.boostButton.SetActive (false);
		}


	}

	void ShowLevelCompletePopup()
	{
		//if(!GameObject.FindWithTag(Tags.LevelExit))
		//	Time.timeScale = 1;
		GAManager.Instance.LogDesignEvent("GamePlay:LevelComplete:"+ (Constants.selectedLevel+1));
		Instantiate(Resources.Load(Constants.LevelComplete));
	}

	void ShowLevelFailPopup()
	{
		//if(!GameObject.FindWithTag(Tags.LevelExit))
		//	Time.timeScale = 1;
		GAManager.Instance.LogDesignEvent("GamePlay:LevelComplete:"+ (Constants.selectedLevel+1));
		Instantiate(Resources.Load(Constants.LevelFail));
	}


}
