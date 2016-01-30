using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Kill (int seconds) {
		Invoke("KillPlayer",seconds);
	}

	void KillPlayer () {
		SceneManager.LoadScene("Scene Juanca", LoadSceneMode.Single);
	}

}
