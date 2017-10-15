using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFader : MonoBehaviour {

	// the image you want to fade, assign in inspector
	public Image img;




	public Image FadeEffectImage;
	void OnEnable () {
		SetFadingState ();
	}

	void SetFadingState()
	{
		FadeEffectImage.gameObject.SetActive (true);
		FadeEffectImage.CrossFadeAlpha(0,0,true);
		FadeEffectImage.CrossFadeAlpha(1,1f,true);
		Invoke("DisableFadingEffect",1f);
	}

	void DisableFadingEffect()
	{
		FadeEffectImage.CrossFadeAlpha(0,1f,true);
		Invoke("disable",1f);

	}
	public void disable()
	{
		FadeEffectImage.gameObject.SetActive (false);
		enabled = false;
	}
}