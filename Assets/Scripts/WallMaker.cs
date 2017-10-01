using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallMaker : MonoBehaviour {

    public GameObject wallPrefab;
    private static Vector3 wallPosition;
    private static float distance;
    public GameObject wallParent;
    private static int count;
    private int highScore;
    public Text scoreText;
    public Text gameOverText;
    public Text highScoreNum;

    void Start() {
        highScore = PlayerPrefs.GetInt("highscore");
        count = 0;
        distance = 0;
        for(int i = 0; i< 20; i++) {
            makeWall();
        }
    }
	
	void Update() {
        if (DeathController.isDead) {
            gameOverText.text = count.ToString();
            if(count > highScore) {
                highScore = count;
                PlayerPrefs.SetInt("highscore", highScore);
            }
            highScoreNum.text = highScore.ToString(); 
        }
	}

    public void makeWall() {
        wallPosition = new Vector3(0f, Random.Range(-5, 5), distance);
        Instantiate(wallPrefab, wallPosition, new Quaternion(0f, 0f, 0f, 0f),wallParent.transform);
        distance += 15;
    }

    private void OnTriggerEnter(Collider other) {
        makeWall();
        count++;
        updateScore();
    }

    public void updateScore() {
        scoreText.text = count.ToString();
    }
}