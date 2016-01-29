using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MoveUp () {
		Debug.Log("arriba");
	}

	public void MoveDown () {
		Debug.Log("abajo");
	}

	public void MoveLeft () {
		Debug.Log("izq");
	}

	public void MoveRight () {
		Debug.Log("der");
	}

	public void Stop () {
		Debug.Log("para");
	}
}
