using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip die;

	public void ReactToHit() {
		EnemyAI behavior = GetComponent<EnemyAI> ();
		if (behavior != null) {
            behavior.decreaseHp(Time.deltaTime);
		}
        if (behavior.getHp() <= 0)
        {
            behavior.setAlive (false);
            StartCoroutine(Die());
        }
		
	}

	private IEnumerator Die() {
        audioSource.PlayOneShot(die);
		yield return new WaitForSeconds (3);
		Destroy (this.gameObject);
        if (GameObject.FindGameObjectsWithTag("enemy").Length == 1)
        {
            ResultText.result = "You win!";
            SceneManager.LoadScene(2);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
