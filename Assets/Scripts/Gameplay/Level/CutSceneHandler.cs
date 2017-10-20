using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CutSceneHandler : MonoBehaviour {

	// Use this for initialization
	int currentScene=-1;
	public Text panelText;
	public GameObject continueButton;
	float delay=0.01f;
	public string currentText;
	//Scene1
	public GameObject Shabebarat;
	public GameObject MrsShahid_Scene1;

	//Scene2
	public GameObject Thought;
	public GameObject MrsShahid_Scene2;

	//Scene2
	public GameObject BusEmpty;
	public GameObject BusFilled;
	public GameObject MrsShahid_Scene3;


	public GameObject[] Scenes;
	public GameObject[] ScenePanel;


	void Start () {
		SoundManager.Instance.UnMuteSound ();
		SoundManager.Instance.UnMuteMusic ();
		switchScene ();
	}

	public void HideAll()
	{
		for (int i = 0; i < Scenes.Length; i++) {
			
			Scenes [i].SetActive (false);
			ScenePanel [i].SetActive (false);	
		}
		continueButton.SetActive (false);
	}
	public void switchScene()
	{
		GetComponent<ImageFader> ().enabled = true;
		Invoke ("SelectScene", 1f);
	}

	public void SelectScene()
	{
		HideAll ();
		currentScene++;
		switch (currentScene) {
		case 0:
			StartCoroutine (LoadScene1 ());
			break;
		case 1:
			StartCoroutine (LoadScene2 ());
			break;
		case 2:
			StartCoroutine (LoadScene3 ());
			break;

		default:
			GameManager.Instance.LoadLoadingScreen (Constants.GamePlay);
			break;


		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator ShowText(string desc)
	{	
		
			int index = 0;
			

			while (index < desc.Length) {
			
			currentText += desc [index++];
			ScenePanel [currentScene].GetComponentInChildren<Text>().text = currentText;
			yield return new WaitForSeconds (0.02f);
			if(index%3==0)
				SoundManager.Instance.PlaySound(GameManager.SoundState.TYPESOUND);
			}

			


	}

	public IEnumerator LoadScene1()
	{
		Scenes [currentScene].SetActive (true);
		ScenePanel [currentScene].SetActive (true);
		currentText = string.Empty;
		StartCoroutine (ShowText ("Today is Shabebarat"));
		yield return new WaitForSeconds (1f);
		Shabebarat.SetActive (true);
		yield return new WaitForSeconds (1f);
		StartCoroutine (ShowText ("\nMrs Shahid is too happy"));
		yield return new WaitForSeconds (1f);
		MrsShahid_Scene1.SetActive (true);
		yield return new WaitForSeconds (1f);
		StartCoroutine (ShowText ("\nShe is going to her Sister's House"));
		yield return new WaitForSeconds (1f);
		continueButton.SetActive (true);
	}


	public IEnumerator LoadScene2()
	{
		Scenes [currentScene].SetActive (true);
		ScenePanel [currentScene].SetActive (true);
		currentText = string.Empty;
		StartCoroutine (ShowText ("Mrs Shahid is Happy."));
		yield return new WaitForSeconds (1f);
		MrsShahid_Scene2.SetActive (true);
		yield return new WaitForSeconds (1f);
		StartCoroutine (ShowText ("\nShe is going to her sister's house"));
		yield return new WaitForSeconds (1f);
		Thought.SetActive (true);
		yield return new WaitForSeconds (1f);
		StartCoroutine (ShowText ("\nShe is waiting for the bus"));
		yield return new WaitForSeconds (1f);
		continueButton.SetActive (true);

	}

	public IEnumerator LoadScene3()
	{
		Scenes [currentScene].SetActive (true);
		ScenePanel [currentScene].SetActive (true);
		currentText = string.Empty;
		StartCoroutine (ShowText ("Bus is Here"));
		yield return new WaitForSeconds (1f);
		BusEmpty.SetActive (true);
		BusEmpty.transform.parent.gameObject.SetActive (true);
		yield return new WaitForSeconds (1f);
		StartCoroutine (ShowText ("\nMrs Shahid is going in Bus"));
		yield return new WaitForSeconds (2.5f);
		BusEmpty.SetActive (false);
		MrsShahid_Scene3.SetActive (false);
		BusFilled.SetActive (true);
		yield return new WaitForSeconds (1f);
		StartCoroutine (ShowText ("\nBus is going to Saddar"));
		yield return new WaitForSeconds (1f);
		continueButton.SetActive (true);

	}


}
