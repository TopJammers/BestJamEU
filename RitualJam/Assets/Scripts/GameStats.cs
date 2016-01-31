using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStats : MonoBehaviour {
	public enum deathTypes {Spikes, Walls, Holes, Boulder}

	private static Dictionary<deathTypes, int> deathCnt;
	private static int cnt;

	// Use this for initialization
	void Start () {
		if (deathCnt == null) {
			deathCnt = new Dictionary<deathTypes, int>();
			deathCnt.Add(deathTypes.Spikes, 0);
			deathCnt.Add(deathTypes.Walls, 0);
			deathCnt.Add(deathTypes.Holes, 0);
			deathCnt.Add(deathTypes.Boulder, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddDeath (deathTypes type) {
		int cnt = deathCnt[type];
		deathCnt[type] = cnt+1;
		foreach (deathTypes dt in deathCnt.Keys) {
			Debug.Log(dt.ToString() + ": " + deathCnt[dt]);
		}
	}
}
