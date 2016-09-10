using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    public float speed;
    private float altitude;
    private bool moveUp;

	// Use this for initialization
	void Start () {
        altitude = 0;
        moveUp = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (altitude < 10.0f && moveUp)
        {
            altitude += speed * Time.deltaTime;
            transform.position += transform.up * speed * Time.deltaTime;
        }

        if (altitude > 0.0f && !moveUp)
        {
            altitude -= speed * Time.deltaTime;
            transform.position -= transform.up * speed * Time.deltaTime;
        }
	}

    public void setMoveUp(bool move)
    {
        moveUp = move;
    }
}
