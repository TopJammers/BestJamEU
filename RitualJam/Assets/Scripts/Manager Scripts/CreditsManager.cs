﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour {
	//Attributes
	public GameObject clickObject;
	public GameObject hoverObject;
	public Texture2D cursorTexture;
	private Vector2 cursorHotspot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake(){
		cursorHotspot = new Vector2(cursorTexture.width/3.0f, 2f);
		Cursor.SetCursor (cursorTexture, cursorHotspot, CursorMode.ForceSoftware);
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
