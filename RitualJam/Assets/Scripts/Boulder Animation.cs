using UnityEngine;
using System.Collections;

public class BoulderAnimation : MonoBehaviour {
	//Constants
	private const float INTERVAL_TIME = 0.5f;
	//Attributes
	public Sprite boulder1;
	public Sprite boulder2;
	public Sprite boulder3;
	private int turn = 2;
	private float timeLeft = INTERVAL_TIME;

	// Use this for initialization
	void Start (){
	}

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			if (turn == 1) {
				GetComponent<SpriteRenderer> ().sprite = boulder1;
				turn = 2;
			} else if (turn == 2) {
				GetComponent<SpriteRenderer> ().sprite = boulder2;
				turn = 3;
			} else {
				GetComponent<SpriteRenderer> ().sprite = boulder3;
				turn = 1;
			}
			timeLeft = INTERVAL_TIME;
		}
	}
}
