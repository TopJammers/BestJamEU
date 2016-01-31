using UnityEngine;
using System.Collections;

public class GroundHole : MonoBehaviour {

     Animator player_anim;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            player_anim = col.gameObject.GetComponent<Animator>();
            player_anim.SetBool("IsFalling", true);
            Debug.Log("Player Died");
            col.gameObject.GetComponent<GridMove>().setIsDead(true);
            col.gameObject.GetComponent<PlayerDeath>().Kill(1);


        }
    }
}
