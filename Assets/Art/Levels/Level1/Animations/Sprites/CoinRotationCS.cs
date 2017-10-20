using UnityEngine;
using System.Collections;

public class CoinRotationCS : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 1 * Time.deltaTime *speed, 0);
	
	}
}
