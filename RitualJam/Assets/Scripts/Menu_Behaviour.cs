using UnityEngine;
using System.Collections;

public class Menu_Behaviour : MonoBehaviour {
	//Attributes
	public GameObject confirmCanvas;

	// Use this for initialization
	void Awake() {
		DontDestroyOnLoad (transform.gameObject);
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Public methods
	public void OnSettingsClick()
	{
		Application.LoadLevel (1);
	}

	public void OnCreditsClick()
	{
		Application.LoadLevel (2);
	}

	public void OnPlayClick()
	{
	}

	public void OnQuitClick()
	{
		confirmCanvas.SetActive (true);
	}

	public void OnBackClick()
	{
		Application.LoadLevel (0);
	}

	public void OnYesClick()
	{
		Application.Quit ();
	}

	public void OnNoClick()
	{
		confirmCanvas.SetActive (false);
	}
}
