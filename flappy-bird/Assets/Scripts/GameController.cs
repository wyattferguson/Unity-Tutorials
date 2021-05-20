using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance;			//A reference to our game control script so we can a
    public float scrollSpeed = -5f;

    public Text endText;
    public Text scoreText;

    private int score = 0;
    public bool dead = false;

    void Awake () {
        // setup instance so we can access elsewhere
		if(instance == null) {
            instance = this;
        }
	}

    public void BirdDied() {
        this.dead = true;
        endText.gameObject.SetActive(true);
    }

    public void BirdScored() {
        this.score += 100;
        scoreText.text = "Score: " + this.score;
    }
}
