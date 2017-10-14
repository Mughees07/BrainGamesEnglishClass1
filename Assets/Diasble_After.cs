using UnityEngine;
using System.Collections;

public class Diasble_After : MonoBehaviour {

	public float timer;

	void OnEnable () {

		Invoke ("Disable", timer);

	}

	void Disable()
	{
		gameObject.SetActive (false);
	}

}
