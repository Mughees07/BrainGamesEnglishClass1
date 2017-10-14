using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class References : SingletonForScripts<References> {

	public GameObject player;
	public SimpleControlVehicle vehicleController;
	public TutorialManager tutorialManager;


	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag ("Player");
		vehicleController = player.GetComponent<SimpleControlVehicle> ();
		tutorialManager = FindObjectOfType<TutorialManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
