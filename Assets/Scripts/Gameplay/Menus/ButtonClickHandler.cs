using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour {

	public static bool mouseDown;
	// Use this for initialization
	public void OnPointerDown(){
		if (this.name.Equals ("Race")) {						
			References.Instance.vehicleController.accelerate = true;

		} else if (this.name.Equals ("Boost")) {
			if(References.Instance.boostButton.GetComponent<Button>().interactable)
			References.Instance.vehicleController.boost ();
		}

	}
	public void OnPointerUp(){
		if (this.name.Equals ("Race")) {
			References.Instance.vehicleController.accelerate = false;

		}
	}

	void Update(){

		#if UNITY_EDITOR

		if(Input.GetKeyDown(KeyCode.DownArrow))
			References.Instance.vehicleController.accelerate = true;
		else  if(Input.GetKeyDown(KeyCode.UpArrow))
			References.Instance.vehicleController.accelerate = false;
		else  if(Input.GetKeyDown(KeyCode.Space))
		{
			if(References.Instance.boostButton.GetComponent<Button>().interactable)
				References.Instance.vehicleController.boost ();
		}
		#endif 
	}
}
