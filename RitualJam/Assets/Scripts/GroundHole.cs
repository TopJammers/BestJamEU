using UnityEngine;
using System.Collections;

public class GroundHole : MonoBehaviour {


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
            Debug.Log("Player Died");
            col.gameObject.GetComponent<Animator>().SetBool("IsFalling",true);
            col.gameObject.GetComponent<GridMove>().setIsDead(true);
            col.gameObject.GetComponent<PlayerDeath>().Kill(2, GameManager.deathTypes.Holes);

        }
    }
}
