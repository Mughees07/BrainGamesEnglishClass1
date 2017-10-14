﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typeWriter : MonoBehaviour {

	public float delay = 0.1f;
	public string fullText;
	private string currentText = "";

	void Start ()
	{
		StartCoroutine(ShowText());
		//fullText = TutorialManager.TutorialTxt.text.ToString();
	}

	IEnumerator ShowText()
	{
		for(int i = 0; i <= fullText.Length; i++)
		{ 
			currentText = fullText.Substring(0,i);
			this.GetComponent<Text>().text =currentText;
			yield return new WaitForSeconds(delay);
		}
	}
}
