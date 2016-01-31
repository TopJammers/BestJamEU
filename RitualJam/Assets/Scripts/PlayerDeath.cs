using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {
	public GameObject gameStats;

	private GameStats stats;

	// Use this for initialization
	void Start () {
		stats = gameStats.GetComponent<GameStats>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

<<<<<<< HEAD
	public void Kill (int seconds) {
		Invoke("KillPlayer",seconds);
	}

	void KillPlayer () {
		SceneManager.LoadScene("Scene Juanca", LoadSceneMode.Single);
	}

=======
	public void Kill (int seconds, GameStats.deathTypes dt) {
		Invoke("KillPlayer",seconds);
		stats.AddDeath(dt);
	}

	void KillPlayer () {
		SceneManager.LoadScene("animacionesbuenas", LoadSceneMode.Single);
	}

>>>>>>> 831ac228a43968f99e7731fff31902166ba2e529
}
