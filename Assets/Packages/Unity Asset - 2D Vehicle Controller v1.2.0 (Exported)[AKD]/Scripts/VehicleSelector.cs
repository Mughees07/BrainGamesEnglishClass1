using UnityEngine;
using System.Collections;

public class VehicleSelector : MonoBehaviour {

	public GameObject Bus;
	public GameObject Rickshaw;
	public GameObject Car;
	// Use this for initialization
	public void SelectBus()
	{
		Bus.SetActive (true);
		References.Instance.player = Bus;
		References.Instance.vehicleController = Bus.GetComponent<SimpleControlVehicle> ();
	}

	public void SelectCar()
	{
		Car.transform.position = Bus.transform.position;
		References.Instance.cameraControl.target = Car.transform;
		Bus.SetActive (false);
		Car.SetActive (true);
		References.Instance.player = Car;
		References.Instance.vehicleController = Car.GetComponent<SimpleControlVehicle> ();
	}

	public void SelectRickshaw()
	{
		Rickshaw.transform.position = Car.transform.position;
		References.Instance.cameraControl.target = Rickshaw.transform;
		Car.SetActive (false);
		Rickshaw.SetActive (true);
		References.Instance.player = Rickshaw;
		References.Instance.vehicleController = Rickshaw.GetComponent<SimpleControlVehicle> ();
	}





}
