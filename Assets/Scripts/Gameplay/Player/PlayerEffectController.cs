using UnityEngine;
using System.Collections;

public class PlayerEffectController : MonoBehaviour {

	// Use this for initialization

	public GameObject HitEffect1;
	public GameObject TyrePuncherEffect;
	public GameObject feulEffect;
	public GameObject HitEffect2;
	public GameObject CoinEffect;
	void Start () {
	
	}


	public void ShowHit1Effect(Vector3 pos)
	{
		Instantiate (HitEffect1, pos, Quaternion.identity);
	}

	public void ShowHit2Effect(Vector3 pos)
	{
		Instantiate (HitEffect2, pos, Quaternion.identity);
	}

	public void ShowCoinEffect(Vector3 pos)
	{
		Instantiate (CoinEffect, pos, Quaternion.identity);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
