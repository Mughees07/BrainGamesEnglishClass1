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
		
		}


	}
}
