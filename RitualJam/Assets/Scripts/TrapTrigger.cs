using UnityEngine;
using System.Collections;

public class TrapTrigger : MonoBehaviour {

    // Use this for initialization
    public float timer;

    public GameObject trap;


    private bool triggered = false;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!triggered)
        {
            triggered = true;
            if (col.gameObject.tag.Equals("Player"))
            {
                Debug.Log("Trap Activated");
                trap.GetComponent<ActivableTrap>().activate(timer);

            }
        }
    }
}
