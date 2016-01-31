using UnityEngine;
using System.Collections;

public class OpenDoor2 : MonoBehaviour {
	public float distanceMin;

	Animator dooranim;
	GameObject player;
	float distance;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		dooranim = this.GetComponent<Animator>();
	}

	void FixedUpdate () {
		distance = Vector2.Distance(this.transform.position, player.transform.position);

		if (distance <= distanceMin){
			dooranim.SetBool("Open", true);
		} 
	}

	// Update is called once per frame
	void Update () {
	
	}
}
