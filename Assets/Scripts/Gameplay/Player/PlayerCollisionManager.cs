﻿using UnityEngine;
using System.Collections;

public class PlayerCollisionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag.Equals (Tags.carTrigger)) {



		} else if (other.gameObject.tag.Equals (Tags.RickshawTrigger)) {
		
		
		
		}


	}
}
