using UnityEngine;
using System.Collections;

public class ButtonClickHandler : MonoBehaviour {

	public static bool mouseDown;
	// Use this for initialization
	public void OnPointerDown(){
		if (this.name.Equals ("Race"))
			References.Instance.vehicleController.accelerate = true;
		else if (this.name.Equals ("Boost"))
			References.Instance.vehicleController.boost ();

	}
	public void OnPointerUp(){
		if(this.name.Equals("Race"))
		References.Instance.vehicleController.accelerate = false;
	}
}
