using UnityEngine;
using System.Collections;

public class FloorSpikes : MonoBehaviour {


    public float timer;
    public bool spikesActive=false;
    Collider2D trigger;
    public bool hidden;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        trigger = this.gameObject.GetComponent<Collider2D>();
        if(!hidden)
        { 
            trigger.enabled = false;
            InvokeRepeating("spikesOn", 0, timer);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void spikesOn()
    {
        trigger.enabled = true;
        spikesActive = true;
        GetComponent<SpriteRenderer>().enabled = true;
        anim.SetBool("GroundSpikes", true);
        Invoke("spikesOff", 0.5f);
    }

    void spikesOff()
    {
        trigger.enabled = false;
        spikesActive = false;
        anim.SetBool("GroundSpikes", false);
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag.Equals("Player"))
        {
            if (hidden)
            {
                
                GetComponent<SpriteRenderer>().enabled = true;
                anim.SetBool("GroundSpikes", true);
                anim.transform.position = col.gameObject.transform.position;
            }
            Debug.Log("Player Died");
            col.gameObject.GetComponent<Animator>().SetBool("IsCrushed", true);
            col.gameObject.GetComponent<GridMove>().setIsDead(true);
            col.gameObject.GetComponent<PlayerDeath>().Kill(2, GameManager.deathTypes.Spikes);
        }
    }
}
