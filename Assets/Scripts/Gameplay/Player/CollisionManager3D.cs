using UnityEngine;
using System.Collections;

public class CollisionManager3D : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Collision 3d "+ other.name);
		if (other.gameObject.tag.Equals (Tags.Coin)) {
			GetComponentInParent<PlayerCollisionManager>().SetCoins (other.transform.position);
			Destroy (other.gameObject);
		}
	}
}
