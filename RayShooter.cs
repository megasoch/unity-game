using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {

	private Camera playerCamera;
    RaycastHit laser;
    LineRenderer lineRenderer;
    bool laserOn;
    public Texture texture;

	// Use this for initialization
	void Start () {
		playerCamera = GetComponent<Camera> ();
        laserOn = false;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
        lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (laserOn)
        {
            Vector3 point1 = new Vector3(playerCamera.pixelWidth / 2, playerCamera.pixelHeight / 2, 0);
            Ray ray1 = playerCamera.ScreenPointToRay(point1);
            Physics.Raycast(ray1, out laser);
            Vector3 from = transform.position;
            from.y = 1;
            drawLine(from, laser.point);
            lineRenderer.enabled = true;
            Vector3 point = new Vector3(playerCamera.pixelWidth / 2, playerCamera.pixelHeight / 2, 0);
            Ray ray = playerCamera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

                if (target != null)
                {
                    target.ReactToHit();
                }
            }
        }
        
        if (Input.GetMouseButtonDown (0)) {
            laserOn = true;
            
		}
        if (Input.GetMouseButtonUp(0))
        {
            laserOn = false;
            lineRenderer.enabled = false;
        }
	}

    private void drawLine(Vector3 from, Vector3 to)
    {
        lineRenderer.SetVertexCount(2);
        lineRenderer.SetColors(Color.blue, Color.blue);
        lineRenderer.SetPosition(0, from);
        lineRenderer.SetPosition(1, to);
        lineRenderer.SetWidth(0.5f, 0.0f);
    }
}
