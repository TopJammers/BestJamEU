﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour {
	//Attributes
	public GameObject clickObject;
	public GameObject hoverObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Public methods
	public void OnBackClick()
	{
		clickObject.GetComponent<AudioSource> ().enabled = true;
		clickObject.GetComponent<AudioSource> ().Play ();
		SceneManager.LoadScene ("Menu Scene", LoadSceneMode.Single);
	}

	public void OnButtonHover()
	{
		hoverObject.GetComponent<AudioSource> ().Play ();
		hoverObject.GetComponent<AudioSource> ().enabled = true;
	}
}
