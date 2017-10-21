using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class References : SingletonForScripts<References> {

	public GameObject player;
	public SimpleControlVehicle vehicleController;
	public VehicleSelector vehicleSelector;
	public TutorialManager tutorialManager;
	public ImageFader imageFade;
	public CameraControl cameraControl;

	public GameObject raceButton;
	public GameObject boostButton;
	public GameObject boostGlow;

	public Image HealthBar;
	public Text Coins;
	public Text score;







	// Use this for initialization
	void Start () {
		//player=GameObject.FindGameObjectWithTag ("Player");
		//vehicleController = player.GetComponent<SimpleControlVehicle> ();
		tutorialManager = FindObjectOfType<TutorialManager> ();
		vehicleSelector = FindObjectOfType<VehicleSelector> ();
		cameraControl = FindObjectOfType<CameraControl> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
