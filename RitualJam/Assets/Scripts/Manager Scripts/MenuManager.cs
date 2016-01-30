using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	//Attributes
	public GameObject confirmPanel;
	private static MenuManager instance = null;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake() {
		//Singleton pattern
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad (gameObject);
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
		confirmPanel.SetActive (true);
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
		confirmPanel.SetActive (false);
	}
}
