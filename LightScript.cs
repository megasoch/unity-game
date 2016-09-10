using UnityEngine;
using System.Collections;

public class LightScript : MonoBehaviour {

    public float duration = 1.0f;
    private Light sinusLight;

	// Use this for initialization
	void Start () {   
        sinusLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.5f + 0.5f;
        sinusLight.intensity = amplitude;
    }
}
