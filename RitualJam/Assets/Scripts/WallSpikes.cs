using UnityEngine;
using System.Collections;

public class WallSpikes : MonoBehaviour {

    // Use this for initialization

    public GameObject spikes;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        

        if(col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Player Died");
            //col.getCompontent<PlayerDeath>().kill();
            Instantiate(spikes,this.transform.position,this.transform.rotation);
            
        }
    }
}
