using UnityEngine;
using System.Collections;

public class GroundHole : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Player Died");
			col.gameObject.GetComponent<PlayerDeath>().Kill(1, GameManager.deathTypes.Holes);

        }
    }
}
