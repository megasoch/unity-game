using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public float buttonDistance;
    private bool isOpen;
    public DoorScript door;
    public OffMeshLink offMeshLink;

    MeshRenderer meshRenderer;

    // Use this for initialization
    void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
        isOpen = false;
        offMeshLink.activated = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("e"))
        {
            isOpen = !isOpen;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (Vector3.Distance(transform.position, player.transform.position) < buttonDistance)
            {
                if(isOpen)
                {
                    door.setMoveUp(true);
                    meshRenderer.material.color = Color.green;
                    offMeshLink.activated = true;
                } else
                {
                    door.setMoveUp(false);
                    meshRenderer.material.color = Color.black;
                    offMeshLink.activated = false;
                }
                
            }
        }   
	}
}
