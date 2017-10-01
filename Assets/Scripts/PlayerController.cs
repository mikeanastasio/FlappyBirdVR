using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public Vector3 speed;
    public float maxVelocity = 5;
    public static bool gameStart;
    public GameObject startMenu;
    public GameObject gameScore;

	void Start() {
		rb = this.GetComponent<Rigidbody> ();
        gameStart = false;
	}
	
	void FixedUpdate() {
        if (!DeathController.isDead && gameStart) {
            startGame();
            rb.useGravity = true;
            rb.AddForce(speed);
            if (rb.velocity.z > maxVelocity) {
                float yVelocity = rb.velocity.y;
                rb.velocity = new Vector3(0f, yVelocity, maxVelocity);
            }
            if (rb.velocity.y > 10) {
                float zVelocity = rb.velocity.z;
                rb.velocity = new Vector3(0f, 10, zVelocity);
            }
			if (Input.GetButtonDown("Fire1") || GvrController.ClickButtonDown) {
                jump();
            }
        }
        rb.useGravity = false;
        if (DeathController.isDead) {
            rb.velocity = new Vector3(0f, 0f, 0f);
        }
		if (!gameStart && (Input.GetButtonDown("Fire1") || GvrController.ClickButtonDown)) {
            gameStart = true;
        }
	}

    public void jump() {
    	rb.AddForce(new Vector3(0f, 1000f, 0f));
    }

    public void startGame(){
        startMenu.SetActive(false);
        gameScore.SetActive(true);
    }
}
