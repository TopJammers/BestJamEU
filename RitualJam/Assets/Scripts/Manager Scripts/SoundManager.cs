using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundManager : MonoBehaviour {
	//Attributes
	public Slider musicSlider;
	public Slider soundSlider;
	private bool musicOn = true;
	private bool soundOn = true;
	private float musicVolume;
	private float soundVolume;
	private static SoundManager instance = null;

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
	public void OnMusicToggleChange()
	{
		musicOn = !musicOn;
		musicSlider.interactable = musicOn;
	}

	public void OnSoundToggleChange()
	{
		soundOn = !soundOn;
		soundSlider.interactable = soundOn;
	}

	public void OnMusicSliderChange(){
		musicVolume = musicSlider.value;
	}

	public void OnSoundSliderChange(){
		soundVolume = soundSlider.value;
	}
}
