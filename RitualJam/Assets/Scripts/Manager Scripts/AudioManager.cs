using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioManager : MonoBehaviour {
	//Attributes
	public Slider musicSlider;
	public Slider soundSlider;
	public Toggle musicToggle;
	public Toggle soundToggle;
	private bool musicOn = true;
	private bool soundOn = true;
	private float musicVolume;
	private float soundVolume;
	private static AudioManager instance = null;

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
		//Load settings
		if (musicToggle != null) {
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
		}
		DontDestroyOnLoad (gameObject);
	}
	
	//Public methods
	public void OnMusicToggleChange()
	{
		musicOn = !musicOn;
		musicSlider.interactable = musicOn;
		int musicOnInteger = 0;
		if (musicOn) {
			musicOnInteger = 1;
		}
		PlayerPrefs.SetInt ("MusicOn", musicOnInteger);
	}

	public void OnSoundToggleChange()
	{
		soundOn = !soundOn;
		soundSlider.interactable = soundOn;
		int soundOnInteger = 0;
		if (soundOn) {
			soundOnInteger = 1;
		}
		PlayerPrefs.SetInt ("SoundOn",soundOnInteger);
	}

	public void OnMusicSliderChange(){
		musicVolume = musicSlider.value;
		PlayerPrefs.SetFloat ("MusicVolume",musicVolume);
	}

	public void OnSoundSliderChange(){
		soundVolume = soundSlider.value;
		PlayerPrefs.SetFloat ("SoundVolume", soundVolume);
	}
}
