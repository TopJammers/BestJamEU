using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	//Attributes
	public GameObject confirmPanel;
	private static bool streamingMode = false;
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
		}
		DontDestroyOnLoad (gameObject);
	}

	//Public methods
	public void OnSettingsClick()
	{
		SceneManager.LoadScene ("Settings Scene", LoadSceneMode.Single);
	}

	public void OnCreditsClick()
	{
		SceneManager.LoadScene ("Credits Scene", LoadSceneMode.Single);
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
		SceneManager.LoadScene ("Menu Scene", LoadSceneMode.Single);
	}

	public void OnYesClick()
	{
		Application.Quit ();
	}

	public void OnNoClick()
	{
		confirmPanel.SetActive (false);
	}

	public void OnStreamingToggleChange()
	{
		streamingMode = !streamingMode;
	}

	public bool IsStreamingModeOn()
	{
		return streamingMode;
	}
}
