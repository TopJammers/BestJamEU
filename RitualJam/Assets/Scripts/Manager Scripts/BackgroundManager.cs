using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour {
	//Attributes
	public Texture texture1;
	public Texture texture2;
	private int turn = 2;
	private float timeLeft;

	// Use this for initialization
	void Start () {
		timeLeft = Random.Range (0.45f,0.6f);
	}

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			if(turn == 1)
			{
				GetComponent<RawImage> ().texture = texture2;
				turn = 2;
			}
			else{
				GetComponent<RawImage> ().texture = texture1;
				turn = 1;
			}
			timeLeft = Random.Range (0.45f,0.6f);
		}
	}
}
