using UnityEngine;
using System.Collections;

public class PlayerCollisionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Variables.currentHealth = 100;
		Variables.points = 0;
		Variables.Coins = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag.Equals (Tags.carTrigger)) {

			if (References.Instance.tutorialManager._currentTutorialState == TutorialManager.TutorialState.SwitchToCar) {	
				References.Instance.player.GetComponent<Rigidbody2D> ().isKinematic = true;
				References.Instance.tutorialManager.ShowTutorial ((References.Instance.tutorialManager._currentTutorialState));	
			}

			SoundManager.Instance.PlaySound(GameManager.SoundState.THUDSOUND);

			Debug.Log ("Car Trigger");
			

		} else if (other.gameObject.tag.Equals (Tags.RickshawTrigger)) {
		
			if (References.Instance.tutorialManager._currentTutorialState == TutorialManager.TutorialState.SwitchToRickshaw) {	
			References.Instance.player.GetComponent<Rigidbody2D> ().isKinematic = true;
			References.Instance.tutorialManager.ShowTutorial ((References.Instance.tutorialManager._currentTutorialState));	
			//References.Instance.vehicleSelector.SelectRickshaw ();
			}
			Debug.Log ("Rickshaw Trigger");
		
		} else if (other.gameObject.tag.Equals (Tags.LevelEndTrigger)) {
			if (References.Instance.tutorialManager._currentTutorialState == TutorialManager.TutorialState.StoryEnd) {	
				References.Instance.player.GetComponent<Rigidbody2D> ().isKinematic = true;
				References.Instance.tutorialManager.ShowTutorial ((References.Instance.tutorialManager._currentTutorialState));	
			}
	

		} else if (other.gameObject.tag.Equals (Tags.HurdleTrigger)) {
			if (References.Instance.tutorialManager._currentTutorialState == TutorialManager.TutorialState.BoostAttack) {
				References.Instance.player.GetComponent<Rigidbody2D> ().isKinematic = true;
				References.Instance.tutorialManager.ShowTutorial (References.Instance.tutorialManager._currentTutorialState);
			}

			Debug.Log ("Hurdle Trigger");
			References.Instance.boostButton.SetActive (true);

		}	else if (other.gameObject.tag.Equals (Tags.Hurdle)) {
			Debug.Log ("Hurdle");
			if (Variables.boost) {
				SoundManager.Instance.PlaySound(GameManager.SoundState.PLAYERHITSOUND);
				for (int i = 0; i < other.gameObject.transform.childCount; i++) {

					other.gameObject.transform.GetChild (i).gameObject.AddComponent<Rigidbody2D> ();
					other.gameObject.transform.GetChild (i).gameObject.GetComponent<Rigidbody2D> ().AddForce(new Vector2(Random.Range(20f,30f),Random.Range(5f,10f)),ForceMode2D.Impulse);
					other.gameObject.transform.GetChild (i).gameObject.GetComponent<Rigidbody2D> ().AddTorque(Random.Range(0f,180));
				}
				Variables.points += 20;
				Variables.Coins += 1;
			} else {
				Variables.currentHealth -= 20;
				References.Instance.HealthBar.fillAmount -= 0.2f;
				if (Variables.currentHealth <= 0)
					ShowLevelFailPopup ();
				else
					StartCoroutine (Blink ());
			}

			Variables.boost = false;
			References.Instance.boostButton.SetActive (false);
			other.enabled = false;
		}


	}

	public IEnumerator Blink()
	{
		
		for(int i=0;i<3;i++)
		{
			References.Instance.player.transform.GetChild (0).gameObject.SetActive (false);
			yield return new WaitForSeconds (0.3f);
			References.Instance.player.transform.GetChild (0).gameObject.SetActive (true);
			yield return new WaitForSeconds (0.3f);
		}
			
	}

	public void ShowLevelCompletePopup()
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
