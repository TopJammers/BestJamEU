using UnityEngine;
using System.Collections;

public class WallSpikes : MonoBehaviour {

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
            Animator anim = GetComponent<Animator>();
            this.gameObject.GetComponent<Renderer>().enabled = true;
            GridMove player = col.gameObject.GetComponent<GridMove>();
            anim.transform.position = player.getObjectivePosition();
            string dir = player.getActiveCommand();
            switch (dir)
            {
                case "left":
                    Debug.Log("Intento de giro");
                    transform.eulerAngles = new Vector3(0, 0, 90);
                    break;
                case "right":
                    Debug.Log("Intento de giro");
                    transform.eulerAngles = new Vector3(0, 0, 270);
                    break;
                case "down":
                    Debug.Log("Intento de giro");
                    transform.eulerAngles = new Vector3(0, 0, 180);
                    break;
                default:
                    break;
                    
                    
            }
            
            

            anim_wall.SetBool("DeathWall",true);
			col.gameObject.GetComponent<GridMove>().setIsDead(true);
			col.gameObject.GetComponent<SpriteRenderer>().enabled=false;

			col.gameObject.GetComponent<PlayerDeath>().Kill(1, GameManager.deathTypes.Spikes);

            //Instantiate(spikes,this.transform.position,this.transform.rotation);
        }
    }
}
