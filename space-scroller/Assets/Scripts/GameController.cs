using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance;

    public bool isDead = false;

    private float scoreRate = 0.5f;
    private float scoreBuffer = 0;
    private int score = 0;

    public Text scoreText;
    public Text endText;
    public Text retryText;

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    public void PlayerCrash() {
        this.isDead = true;
        endText.gameObject.SetActive(true);
        retryText.gameObject.SetActive(true);
    }

    private void Update() {
        if (this.isDead == false) {
            if(this.scoreBuffer > this.scoreRate) {
                this.score += 1;
                this.scoreBuffer = 0;
                scoreText.text = "Score: " + this.score;
            }
            this.scoreBuffer += Time.deltaTime;
        }

        if (this.isDead && Input.GetButtonDown("Jump")) {
            //...reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
