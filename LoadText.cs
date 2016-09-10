using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text result = GetComponent<Text>();
        result.text = ResultText.result;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
    