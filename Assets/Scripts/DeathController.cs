using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour {
    public GameObject walls;
    private Rigidbody rb;
    public GameObject gameOverMenu;
    public GameObject gameScore;
    public static bool isDead;

    void Start() {
        isDead = false;
	}

	void Update() {
		if(isDead && (Input.GetButtonDown("Fire1") || GvrController.ClickButtonDown)) {
            SceneManager.LoadScene("flappyBirdVR");
        }
	}

    private void OnCollisionEnter(Collision collision) {
        death();
		if (collision.gameObject.tag == "floor")
			transform.position = new Vector3 (0, 15, 0);
    }

    public void death() {
        isDead = true;
        Destroy(walls);
        gameOverMenu.SetActive(true);
        gameScore.SetActive(false);     
    }
}