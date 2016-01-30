using UnityEngine;
using System.Collections;

public class ActivableTrap : MonoBehaviour {

	// Use this for initialization
    public enum trapTypes { Spikes,Hole,Pusher,Boulder}

    public GameObject spikes;
    public GameObject hole;
    public GameObject pusher;
    public GameObject boulder;

    private GameObject trap;

    public trapTypes trapType;
	void Start () {

	    switch(trapType)
        {
            case trapTypes.Spikes:
                trap = spikes;
                break;
            case trapTypes.Hole:
                trap = hole;
                break;
            case trapTypes.Pusher:
                trap = pusher;
                break;
            case trapTypes.Boulder:
                trap = boulder;
                break;
            default:
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void activate(float time)
    {
        Invoke("createTrap", time);
    }

    public void createTrap()
    {   
        Instantiate(trap, this.transform.position, this.transform.rotation);
    }
}
