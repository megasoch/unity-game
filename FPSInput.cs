using UnityEngine;
using System.Collections;

public class FPSInput : MonoBehaviour {

	public float speed = 1.0f;
	private CharacterController characterController;
	private float gravity = -9.8f;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;
		Vector3 movement = new Vector3 (deltaX, gravity, deltaZ);
		movement = Vector3.ClampMagnitude (movement, speed);
		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);
		characterController.Move (movement);
	}
}
