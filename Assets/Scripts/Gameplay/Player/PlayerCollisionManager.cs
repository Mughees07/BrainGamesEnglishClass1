using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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


	public void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Collision 3d "+ other.name);
		if (other.gameObject.tag.Equals (Tags.Coin)) {

			SetCoins (other.transform.position);

		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("Collision 2d "+ other.name);
		other.enabled = false;
		if (other.gameObject.tag.Equals (Tags.carTrigger)) {

			if (References.Instance.tutorialManager._currentTutorialState == TutorialManager.TutorialState.SwitchToCar) {
				References.Instance.vehicleController.accelerate = false;
				References.Instance.player.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;	
				References.Instance.player.GetComponent<Rigidbody2D> ().isKinematic = true;
				References.Instance.tutorialManager.ShowTutorial ((References.Instance.tutorialManager._currentTutorialState));	
			}

			SoundManager.Instance.PlaySound (GameManager.SoundState.THUDSOUND);

			Debug.Log ("Car Trigger");			

		} else if (other.gameObject.tag.Equals (Tags.RickshawTrigger)) {
		
			if (References.Instance.tutorialManager._currentTutorialState == TutorialManager.TutorialState.SwitchToRickshaw) {	
				References.Instance.vehicleController.accelerate = false;
				References.Instance.player.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;	
				References.Instance.player.GetComponent<Rigidbody2D> ().isKinematic = true;
				References.Instance.tutorialManager.ShowTutorial ((References.Instance.tutorialManager._currentTutorialState));	
				//References.Instance.vehicleSelector.SelectRickshaw ();
			}
			Debug.Log ("Rickshaw Trigger");
		
		} else if (other.gameObject.tag.Equals (Tags.LevelEndTrigger)) {
			if (References.Instance.tutorialManager._currentTutorialState == TutorialManager.TutorialState.StoryEnd) {
				References.Instance.vehicleController.accelerate = false;	
				References.Instance.player.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;	
				References.Instance.player.GetComponent<Rigidbody2D> ().isKinematic = true;

				References.Instance.tutorialManager.ShowTutorial ((References.Instance.tutorialManager._currentTutorialState));	
			}
	

		} else if (other.gameObject.tag.Equals (Tags.HurdleTrigger)) {
			if (References.Instance.tutorialManager._currentTutorialState == TutorialManager.TutorialState.BoostAttack) {
				References.Instance.boostButton.SetActive (true);
				References.Instance.raceButton.SetActive (false);
				References.Instance.vehicleController.accelerate = false;
				References.Instance.player.GetComponent<Rigidbody2D> ().isKinematic = true;
				References.Instance.player.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;	

				References.Instance.tutorialManager.ShowTutorial (References.Instance.tutorialManager._currentTutorialState);
			}

			Debug.Log ("Hurdle Trigger");
			References.Instance.boostButton.GetComponent<Button> ().interactable = true;
			//References.Instance.boostButton.SetActive (true);

		} else if (other.gameObject.tag.Equals (Tags.Hurdle)) {
			Debug.Log ("Hurdle");
			if (Variables.boost) {				
				clearHurdle (other);
				References.Instance.vehicleController.accelerate = false;
				SetScore ();
			} else {
				
				SetHealth ();
				StartCoroutine (Blink (other));
			}

			Variables.boost = false;
			References.Instance.boostButton.GetComponent<Button> ().interactable = false;
			//References.Instance.boostButton.SetActive (false);

		} else if (other.gameObject.tag.Equals (Tags.Coin)) {

			SetCoins (other.transform.position);

		}
	}

	public void SetHealth()
	{
		Variables.currentHealth -= 20;
		StartCoroutine (FillBar (-0.1f,References.Instance.HealthBar.fillAmount,false));
		//References.Instance.HealthBar.fillAmount = ;
	}

	public void SetScore()
	{
		Variables.points += 20;
		References.Instance.score.text = Variables.points.ToString();

	}

	public void SetCoins(Vector3 pos)
	{
		Variables.Coins += 1;
		StartCoroutine (FillBar (0.1f,References.Instance.CoinsBar.fillAmount,true));
		//References.Instance.CoinsBar.fillAmount = (float)(Variables.Coins % 10) / 10f;
		GetComponent<PlayerEffectController> ().ShowCoinEffect (pos);
	}

	public IEnumerator FillBar(float val,float currentVal,bool isCoin)
	{
		float tempVal = currentVal;

		if (isCoin) {			
			if (currentVal == 1f)
				tempVal = 0f;
		}


		for (int i = 0; i < 10; i++) {
		
			tempVal += val/10;
			if(isCoin)
			References.Instance.CoinsBar.fillAmount = tempVal;
			else
			References.Instance.HealthBar.fillAmount = tempVal;
			
			yield return new WaitForSeconds (0.05f);		
		}
	}


	public void clearHurdle(Collider2D other)
	{
		SoundManager.Instance.PlaySound(GameManager.SoundState.PLAYERHITSOUND);
		GetComponent<PlayerEffectController> ().ShowHit1Effect (other.transform.position);
		for (int i = 0; i < other.gameObject.transform.childCount; i++) {

			other.gameObject.transform.GetChild (i).gameObject.AddComponent<Rigidbody2D> ();
			other.gameObject.transform.GetChild (i).gameObject.GetComponent<Rigidbody2D> ().AddForce(new Vector2(Random.Range(20f,30f),Random.Range(5f,10f)),ForceMode2D.Impulse);
			other.gameObject.transform.GetChild (i).gameObject.GetComponent<Rigidbody2D> ().AddTorque(Random.Range(0f,180));
		}
	}
	public void clearHurdleEase(Collider2D other)
	{
		SoundManager.Instance.PlaySound(GameManager.SoundState.PLAYERHITSOUND);
		GetComponent<PlayerEffectController> ().ShowHit2Effect (other.transform.position);
		for (int i = 0; i < other.gameObject.transform.childCount; i++) {

			other.gameObject.transform.GetChild (i).gameObject.AddComponent<Rigidbody2D> ();
			other.gameObject.transform.GetChild (i).gameObject.GetComponent<Rigidbody2D> ().AddForce(new Vector2(Random.Range(5f,10f),Random.Range(1f,3f)),ForceMode2D.Impulse);
			other.gameObject.transform.GetChild (i).gameObject.GetComponent<Rigidbody2D> ().AddTorque(Random.Range(0f,180));
		}
	}

	public IEnumerator Blink(Collider2D other)
	{
		References.Instance.vehicleController.accelerate = false;
		References.Instance.player.GetComponent<Rigidbody2D> ().isKinematic = true;
		for(int i=0;i<3;i++)
		{
			for(int j=0;j<3;j++)
			{			
			References.Instance.player.transform.GetChild (j).gameObject.SetActive (false);			
			}
			yield return new WaitForSeconds (0.2f);
			for(int j=0;j<3;j++)
			{				
				References.Instance.player.transform.GetChild (j).gameObject.SetActive (true);
			}
			yield return new WaitForSeconds (0.2f);
		}
		if (Variables.currentHealth <= 0)
			ShowLevelFailPopup ();
		else
		References.Instance.player.GetComponent<Rigidbody2D> ().isKinematic = false;
		clearHurdleEase (other);	
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
