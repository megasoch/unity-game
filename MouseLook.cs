using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;

	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	private float rotationX = 0;
	private float rotationY = 0;

	// Use this for initialization
	void Start () {
		Rigidbody body = GetComponent<Rigidbody> ();
		if (body != null)
			body.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
		rotationX = Mathf.Clamp (rotationX, minimumVert, maximumVert);

		rotationY += Input.GetAxis ("Mouse X") * sensitivityHor;
		transform.localEulerAngles = new Vector3 (rotationX, rotationY, 0);
	}
}
