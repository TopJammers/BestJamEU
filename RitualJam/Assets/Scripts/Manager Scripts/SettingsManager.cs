using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour {
	//Attributes
	public Slider musicSlider;
	public Slider soundSlider;
	public Toggle musicToggle;
	public Toggle soundToggle;
	public GameObject clickObject;
	public GameObject hoverObject;
	public Texture2D cursorTexture;
	private bool musicOn = true;
	private bool soundOn = true;
	private float musicVolume;
	private float soundVolume;
	private Vector2 cursorHotspot;
	private static bool streamingMode = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake() {
		cursorHotspot = new Vector2(cursorTexture.width/2.0f, 2f);
		Cursor.SetCursor (cursorTexture, cursorHotspot, CursorMode.ForceSoftware);
		//Load settings
		int musicOnInteger = PlayerPrefs.GetInt ("MusicOn", 1);
		if (musicOnInteger == 0) {
			if (musicToggle.isOn) {
				musicOn = true;
			}
			musicToggle.isOn = false;
		} else {
			if (!musicToggle.isOn) {
				musicOn = false;
			}
			musicToggle.isOn = true;
		}
		int soundOnInteger = PlayerPrefs.GetInt ("SoundOn", 1);
		if (soundOnInteger == 0) {
			if (soundToggle.isOn) {
				soundOn = true;
			}
			soundToggle.isOn = false;
		} else {
			if (!soundToggle.isOn) {
				soundOn = false;
			}
			soundToggle.isOn = true;
		}
		musicSlider.value = PlayerPrefs.GetFloat ("MusicVolume", 1f);
		musicVolume = musicSlider.value;
		soundSlider.value = PlayerPrefs.GetFloat ("SoundVolume", 1f);
		soundVolume = soundSlider.value;
		//Set the music volume
		setMusicVolume ();
		//Set the sound volume
		setSoundVolume ();
	}
	
	//Public methods
	public void OnMusicToggleChange()
	{
		clickObject.GetComponent<AudioSource> ().enabled = true;
		clickObject.GetComponent<AudioSource> ().Play ();
		//Set the UI elements on-off
		musicOn = !musicOn;
		musicSlider.interactable = musicOn;
		int musicOnInteger = 0;
		if (musicOn) {
			musicOnInteger = 1;
		}
		//Mute-unmute music volume
		setMusicVolume ();
		//Save the setting
		PlayerPrefs.SetInt ("MusicOn", musicOnInteger);
	}

	public void OnSoundToggleChange()
	{
		clickObject.GetComponent<AudioSource> ().enabled = true;
		clickObject.GetComponent<AudioSource> ().Play ();
		//Set the UI elements on-off
		soundOn = !soundOn;
		soundSlider.interactable = soundOn;
		int soundOnInteger = 0;
		if (soundOn) {
			soundOnInteger = 1;
		}
		//Mute-unmute sound volume
		setSoundVolume();
		//Save the setting
		PlayerPrefs.SetInt ("SoundOn",soundOnInteger);
	}

	public void OnMusicSliderChange(){
		//Change the music volume
		musicVolume = musicSlider.value;
		setMusicVolume ();
		//Save the setting
		PlayerPrefs.SetFloat ("MusicVolume",musicVolume);
	}

	public void OnSoundSliderChange(){
		//Change the sound volume
		soundVolume = soundSlider.value;
		setSoundVolume ();
		//Save the setting
		PlayerPrefs.SetFloat ("SoundVolume", soundVolume);
	}

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

	public void OnStreamingToggleChange()
	{
		clickObject.GetComponent<AudioSource> ().enabled = true;
		clickObject.GetComponent<AudioSource> ().Play ();
		streamingMode = !streamingMode;
	}

	public bool IsStreamingModeOn()
	{
		return streamingMode;
	}

	//Private methods
	private void setMusicVolume()
	{
		if (!musicOn) {
			GetComponent<AudioSource> ().mute = true;
		} else {
			GetComponent<AudioSource> ().mute = false;
			GetComponent<AudioSource> ().volume = musicVolume;
		}
	}

	private void setSoundVolume()
	{
		if (!soundOn) {
			clickObject.GetComponent<AudioSource> ().mute = true;
			hoverObject.GetComponent<AudioSource> ().mute = true;
		} else {
			clickObject.GetComponent<AudioSource> ().mute = false;
			clickObject.GetComponent<AudioSource> ().volume = soundVolume;
			hoverObject.GetComponent<AudioSource> ().mute = false;
			hoverObject.GetComponent<AudioSource> ().volume = soundVolume;
		}
	}
}
