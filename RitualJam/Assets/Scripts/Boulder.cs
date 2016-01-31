using UnityEngine;
using System.Collections;

public class Boulder : MonoBehaviour {
    public enum Directions { North, South, West, East}
    public Directions direction;
    public float speed;

    private Vector3 movement;
    private CharacterController controller;

    // Use this for initialization
    void Start () {
//        controller = GetComponent<CharacterController>();
        switch (direction)
        {
            case Directions.North:
                movement = new Vector3(0, 1,0);
                break;
            case Directions.South:
                movement = new Vector3(0, -1,0);
                break;
            case Directions.East:
                movement = new Vector3(1, 0,0);
                break;
            case Directions.West:
                movement = new Vector3(-1, 0,0);
                break;
            default:
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(movement*Time.deltaTime);
	}

    void FixedUpdate() {

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        //rb2d.AddForce(movement * speed);

//        controller.Move(movement * speed);
    }

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag.Equals("Player"))	{
			Debug.Log("Player Died");
			col.gameObject.GetComponent<GridMove>().setIsDead(true);
			col.gameObject.GetComponent<SpriteRenderer>().enabled=false;
			col.gameObject.GetComponent<PlayerDeath>().Kill(1, GameStats.deathTypes.Boulder);
			//Instantiate(spikes,this.transform.position,this.transform.rotation);
		}
	}
}
