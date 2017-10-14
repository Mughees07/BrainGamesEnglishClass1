using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFade : MonoBehaviour {

	// the image you want to fade, assign in inspector
	public Image img;

	public void FadeAway()
	{
		// fades the image out when you click
		StartCoroutine(FadeImage(true));
	}

	public void FadeIn()
	{
		img.gameObject.SetActive (true);
		StartCoroutine(FadeImage(false));
	}


	IEnumerator FadeImage(bool fadeAway)
	{
		// fade from opaque to transparent
		if (fadeAway)
		{
			// loop over 1 second backwards
			for (float i = 1; i >= 0; i -= Time.deltaTime)
			{
				// set color with i as alpha
				img.color = new Color(1, 1, 1, i);
				yield return null;
			}
			FadeAway ();
		}
		// fade from transparent to opaque
		else
		{
			// loop over 1 second
			for (float i = 0; i <= 1; i += Time.deltaTime)
			{
				//set color with i as alpha
				img.color = new Color(1, 1, 1, i);
				yield return null;
			}
			img.gameObject.SetActive (false);
		}


	}
}