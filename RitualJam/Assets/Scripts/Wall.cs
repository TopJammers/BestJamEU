using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	// Use this for initialization

	//public GameObject spikes;
	Animator anim_wall;
	void Start () {
		anim_wall = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col)
	{


		if(col.gameObject.tag.Equals("Player"))
		{
			Debug.Log("Player Died");
			anim_wall.SetBool("DeathWall",true);
			col.gameObject.GetComponent<GridMove>().setIsDead(true);
			col.gameObject.GetComponent<SpriteRenderer>().enabled=false;
			col.gameObject.GetComponent<PlayerDeath>().Kill(1, GameManager.deathTypes.Walls);
			//Instantiate(spikes,this.transform.position,this.transform.rotation);
		}
	}
}