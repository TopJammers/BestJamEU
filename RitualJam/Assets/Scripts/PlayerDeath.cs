using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {
	public GameObject gameStats;

	private GameManager stats;

	// Use this for initialization
	void Start () {
		stats = gameStats.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Kill (int seconds, GameManager.deathTypes dt) {
		Invoke("KillPlayer",seconds);
		stats.AddDeath(dt);
	}

	void KillPlayer () {
		SceneManager.LoadScene("animacionesbuenas", LoadSceneMode.Single);
	}
}