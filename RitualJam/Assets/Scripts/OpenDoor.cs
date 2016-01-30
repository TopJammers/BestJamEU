using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

    public float distanceMin;

    GameObject player;
    float distance;
    Animator dooranim;

	// Use this for initialization
	void Start () {
		distance = 0.0f;
        player = GameObject.FindGameObjectWithTag("Player");
        dooranim = this.GetComponent<Animator>();
	}

    void FixedUpdate() {
        distance = Vector2.Distance(this.transform.position, player.transform.position);

        if (distance <= distanceMin){
            dooranim.SetBool("Open", true);
        } 

    }


    void OnCollisionEnter2D(Collision2D col ) {
        if(col.gameObject.tag == "Player"){
            
        }
        
    }
}
