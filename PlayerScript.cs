using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private float hp;
    private bool alive;

	// Use this for initialization
	void Start () {
        hp = 0.5f;
        alive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0.0f && alive)
        {
            alive = false;
            ResultText.result = "You lose!";
            SceneManager.LoadScene(2);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
	}

    public bool getAlive()
    {
        return alive;
    }

    public void decreaseHp(float x)
    {
        hp -= x;
    }
}
