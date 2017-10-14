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



			Debug.Log ("Car Trigger");
			

		} else if (other.gameObject.tag.Equals (Tags.RickshawTrigger)) {
		
			Debug.Log ("Rickshaw Trigger");
		
		}


	}
}
