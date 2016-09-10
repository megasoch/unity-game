using UnityEngine;
using System.Collections;

public class FootSteps : MonoBehaviour {
    public CharacterController charController;

    public float stepSpeed;

    public AudioClip[] steps;
    AudioSource audioSource;

    // Use this for initialization
    IEnumerator Start () {
        audioSource = GetComponent<AudioSource>();
        charController = GetComponent<CharacterController>();
        while (true)
        {
            if (charController.velocity.magnitude > 5.0f)
            {
                audioSource.PlayOneShot(steps[Random.Range(0, steps.Length)]);
                yield return new WaitForSeconds(stepSpeed);
                
            }
            else
            {
                yield return 0;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}

}
