using UnityEngine;
using System.Collections;

public class MovingPlatforms : MonoBehaviour {
    
    public enum Positions { LEFT,CENTER,RIGHT}

    public Positions platformPosition;
    public Positions platformDirection;
    public GameObject platform;
    public float stepSize;
    private float stepCount;
    public float stepTimer;

    private Vector3 offSet;
    
	// Use this for initialization
	void Start () {
        stepCount = 0;
        stepSize = platform.GetComponent<Renderer>().bounds.size.x;
        offSet = new Vector3(0, 0,0);
        InvokeRepeating("movePlatform", 0, stepTimer);

        if (platformDirection.Equals(platformPosition))
        {
            if (platformDirection.Equals(Positions.RIGHT))
            {
                platformDirection = Positions.LEFT;
            }
            else
            {
                platformDirection = Positions.RIGHT;
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void movePlatform()
    {
        stepCount++;
        if(stepCount >=stepTimer)
        {
            switch(platformDirection)
            {
                case Positions.LEFT:
                    offSet = new Vector3(-stepSize, 0,0);
                    platformPosition--;
                    break;
                case Positions.RIGHT:
                    offSet = new Vector3(stepSize, 0,0);
                    platformPosition++;
                    break;      
            }


            this.transform.position += offSet;
            //Cambio de direccion
            if(platformDirection.Equals(platformPosition))
            {
                if(platformDirection.Equals(Positions.RIGHT))
                {
                    platformDirection = Positions.LEFT;
                }
                else
                {
                    platformDirection = Positions.RIGHT;
                }
            }
        }
    }
}
