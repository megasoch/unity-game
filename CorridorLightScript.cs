using UnityEngine;
using System.Collections;

public class CorridorLightScript : MonoBehaviour {

    public float speed;
    private float angle;
    private bool forward;

	// Use this for initialization
	void Start () {
        forward = true;
        angle = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (angle < 170 && forward)
        {
            angle += speed * Time.deltaTime;
            transform.RotateAround(transform.position, transform.right, speed * Time.deltaTime);
        }
        if (angle >= 170)
        {
            forward = false;
        }
        if (angle > 10 && !forward)
        {
            angle -= speed * Time.deltaTime;
            transform.RotateAround(transform.position, transform.right, -speed * Time.deltaTime);
        }
        if (angle <= 10)
        {
            forward = true;
        }
    }
}
