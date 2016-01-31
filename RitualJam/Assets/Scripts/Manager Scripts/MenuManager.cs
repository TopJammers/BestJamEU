using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	//Attributes
	public GameObject confirmPanel;
	public GameObject clickObject;
	public GameObject hoverObject;
	public Texture2D cursorTexture;
	private static bool streamingMode = false;
		
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void Awake() {
		Cursor.SetCursor (cursorTexture, CursorMode.ForceSoftware);
		int musicOn = PlayerPrefs.GetInt ("MusicOn",1);
		if (musicOn == 1) {
			GetComponent<AudioSource> ().mute = false;
			GetComponent<AudioSource> ().volume = PlayerPrefs.GetFloat ("MusicVolume", 1f);
		} else {
			GetComponent<AudioSource> ().mute = true;
		}
		int soundOn = PlayerPrefs.GetInt ("SoundOn",1);
		if (soundOn == 1) {
			clickObject.GetComponent<AudioSource> ().mute = false;
			clickObject.GetComponent<AudioSource> ().volume = PlayerPrefs.GetFloat ("SoundVolume", 1f);
			hoverObject.GetComponent<AudioSource> ().mute = false;
			hoverObject.GetComponent<AudioSource> ().volume = PlayerPrefs.GetFloat ("SoundVolume", 1f);
		} else {
			clickObject.GetComponent<AudioSource> ().mute = true;
			hoverObject.GetComponent<AudioSource> ().mute = true;
		}
	}

	//Public methods
	public void OnSettingsClick()
	{
		clickObject.GetComponent<AudioSource> ().Play ();
		clickObject.GetComponent<AudioSource> ().enabled = true;
		SceneManager.LoadScene ("Settings Scene", LoadSceneMode.Single);
	}

	public void OnCreditsClick()
	{
		clickObject.GetComponent<AudioSource> ().Play ();
		clickObject.GetComponent<AudioSource> ().enabled = true;
		SceneManager.LoadScene ("Credits Scene", LoadSceneMode.Single);
	}

	public void OnPlayClick()
	{
		clickObject.GetComponent<AudioSource> ().Play ();
		clickObject.GetComponent<AudioSource> ().enabled = true;
	}

	public void OnQuitClick()
	{
		clickObject.GetComponent<AudioSource> ().Play ();
		clickObject.GetComponent<AudioSource> ().enabled = true;
		confirmPanel.SetActive (true);
	}

	public void OnYesClick()
	{
		clickObject.GetComponent<AudioSource> ().Play ();
		clickObject.GetComponent<AudioSource> ().enabled = true;
		Application.Quit ();
	}

	public void OnNoClick()
	{
		clickObject.GetComponent<AudioSource> ().Play ();
		clickObject.GetComponent<AudioSource> ().enabled = true;
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

	public void OnButtonHover()
	{
		hoverObject.GetComponent<AudioSource> ().Play ();
		hoverObject.GetComponent<AudioSource> ().enabled = true;
	}
}
